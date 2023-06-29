using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes.Circle
{
    /// <summary>
    /// Represents the attributes needed for green circle
    /// </summary>
    public class GreenCircle : Circle
    {
        public GreenCircle(Point center, int speed, int size, int redLine) : base(center, speed, size, redLine)
        {
            Color = Color.Green;
        }
        /// <summary>
        /// Draws the green cricle on the graphics
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.Color);
            g.FillEllipse(b, Center.X, Center.Y, Size * 2, Size * 2);
            b.Dispose();
        }
        /// <summary>
        /// Moves the center of the green circle
        /// </summary>
        /// <param name="distance"></param>
        public override void Move(int distance)
        {
            //When passes the red line, speed increases to double
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
