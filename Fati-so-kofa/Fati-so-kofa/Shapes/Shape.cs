using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa.Shapes
{
    /// <summary>
    /// Represents the basic attributes needed for shape
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Shape's center coordinate
        /// </summary>
        public Point Center{ get; set; }
        /// <summary>
        /// Shape's movement speed
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Shape's width and height
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Shape's color
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Shape's X coordinate where it does something
        /// </summary>
        public int RedLine { get; private set; }

        protected Shape(Point center, int speed, int size, int redLine)
        {
            Center = center;
            Speed = speed;
            Size = size;
            RedLine = redLine;
        }

        /// <summary>
        /// Changes the Center coordinates
        /// </summary>
        /// <param name="distance"></param>
        public abstract void Move(int distance);
        /// <summary>
        /// Draws the shape on the graphics
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// Checks for collision with the player
        /// </summary>
        /// <param name="playerCenter">Player posion</param>
        /// <param name="playerSize">Player widht and height</param>
        /// <returns>Returns true if collides with the player or false if not</returns>
        public abstract bool isHit(Point playerCenter, int playerSize);
    }
}
