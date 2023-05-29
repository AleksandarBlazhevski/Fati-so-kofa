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
        
        private bool speedUp;

        private bool RespawnIncrease;


        public ScoreManager(Label lScore)
        {
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
            if(score != 0 && score % 5 == 0 )
            {
                speedUp = true;
            }
            if(score != 0 && score % 10 == 0)
            {
                RespawnIncrease = true;
            }

            updateLabel();
        }
        public void removePoint()
        {

            score--;
            updateLabel();
        }

        public void updateLabel()
        {
            lScore.Text = "Score: " + score;
        }
        
        public bool timeToSpeedUp()
        {
            if(speedUp)
            {
                speedUp = false;
                return true;
            }
            return false;
        }

        public bool timeToRespawnFaster()
        {
            if (RespawnIncrease)
            {
                RespawnIncrease = false;
                return true;
            }
            return false;
        }
    }
}
