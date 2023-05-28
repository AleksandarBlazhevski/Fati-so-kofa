using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa.Shapes.Circle
{
    
    public class Circle : Shape
    {
        //Center point, circle color, movement speed, circle radius
        public Circle(Point center, Color color, int speed, int size) : base(center, color, speed, size)
        {
        }

        public override bool isHit(Point playerCenter, int playerSize)
        {
            float distanceX = Math.Abs(Center.X - playerCenter.X);
            float distanceY = Math.Abs(Center.Y - playerCenter.Y);
            if (distanceX > (playerSize / 2f) + Size) return false;
            if (distanceY > (playerSize / 2f) + Size) return false;
            if (distanceX <= (playerSize / 2f)) return true;
            if (distanceY <= (playerSize / 2f)) return true;

            double cornerDist_sq = Math.Pow((distanceX - (playerSize / 2f)), 2) + Math.Pow((distanceY - (playerSize / 2f)), 2);
            return (cornerDist_sq <= (Size * Size));
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.Color);
            g.FillEllipse(b, Center.X, Center.Y, Size * 2, Size * 2);
            b.Dispose();
        }

        public override void Move(int distance)
        {
            Center = new Point(Center.X, Center.Y + distance);
        }
    }
}
