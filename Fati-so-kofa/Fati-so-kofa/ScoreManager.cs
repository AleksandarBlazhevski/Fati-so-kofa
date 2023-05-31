using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa
{
    public class ScoreManager
    {
        public int score;
        public int topScore;
        private Label lScore;
        private Label lLifes;
        private Label lConsMisses;
        private Spawner spawner;

        public int ConsecutiveMisses { get; private set; }
        public int Lifes { get; private set; }

        public ScoreManager(Label lScore, Spawner spawner, Label lLifes, Label lConsMisses, int lastHighScore)
        {
            this.spawner = spawner;
            this.lScore = lScore;
            this.lLifes = lLifes;
            this.lConsMisses = lConsMisses;
            topScore = lastHighScore;
            score = 0;
            Lifes = 3;
            ConsecutiveMisses = 0;
        }
        public void updateScores()
        {
            topScore = score >= topScore ? score : topScore;
        }
        public void incMissedCircles()
        {
            ConsecutiveMisses++;
            updateLabel();
        }
        public void resetConsecMisses()
        {
            ConsecutiveMisses = 0;
            updateLabel();
        }
        public void addPoint()
        {
            score++;
            if(score % 5 == 0 && score % 10 != 0)
            {
                spawner.increaseSpeed(1);
            }
            if (score % 10 == 0 && score > 0)
            {
                spawner.increaseFrequency(200);
            }
            updateLabel();
        }
        public void removePoint()
        {
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

        public void updateLabel()
        {
            lScore.Text = "Score: " + score;
            lLifes.Text = "Lifes remaining: " + Lifes;
            lConsMisses.Text = "Consecutive misses: " + ConsecutiveMisses;
        }
        
        
    }
}
