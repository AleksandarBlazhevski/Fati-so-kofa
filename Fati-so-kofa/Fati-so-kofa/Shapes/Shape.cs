using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes
{

    public abstract class Shape
    {
        public Point Center{ get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public int RedLine { get; private set; }

        protected Shape(Point center, int speed, int size, int redLine)
        {
            Center = center;
            Speed = speed;
            Size = size;
            RedLine = redLine;
        }

        public abstract void Move(int distance);

        public abstract void Draw(Graphics g);

        public abstract bool isHit(Point playerCenter, int playerSize);
    }
}
