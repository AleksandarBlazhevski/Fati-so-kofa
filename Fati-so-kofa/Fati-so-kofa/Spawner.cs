using Fati_so_kofa.Shapes;
using Fati_so_kofa.Shapes.Circle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa
{
    /// <summary>
    /// Handles the spawning mechanisam of the shapes
    /// </summary>
    public class Spawner
    {
        /// <summary>
        /// Stores all shapes spawned
        /// </summary>
        public List<Shape> ShapesList { get; set; }
        /// <summary>
        /// Stores the current shape speed
        /// </summary>
        private int shapeSpeed;
        /// <summary>
        /// Stores the time between shape spawned
        /// </summary>
        private int spawnFrequency;
        /// <summary>
        /// Timer that interval can be modified to alter spawn rates of the shapes
        /// </summary>
        private Timer spawnTimer;
        /// <summary>
        /// Label to show the current shapes speed
        /// </summary>
        private Label shapesSpeedLabel;
        /// <summary>
        /// Label to show the current shapes spawn rate
        /// </summary>
        private Label shapeRespawnLabel;
        /// <summary>
        /// Y coordinate to the red line drawn on the form
        /// </summary>
        private int redLine;
        /// <summary>
        /// Instance of random used to randomise the line that the new shape spawns
        /// </summary>
        private Random randomLinePicker;
        /// <summary>
        /// Instance of random used to pick a direction where the middle red circle will move
        /// </summary>
        private Random randomRed;
        /// <summary>
        /// Static variables for X coordinate of the lines that the shapes can spawn
        /// </summary>
        private readonly int FIRST_LINE = 30;
        private readonly int SECOUND_LINE = 170;
        private readonly int THIRD_LINE = 330;

        public Spawner(Timer spawnTimer, Label shapesSpeedLabel, Label shapeRespawnLabel)
        {
            ShapesList = new List<Shape>();
            spawnFrequency = 2000;
            randomLinePicker = new Random();
            randomRed = new Random();
            shapeSpeed = 3;
            redLine = 300;
            this.spawnTimer = spawnTimer;
            updateFrequency();
            this.shapesSpeedLabel = shapesSpeedLabel;
            this.shapeRespawnLabel = shapeRespawnLabel;
            updateShapesInfo();
        }
        /// <summary>
        /// Increases the frequency of the shapes spawn rate
        /// </summary>
        /// <param name="howMuch">How much to subtract the spawnFrequency value</param>
        public void increaseFrequency(int howMuch)
        {
            if(spawnFrequency == 200)
            {
                return;
            }
            spawnFrequency-=howMuch;
            updateFrequency();
            updateShapesInfo();
        }
        /// <summary>
        /// Decreases the frequency of the shapes spawn rate
        /// </summary>
        /// <param name="howMuch">How much to add the spawnFrequency value</param>
        public void decreaseFrequency(int howMuch)
        {
            if(spawnFrequency == 2000)
            {
                return;
            }
            spawnFrequency+=howMuch;
            updateFrequency();
            updateShapesInfo();
        }
        /// <summary>
        /// Increases the speed of shapes
        /// </summary>
        /// <param name="howMuch"></param>
        public void increaseSpeed(int howMuch)
        {
            shapeSpeed += howMuch;
            updateShapesInfo();
        }
        /// <summary>
<<<<<<< HEAD
        /// Increases the speed of shapes
=======
<<<<<<< HEAD
        /// Decreases the speed of shapes
=======
        /// Increases the speed of shapes
>>>>>>> d242a9540e760fbd9bccf6a67c5f4ddfb6253c9a
>>>>>>> 93158a0 (Finished documentation)
        /// </summary>
        /// <param name="howMuch"></param>
        public void decreaseSpeed(int howMuch)
        {
            shapeSpeed -= howMuch;
            if (shapeSpeed <= 0)
            {
                shapeSpeed = 1;
                return;
            }
            updateShapesInfo();
        }
        /// <summary>
        /// Picks the line in which the shape will spawn
        /// </summary>
        /// <returns>Returns integer value corresponding to the line number</returns>
        private int pickLine()
        {
            int line = randomLinePicker.Next(0, 3);
            switch (line)
            {
                case 0:
                    return FIRST_LINE;
                case 1:
                    return SECOUND_LINE;
                case 2:
                    return THIRD_LINE;
                default:
                    return SECOUND_LINE;
            }
        }
        /// <summary>
        /// Generates random integer used to create shape corresponding to that integer
        /// </summary>
        /// <returns>Random shape</returns>
        private Shape pickShape()
        {
            int shapeNum = randomLinePicker.Next(0, 3);
            switch(shapeNum)
            {
                case 0:
                    return new GreenCircle(new Point(pickLine(), 0), shapeSpeed, 20, redLine);
                case 1:
                    return new BlueCircle(new Point(pickLine(), 0), shapeSpeed, 20, redLine);
                case 2:
                    return new RedCircle(new Point(pickLine(), 0), shapeSpeed, 20, redLine, randomRed);
                default:
                    throw new ShapeNotFoundException();
            }
        }
        /// <summary>
        /// Adds random shape to the ShapeList
        /// </summary>
        public void spawnShape()
        {
            ShapesList.Add(pickShape());

        }
        /// <summary>
        /// Draws all shapes on the graphics provided
        /// </summary>
        /// <param name="g">Graphscs to draw on</param>
        public void drawAll(Graphics g)
        {
            foreach(Shape s in ShapesList)
            {
                s.Draw(g);
            }
        }
        /// <summary>
        /// Invokes Move(shapeSpeed) on all shapes in ShapesList
        /// </summary>
        public void MoveAllShapes()
        {
            foreach(Shape s in ShapesList)
            {
                s.Move(shapeSpeed);
            }
        }
        /// <summary>
        /// Updates the shawnTimer to the spawn frequency
        /// </summary>
        private void updateFrequency()
        {
            this.spawnTimer.Interval = spawnFrequency;
        }
        /// <summary>
        /// Updates the shapes information on the display labels
        /// </summary>
        private void updateShapesInfo()
        {
            shapesSpeedLabel.Text = "Shapes speed: " + shapeSpeed;
            shapeRespawnLabel.Text = "Shapes spawn every: " + spawnFrequency/1000f +" s";
        }
        /// <summary>
        /// Draws the red line on the graphics provided
        /// </summary>
        /// <param name="g"></param>
        public void drawLine(Graphics g)
        {
            Pen p = new Pen(Color.Red);
            g.DrawLine(p, 0, redLine, 400, redLine);
            p.Dispose();
        }
        /// <summary>
        /// Removes white colored or below the window shapes
        /// </summary>
        public void removeDestroyed()
        {

            ShapesList.RemoveAll(r => r.Color == Color.White || r.Center.Y >= 650);
        }
    }
}
