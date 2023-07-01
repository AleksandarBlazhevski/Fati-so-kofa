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
    /// <summary>
    /// Game over form responsible for showing the highest score and the score the current player achived
    /// </summary>
    public partial class GameOverForm : Form
    {
        /// <summary>
        /// Current player score
        /// </summary>
        public int score;
        /// <summary>
        /// Highest score achived
        /// </summary>
        public int highScore;

        public GameOverForm(int score, int highScore)
        {
            InitializeComponent();
            this.score = score;
            this.highScore = highScore;
            showScore();
        }
        /// <summary>
        /// Shows the scores in their specific label
        /// </summary>
        private void showScore()
        {
            lTotalScore.Text = score.ToString();
            lHightScore.Text = highScore.ToString();
        }
        /// <summary>
        /// Closes the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Sends the player to the menu form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
