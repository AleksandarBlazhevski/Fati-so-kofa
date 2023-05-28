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
        public Color Color { get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }

        protected Shape(Point center, Color color, int speed, int size)
        {
            Center = center;
            Color = color;
            Speed = speed;
            Size = size;
        }

        public abstract void Move(int lenth);

        public abstract void Draw(Graphics g);

        public abstract bool isHit(Point playerCenter, int playerSize);
    }
}
