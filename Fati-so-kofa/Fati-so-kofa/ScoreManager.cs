using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa
{
    /// <summary>
    /// Handles the player score and displays it 
    /// </summary>
    public class ScoreManager
    {
        /// <summary>
        /// Stores the score as integer
        /// </summary>
        public int score;
        /// <summary>
        /// Stores the highest score until present
        /// </summary>
        public int topScore;
        /// <summary>
        /// Label for the live score
        /// </summary>
        private Label lScore;
        /// <summary>
        /// Label for remaining lifes
        /// </summary>
        private Label lLifes;
        /// <summary>
        /// Label for consecutive circle misses
        /// </summary>
        private Label lConsMisses;
        /// <summary>
        /// Instance of the class spawner
        /// </summary>
        private Spawner spawner;
        /// <summary>
        /// Progress bar for the shapes speed
        /// </summary>
        private ProgressBar pbShapesSpeed;
        /// <summary>
        /// Progress bar for the shapes spawn rate
        /// </summary>
        private ProgressBar pbShapesSpawnRate;
        /// <summary>
        /// Stores the consecutive missses as integer
        /// </summary>
        public int ConsecutiveMisses { get; private set; }
        /// <summary>
        /// Stores remaining lifes as integer
        /// </summary>
        public int Lifes { get; private set; }

        public ScoreManager(Label lScore, Spawner spawner, Label lLifes, Label lConsMisses, int lastHighScore, ProgressBar pbShapesSpeed, ProgressBar pbShapesSpawnRate)
        {
            this.spawner = spawner;
            this.lScore = lScore;
            this.lLifes = lLifes;
            this.lConsMisses = lConsMisses;
            this.pbShapesSpeed = pbShapesSpeed;
            this.pbShapesSpawnRate = pbShapesSpawnRate;
            topScore = lastHighScore;
            score = 0;
            Lifes = 3;
            ConsecutiveMisses = 0;
        }
        /// <summary>
        /// Sets the highest score as current score or previous high score
        /// </summary>
        public void updateScores()
        {
            topScore = score >= topScore ? score : topScore;
        }
        /// <summary>
        /// Increments consecutive misses
        /// </summary>
        public void incMissedCircles()
        {
            ConsecutiveMisses++;
            updateLabel();
        }
        /// <summary>
        /// Sets consecutive misses to 0
        /// </summary>
        public void resetConsecMisses()
        {
            ConsecutiveMisses = 0;
            updateLabel();
        }
        /// <summary>
        /// Increments score and updates the values of all progress bars and the score label
        /// </summary>
        public void addPoint()
        {
            score++;
            pbShapesSpeed.Value = pbShapesSpeed.Value == 5 ? 1 : pbShapesSpeed.Value + 1;
            pbShapesSpawnRate.Value = pbShapesSpawnRate.Value == 10 ? 1 : pbShapesSpawnRate.Value + 1;
            if (score % 5 == 0 && score % 10 != 0)
            {
                spawner.increaseSpeed(1);
            }
            if (score % 10 == 0 && score > 0)
            {
                spawner.increaseFrequency(200);
            }
            updateLabel();
        }
        /// <summary>
        /// Decrements score ,lifes and updates the values of all progress bars and the score label
        /// </summary>
        public void removePoint()
        {
            pbShapesSpeed.Value = pbShapesSpeed.Value == 1 ? 5 : pbShapesSpeed.Value - 1;
            pbShapesSpawnRate.Value = pbShapesSpawnRate.Value == 1 ? 10 : pbShapesSpawnRate.Value - 1;
            if (score % 5 == 0 && score % 10 != 0)
            {
                spawner.decreaseSpeed(1);
            }
            if (score % 10 == 0)
            {
                spawner.decreaseFrequency(200);
            }
            score--;
            //Reduce remaining lifes
            Lifes--;
            updateLabel();
        }
        /// <summary>
        /// Updates the display labels to proper values
        /// </summary>
        public void updateLabel()
        {
            lScore.Text = "Score: " + score;
            lLifes.Text = "Lifes remaining: " + Lifes;
            lConsMisses.Text = "Consecutive misses: " + ConsecutiveMisses;
        }
        
        
    }
}
