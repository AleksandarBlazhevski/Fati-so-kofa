using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fati_so_kofa
{
    public class Player
    {
        public Point Postiion { get; set; }
        public Color Color { get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }

        //Top left point, player color, player speed, square side
        public Player(Point postiion, Color color, int speed, int size)
        {
            Postiion = postiion;
            Color = color;
            Speed = speed;
            Size = size;
        }

        public void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(this.Color);
            g.FillRectangle(b, Postiion.X, Postiion.Y, Size, Size);
            b.Dispose();
        }
        public void MoveLeft() { 
            Postiion = new Point(Postiion.X - Speed, Postiion.Y);
        }
        public void MoveRight()
        {
            Postiion = new Point(Postiion.X + Speed, Postiion.Y);
        }
        public void MoveUp()
        {
            Postiion = new Point(Postiion.X, Postiion.Y - Speed);
        }
        public void MoveDown()
        {
            Postiion = new Point(Postiion.X, Postiion.Y + Speed);
        }
    }
}
