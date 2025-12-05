namespace SurvivalShooterGame.Forms
{
    partial class MainGameForm
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
            components = new System.ComponentModel.Container();
            mainGameTimer = new System.Windows.Forms.Timer(components);
            hudPanel = new Panel();
            timeLabel = new Label();
            scoreLabel = new Label();
            hpLabel = new Label();
            hudPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainGameTimer
            // 
            mainGameTimer.Enabled = true;
            mainGameTimer.Interval = 17;
            mainGameTimer.Tick += mainGameTimer_Tick;
            // 
            // hudPanel
            // 
            hudPanel.BackColor = Color.SteelBlue;
            hudPanel.Controls.Add(timeLabel);
            hudPanel.Controls.Add(scoreLabel);
            hudPanel.Controls.Add(hpLabel);
            hudPanel.Dock = DockStyle.Top;
            hudPanel.Location = new Point(0, 0);
            hudPanel.Name = "hudPanel";
            hudPanel.Padding = new Padding(10, 25, 10, 25);
            hudPanel.Size = new Size(1182, 99);
            hudPanel.TabIndex = 0;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeLabel.ForeColor = Color.WhiteSmoke;
            timeLabel.Location = new Point(970, 33);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(97, 41);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "Time:";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreLabel.ForeColor = Color.WhiteSmoke;
            scoreLabel.Location = new Point(537, 33);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(129, 41);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "Score: 0";
            // 
            // hpLabel
            // 
            hpLabel.AutoSize = true;
            hpLabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            hpLabel.ForeColor = Color.WhiteSmoke;
            hpLabel.Location = new Point(34, 33);
            hpLabel.Name = "hpLabel";
            hpLabel.Size = new Size(91, 41);
            hpLabel.TabIndex = 0;
            hpLabel.Text = "HP: 0";
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 539);
            Controls.Add(hudPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainGameForm";
            KeyDown += MainGameForm_KeyDown;
            KeyUp += MainGameForm_KeyUp;
            MouseClick += MainGameForm_MouseClick;
            hudPanel.ResumeLayout(false);
            hudPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer mainGameTimer;
        private Panel hudPanel;
        private Label hpLabel;
        private Label timeLabel;
        private Label scoreLabel;
    }
}