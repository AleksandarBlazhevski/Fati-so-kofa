using Fati_so_kofa.Shapes;
using Fati_so_kofa.Shapes.Circle;
using System;
using System.Collections.Generic;
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

        private readonly int FirstLine = 30;
        private readonly int SecoundLine = 170;
        private readonly int ThirdLine = 330;

        public Spawner(Timer spawnTimer)
        {
            ShapesList = new List<Shape>();
            spawnFrequency = 4000;
            shapeSpeed = 3;
            this.spawnTimer = spawnTimer;
            updateFrequency();
        }
        public void increaseFrequency(int howMuch)
        {
            spawnFrequency-=howMuch;
            updateFrequency();
        }
        public void decreaseFrequency(int howMuch)
        {
            spawnFrequency+=howMuch;
            updateFrequency();
        }
        public void increaseSpeed(int howMuch)
        {
            shapeSpeed += howMuch;
        }
        public void decreaseSpeed(int howMuch)
        {
            shapeSpeed -= howMuch;
        }
        private int pickLine()
        {
            Random random = new Random();

            int line = random.Next(0, 3);
            switch (line)
            {
                case 0:
                    return FirstLine;
                case 1:
                    return SecoundLine;
                case 2:
                    return ThirdLine;
                default:
                    return 0;

            }
        }
        public void spawnShape()
        {
            ShapesList.Add(new Circle(new Point(pickLine(), 0), Color.Green, shapeSpeed, 20));

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
    }
}
