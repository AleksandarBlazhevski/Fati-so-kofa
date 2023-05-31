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
    public partial class Form1 : Form
    {
        private ListView lvScore;
        private List<int> scoreList;
        public Form1()
        {
            InitializeComponent();
            lvScore = lvScores;
            scoreList = new List<int>();
        }

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
