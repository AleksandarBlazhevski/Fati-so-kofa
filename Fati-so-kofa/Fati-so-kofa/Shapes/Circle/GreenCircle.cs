using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes.Circle
{
    public class GreenCircle : Circle
    {
        public GreenCircle(Point center, int speed, int size, int redLine) : base(center, speed, size, redLine)
        {
            Color = Color.Green;
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.Color);
            g.FillEllipse(b, Center.X, Center.Y, Size * 2, Size * 2);
            b.Dispose();
        }

        public override void Move(int distance)
        {
            if (Center.Y > RedLine) {
                Center = new Point(Center.X, Center.Y + distance * 2);
            }
            else
            {
                Center = new Point(Center.X, Center.Y + distance);
            }
        }
    }
}
