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
        
        public GameForm(int lastHighScore)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            pbShapesSpeed.Maximum = 5;
            pbShapesSpeed.Minimum = 1;
            pbShapesSpeed.Step = 1;

            pbShapesSpawnRate.Maximum = 10;
            pbShapesSpawnRate.Minimum = 1;
            pbShapesSpawnRate.Step = 1;



            spawner = new Spawner(tShapeSpawner, lShapeSpeed, lShapesSpawnRate);
            scoreManager = new ScoreManager(lScore, spawner, lLifes, lConsMisses, lastHighScore, pbShapesSpeed, pbShapesSpawnRate);
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

        private bool isLost()
        {
            if(scoreManager.Lifes <= 0)
            {
                return true;
            }
            if(scoreManager.ConsecutiveMisses >= 10)
            {
                return true;
            }
            return false;
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
                        scoreManager.resetConsecMisses();
                    }
                    else
                    {
                        scoreManager.removePoint();
                    }
                    s.Color = Color.White;
                    
                }
            }
            if(spawner.ShapesList.FindAll(r => r.Center.Y >= 650).Any<Shape>())
            {
                scoreManager.incMissedCircles();
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
            if (isLost())
            {
                tShapeMover.Stop();
                tPlayerMover.Stop();
                tShapeSpawner.Stop();
                scoreManager.updateScores();
                GameOverForm gameOverForm = new GameOverForm(scoreManager.score, scoreManager.topScore);
                if(gameOverForm.ShowDialog() == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }
            }
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

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'v')
            {
                player.changeColor();
            }
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
        public int getData()
        {
            return scoreManager.score;
        }
    }
}
