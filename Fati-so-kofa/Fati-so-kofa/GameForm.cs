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
   /// <summary>
   /// Game form responsible for handling the game and player inputs
   /// </summary>
    public partial class GameForm : Form
    {
        /// <summary>
        /// Saves the player inputs
        /// </summary>
        bool pressedLeft, pressedRight;
        /// <summary>
        /// Instance of the class spawner
        /// </summary>
        private Spawner spawner;
        /// <summary>
        /// Instance of the class ScoreManager
        /// </summary>
        private ScoreManager scoreManager;
        /// <summary>
        /// Instance of the class player
        /// </summary>
        Player player = new Player(new Point(170, 500), Color.Blue, 10, 40);
        /// <summary>
        /// Initialize the game with predetermined values
        /// </summary>
        /// <param name="lastHighScore"></param>
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
        /// <summary>
        /// When specific key is released it sets the particular property to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Checks the lost scenarios
        /// </summary>
        /// <returns>Return true if conditions are met</returns>
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
        /// <summary>
        /// Handles all player interactions with the shapes and window boundaries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tPlayerMover_Tick(object sender, EventArgs e)
        {
            //Checks all shapes for collisons
            foreach(Shape s in spawner.ShapesList)
            {
                if (s.isHit(player.Postiion, player.Size))
                {
                    //Checks for same colors
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
                    //Sets the shape color to white (ready for deletion)
                    s.Color = Color.White;
                    
                }
            }
            //Checks for shapes below the window that are missed
            if(spawner.ShapesList.FindAll(r => r.Center.Y >= 650).Any<Shape>())
            {
                scoreManager.incMissedCircles();
            }
            //Removes destroyed shapes
            spawner.removeDestroyed();

            //Moves the player to left if in boundary
            if (pressedLeft && player.Postiion.X > 0)
            {
                player.MoveLeft();
            }
            //Moves the player to right if in boundary
            if (pressedRight && player.Postiion.X < 345)
            {
                player.MoveRight();
            }

            Invalidate();
            //Checks if player lost
            if (isLost())
            {
                //Stops all timers
                tShapeMover.Stop();
                tPlayerMover.Stop();
                tShapeSpawner.Stop();
                scoreManager.updateScores();
                //Shows gameover form
                GameOverForm gameOverForm = new GameOverForm(scoreManager.score, scoreManager.topScore);
                if(gameOverForm.ShowDialog() == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }
        /// <summary>
        /// Timers ticks are responsible for spawning shapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tShapeSpawner_Tick(object sender, EventArgs e)
        {
            spawner.spawnShape();
        }


        /// <summary>
        /// Draws all components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {

            spawner.drawAll(e.Graphics);
            player.Draw(e.Graphics);
            spawner.drawLine(e.Graphics);
        }
        /// <summary>
        /// Timer ticks are responisble for shapes movement cycles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tShapeMover_Tick(object sender, EventArgs e)
        {
            spawner.MoveAllShapes();
            Invalidate();
        }
        /// <summary>
        /// When pressed key 'v' changes the player color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'v')
            {
                player.changeColor();
            }
        }
        /// <summary>
        /// When specific key is released it sets the particular property to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// When invoced sends the current score
        /// </summary>
        /// <returns>Returns current score as integer</returns>
        public int getData()
        {
            return scoreManager.score;
        }
    }
}
