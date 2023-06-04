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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lShapesSpawnRate = new System.Windows.Forms.Label();
            this.lShapeSpeed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lConsMisses = new System.Windows.Forms.Label();
            this.lLifes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbShapesSpeed = new System.Windows.Forms.ProgressBar();
            this.pbShapesSpawnRate = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbShapesSpawnRate);
            this.groupBox1.Controls.Add(this.pbShapesSpeed);
            this.groupBox1.Controls.Add(this.lShapesSpawnRate);
            this.groupBox1.Controls.Add(this.lShapeSpeed);
            this.groupBox1.Location = new System.Drawing.Point(403, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shapes info";
            // 
            // lShapesSpawnRate
            // 
            this.lShapesSpawnRate.AutoSize = true;
            this.lShapesSpawnRate.Location = new System.Drawing.Point(6, 86);
            this.lShapesSpawnRate.Name = "lShapesSpawnRate";
            this.lShapesSpawnRate.Size = new System.Drawing.Size(134, 13);
            this.lShapesSpawnRate.TabIndex = 3;
            this.lShapesSpawnRate.Text = "Shapes spawn every: 0 ms";
            // 
            // lShapeSpeed
            // 
            this.lShapeSpeed.AutoSize = true;
            this.lShapeSpeed.Location = new System.Drawing.Point(6, 26);
            this.lShapeSpeed.Name = "lShapeSpeed";
            this.lShapeSpeed.Size = new System.Drawing.Size(87, 13);
            this.lShapeSpeed.TabIndex = 2;
            this.lShapeSpeed.Text = "Shapes speed: 0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lConsMisses);
            this.groupBox2.Controls.Add(this.lLifes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(403, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 101);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Life and misses";
            // 
            // lConsMisses
            // 
            this.lConsMisses.AutoSize = true;
            this.lConsMisses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConsMisses.Location = new System.Drawing.Point(6, 64);
            this.lConsMisses.Name = "lConsMisses";
            this.lConsMisses.Size = new System.Drawing.Size(148, 17);
            this.lConsMisses.TabIndex = 3;
            this.lConsMisses.Text = "Consecutive misses: 0";
            // 
            // lLifes
            // 
            this.lLifes.AutoSize = true;
            this.lLifes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLifes.Location = new System.Drawing.Point(6, 37);
            this.lLifes.Name = "lLifes";
            this.lLifes.Size = new System.Drawing.Size(120, 17);
            this.lLifes.TabIndex = 2;
            this.lLifes.Text = "Lifes remaining: 3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Press \'v\' to change color";
            // 
            // pbShapesSpeed
            // 
            this.pbShapesSpeed.ForeColor = System.Drawing.Color.Yellow;
            this.pbShapesSpeed.Location = new System.Drawing.Point(6, 42);
            this.pbShapesSpeed.Name = "pbShapesSpeed";
            this.pbShapesSpeed.Size = new System.Drawing.Size(157, 16);
            this.pbShapesSpeed.TabIndex = 4;
            // 
            // pbShapesSpawnRate
            // 
            this.pbShapesSpawnRate.ForeColor = System.Drawing.Color.Fuchsia;
            this.pbShapesSpawnRate.Location = new System.Drawing.Point(6, 102);
            this.pbShapesSpawnRate.Name = "pbShapesSpawnRate";
            this.pbShapesSpawnRate.Size = new System.Drawing.Size(157, 16);
            this.pbShapesSpawnRate.TabIndex = 5;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lScore);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tShapeMover;
        private System.Windows.Forms.Timer tPlayerMover;
        private System.Windows.Forms.Timer tShapeSpawner;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lShapesSpawnRate;
        private System.Windows.Forms.Label lShapeSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lConsMisses;
        private System.Windows.Forms.Label lLifes;
        private System.Windows.Forms.ProgressBar pbShapesSpawnRate;
        private System.Windows.Forms.ProgressBar pbShapesSpeed;
        private System.Windows.Forms.Label label1;
    }
}