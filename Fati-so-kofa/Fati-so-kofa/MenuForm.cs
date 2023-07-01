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

namespace Fati_so_kofa
{
<<<<<<< HEAD
=======
<<<<<<< HEAD
    /// <summary>
    /// Menu form responsible for displaying high scores and to start the game
    /// </summary>
=======
>>>>>>> d242a9540e760fbd9bccf6a67c5f4ddfb6253c9a
>>>>>>> 93158a0 (Finished documentation)
    public partial class MenuForm : Form
    {
        /// <summary>
        /// ListView component used to display the scores
        /// </summary>
        private ListView lvScore;
        /// <summary>
        /// List of integers used to store the scores
        /// </summary>
        private List<int> scoreList;
        public MenuForm()
        {
            InitializeComponent();
            lvScore = lvScores;
            scoreList = new List<int>();
        }
        /// <summary>
        /// Click event which opens the game form and sends it the highest score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(scoreList.Count == 0 ? -1 : scoreList.Max());
            this.Hide();
            DialogResult = gameForm.ShowDialog();
            int lastScore = gameForm.getData();
            scoreList.Add(lastScore);
            loadScores();
            if(!this.IsDisposed)
            {
                this.Show();
            }
                
        }
        /// <summary>
        /// Sorts and loads the scores in ListView for displaying
        /// </summary>
        private void loadScores()
        {
            lvScore.Items.Clear();
            scoreList.Sort();
            scoreList.Reverse();
            for(int i = 0; i<scoreList.Count; i++)
            {
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(scoreList[i].ToString());
                lvScore.Items.Add(item);
            }
        }
    }
}
