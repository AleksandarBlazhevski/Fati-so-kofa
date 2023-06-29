using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa
{
    /// <summary>
    /// Represents the player containing the following information:
    /// Position - player top left coordinate
    /// Color - player color
    /// Speed - player movment speed
    /// Size - player width and height
    /// </summary>
    public class Player
    {
        public Point Postiion { get; set; }
        public Color Color { get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }

        //Top left point, player color, player speed, square size
        public Player(Point postiion, Color color, int speed, int size)
        {
            Postiion = postiion;
            Color = color;
            Speed = speed;
            Size = size;
        }
        /// <summary>
        /// Draws rectangle on the graphics provided
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(this.Color);
            g.FillRectangle(b, Postiion.X, Postiion.Y, Size, Size);
            b.Dispose();
        }
        /// <summary>
        /// Move the top left coordinate to the left by the speed
        /// </summary>
        public void MoveLeft() { 
            Postiion = new Point(Postiion.X - Speed, Postiion.Y);
        }
        /// <summary>
        /// Move the top left coordinate to the right by the speed
        /// </summary>
        public void MoveRight()
        {
            Postiion = new Point(Postiion.X + Speed, Postiion.Y);
        }
        /// <summary>
        /// Change the color of the player (Red -> Green -> Blue -> Red)
        /// </summary>
        public void changeColor()
        {
            if(Color == Color.Red)
            {
                Color = Color.Green;
            }
            else if(Color == Color.Green)
            {
                Color = Color.Blue;
            }
            else if(Color == Color.Blue)
            {
                Color = Color.Red;
            }
        }
    }
}
