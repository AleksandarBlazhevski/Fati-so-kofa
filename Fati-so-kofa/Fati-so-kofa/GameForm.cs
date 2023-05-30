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
        bool pressedLeft, pressedRight;
        private Spawner spawner;
        private ScoreManager scoreManager;
        Player player = new Player(new Point(170, 500), Color.Blue, 10, 40);
        
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            

            spawner = new Spawner(tShapeSpawner);
            scoreManager = new ScoreManager(lScore, spawner);
            tShapeMover.Start();
            tPlayerMover.Start();
            tShapeSpawner.Start();

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


        }

        private void tPlayerMover_Tick(object sender, EventArgs e)
        {
            foreach(Shape s in spawner.ShapesList)
            {
                if (s.isHit(player.Postiion, player.Size))
                {
                    if(player.Color == s.Color)
                    {
                        scoreManager.addPoint();
                        player.changeColor();
                    }
                    else
                    {
                        scoreManager.removePoint();
                    }
                    s.Color = Color.White;
                    
                }
            }
            spawner.removeDestroyed();

            if (pressedLeft && player.Postiion.X > 0)
            {
                player.MoveLeft();
            }
            if (pressedRight && player.Postiion.X < 345)
            {
                player.MoveRight();
            }

            Invalidate();
        }

        private void tShapeSpawner_Tick(object sender, EventArgs e)
        {
            spawner.spawnShape();
        }



        private void GameForm_Paint(object sender, PaintEventArgs e)
        {

            spawner.drawAll(e.Graphics);
            player.Draw(e.Graphics);
            spawner.drawLine(e.Graphics);
        }

        private void tShapeMover_Tick(object sender, EventArgs e)
        {
            spawner.MoveAllShapes();
            Invalidate();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) {
                
                pressedLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                pressedRight = true;
            }
        }
    }
}
