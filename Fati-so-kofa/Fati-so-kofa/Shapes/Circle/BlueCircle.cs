using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes.Circle
{
    /// <summary>
    /// Represents the attributes needed for blue circle
    /// </summary>
    public class BlueCircle : Circle
    {
        /// <summary>
        /// Is circle blinked in his life span
        /// </summary>
        private bool blinked;
        public BlueCircle(Point center, int speed, int size, int redLine) : base(center, speed, size, redLine)
        {
            Color = Color.Blue;
            blinked = false;
        }
        /// <summary>
        /// Draws the green circle on the graphics
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.Color);
            g.FillEllipse(b, Center.X, Center.Y, Size * 2, Size * 2);
            b.Dispose();
        }
        /// <summary>
        /// Moves the center of the circle
        /// </summary>
        /// <param name="distance"></param>
        public override void Move(int distance)
        {
            //Blue ball is in middle and not blinked
            if(!blinked && Center.Y > RedLine && Center.X == 170)
            {
                //Blink forward
                Center = new Point(Center.X, Center.Y + 60);
                blinked = true;
            }
            //Blue ball is on the side and not bliked
            if(!blinked && Center.Y > RedLine && (Center.X == 30 || Center.X == 330))
            {
                //Blink in other side line
                Center = new Point(Center.X == 30? 330 : 30, Center.Y);
                blinked = true;
            }
            //Move forward
            Center = new Point(Center.X, Center.Y + distance);
        }
    }
}
