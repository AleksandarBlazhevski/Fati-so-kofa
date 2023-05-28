using Fati_so_kofa.Shapes;
using Fati_so_kofa.Shapes.Circle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Fati_so_kofa
{
   
    public partial class GameForm : Form
    {
        bool pressedUp, pressedDown, pressedLeft, pressedRight;
        private Spawner spawner;
        Player player = new Player(new Point(80, 80), Color.Blue, 5, 40);
        
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            

            spawner = new Spawner(tShapeSpawner);
            tShapeMover.Start();
            tPlayerMover.Start();
            tShapeSpawner.Start();

            pressedDown = false;
            pressedUp = false;
            pressedLeft = false;
            pressedRight = false;
            
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pressedLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                pressedRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                pressedUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                pressedDown = false;
            }

        }

        private void tPlayerMover_Tick(object sender, EventArgs e)
        {
            foreach(Shape s in spawner.ShapesList)
            {
                if (s.isHit(player.Postiion, player.Size))
                {
                    s.Color = Color.Red;
                }
                else
                {
                    s.Color = Color.Green;
                }
            }

            if (pressedLeft)
            {
                player.MoveLeft();
            }
            if (pressedRight)
            {
                player.MoveRight();
            }
            if (pressedUp)
            {
                player.MoveUp();
            }
            if (pressedDown)
            {
                player.MoveDown();
            }
            Invalidate();
        }

        private void tShapeSpawner_Tick(object sender, EventArgs e)
        {
            spawner.spawnShape();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spawner.increaseFrequency(1000);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {

            spawner.drawAll(e.Graphics);
            player.Draw(e.Graphics);
        }

        private void tShapeMover_Tick(object sender, EventArgs e)
        {
            spawner.MoveAllShapes();
            Invalidate();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("Key down");
            if (e.KeyCode == Keys.Left) {
                
                pressedLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                pressedRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                pressedUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                pressedDown = true;
            }
        }
    }
}
