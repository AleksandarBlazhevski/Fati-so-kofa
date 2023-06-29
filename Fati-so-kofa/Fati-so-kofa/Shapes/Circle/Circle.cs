using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa.Shapes.Circle
{
    /// <summary>
    /// Represents the basic attributes needed for circle
    /// </summary>
    public abstract class Circle : Shape
    {
        public Circle(Point center, int speed, int size, int redLine) : base(center, speed, size, redLine)
        {
        }
        /// <summary>
        /// Checks for collision with the player
        /// </summary>
        /// <param name="playerCenter">Player posion</param>
        /// <param name="playerSize">Player widht and height</param>
        /// <returns>Returns true if collides with the player or false if not</returns>
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

 

    }
}
