namespace Fati_so_kofa
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tShapeMover = new System.Windows.Forms.Timer(this.components);
            this.tPlayerMover = new System.Windows.Forms.Timer(this.components);
            this.tShapeSpawner = new System.Windows.Forms.Timer(this.components);
            this.lScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tShapeMover
            // 
            this.tShapeMover.Interval = 20;
            this.tShapeMover.Tick += new System.EventHandler(this.tShapeMover_Tick);
            // 
            // tPlayerMover
            // 
            this.tPlayerMover.Interval = 20;
            this.tPlayerMover.Tick += new System.EventHandler(this.tPlayerMover_Tick);
            // 
            // tShapeSpawner
            // 
            this.tShapeSpawner.Interval = 3000;
            this.tShapeSpawner.Tick += new System.EventHandler(this.tShapeSpawner_Tick);
            // 
            // lScore
            // 
            this.lScore.AutoSize = true;
            this.lScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScore.Location = new System.Drawing.Point(262, 578);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(88, 24);
            this.lScore.TabIndex = 0;
            this.lScore.Text = "Score: 0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.lScore);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tShapeMover;
        private System.Windows.Forms.Timer tPlayerMover;
        private System.Windows.Forms.Timer tShapeSpawner;
        private System.Windows.Forms.Label lScore;
    }
}