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
        public List<int> previousScores;
        public int topScore;
        private Label lScore;
        private Spawner spawner;
        private bool speedUp;

        private bool RespawnIncrease;


        public ScoreManager(Label lScore, Spawner spawner)
        {
            this.spawner = spawner;
            this.lScore = lScore;
            previousScores = new List<int> ();
            topScore = 0;
            score = 0;


            speedUp = false;


            RespawnIncrease = false;
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
            updateLabel();
        }

        public void updateLabel()
        {
            lScore.Text = "Score: " + score;
        }
        
        
    }
}
