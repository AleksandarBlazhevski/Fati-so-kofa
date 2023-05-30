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
    public class Spawner
    {
        public List<Shape> ShapesList { get; set; }
        private int shapeSpeed;
        private int spawnFrequency;
        private Timer spawnTimer;
        private Label shapesSpeedLabel;
        private Label shapeRespawnLabel;

        private int redLine;
        private Random randomLinePicker;
        private Random randomRed;

        private readonly int FirstLine = 30;
        private readonly int SecoundLine = 170;
        private readonly int ThirdLine = 330;

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
        public void increaseSpeed(int howMuch)
        {
            shapeSpeed += howMuch;
            updateShapesInfo();
        }
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
        private int pickLine()
        {
            int line = randomLinePicker.Next(0, 3);
            switch (line)
            {
                case 0:
                    return FirstLine;
                case 1:
                    return SecoundLine;
                case 2:
                    return ThirdLine;
                default:
                    return SecoundLine;
            }
        }
        private Shape pickShape()
        {
            int shapeNum = randomLinePicker.Next(0, 3);
            //int shapeNum = 2;
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
        public void spawnShape()
        {
            ShapesList.Add(pickShape());

        }
        public void drawAll(Graphics g)
        {
            foreach(Shape s in ShapesList)
            {
                s.Draw(g);
            }
        }
        public void MoveAllShapes()
        {
            foreach(Shape s in ShapesList)
            {
                s.Move(shapeSpeed);
            }
        }
        private void updateFrequency()
        {
            this.spawnTimer.Interval = spawnFrequency;
        }
        private void updateShapesInfo()
        {
            shapesSpeedLabel.Text = "Shapes speed: " + shapeSpeed;
            shapeRespawnLabel.Text = "Shapes spawn every: " + spawnFrequency/1000f +" s";
        }
        public void drawLine(Graphics g)
        {
            Pen p = new Pen(Color.Red);
            g.DrawLine(p, 0, redLine, 400, redLine);
            p.Dispose();
        }
        //Remove circles colored white or below window
        public void removeDestroyed()
        {
            ShapesList.RemoveAll(r => r.Color == Color.White || r.Center.Y >= 650);
        }
    }
}
