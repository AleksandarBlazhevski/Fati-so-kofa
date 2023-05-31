using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fati_so_kofa
{
    public partial class GameOverForm : Form
    {
        public int score;
        public int highScore;

        public GameOverForm(int score, int highScore)
        {
            InitializeComponent();
            this.score = score;
            this.highScore = highScore;
            showScore();
        }

        private void showScore()
        {
            lTotalScore.Text = score.ToString();
            lHightScore.Text = highScore.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
