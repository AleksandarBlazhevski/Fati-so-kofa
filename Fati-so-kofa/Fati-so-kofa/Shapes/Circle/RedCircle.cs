using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes.Circle
{
    public class RedCircle : Circle
    {
        private bool isMiddle;
        private bool goLeft;
        public RedCircle(Point center, int speed, int size, int redLine, Random side) : base(center, speed, size, redLine)
        {
            if(Center.X == 170)
            {
                isMiddle = true;
            }
            else
            {
                isMiddle = false;
            }
            if(side.Next(0,2) == 0)
            {
                goLeft = true;
            }
            else
            {
                goLeft = false;
            }
            Color = Color.Red;
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.Color);
            g.FillEllipse(b, Center.X, Center.Y, Size * 2, Size * 2);
            b.Dispose();
        }

        public override void Move(int distance)
        {
            //In the left line move invards
            if(Center.Y > RedLine && Center.X >= 30 && Center.X < 170 && !isMiddle)
            {
                Center = new Point(Center.X + distance, Center.Y);
            }
            //In the right line move invards
            if (Center.Y > RedLine && Center.X > 170 && Center.X <= 330 && !isMiddle)
            {
                Center = new Point(Center.X - distance , Center.Y);
            }
            //In the middle pick a side to move
            if(Center.Y > RedLine && isMiddle && !(Center.X <= 30 || Center.X >= 330))
            {
                Center = new Point(goLeft ? Center.X - (distance)  : Center.X + (distance), Center.Y);
            }
            Center = new Point(Center.X, Center.Y + distance);
        }
    }
}
