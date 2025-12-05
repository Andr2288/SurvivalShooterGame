namespace SurvivalShooterGame.Forms
{
    partial class GameOverForm
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
            scoreLabel = new Label();
            gameOverLabel = new Label();
            timeLabel = new Label();
            restartButton = new Button();
            exitButton = new Button();
            instructionLabel = new Label();
            SuspendLayout();
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreLabel.ForeColor = Color.WhiteSmoke;
            scoreLabel.Location = new Point(330, 159);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(129, 41);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Score: 0";
            // 
            // gameOverLabel
            // 
            gameOverLabel.AutoSize = true;
            gameOverLabel.Font = new Font("Calibri", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gameOverLabel.ForeColor = Color.Crimson;
            gameOverLabel.Location = new Point(223, 48);
            gameOverLabel.Name = "gameOverLabel";
            gameOverLabel.Size = new Size(339, 73);
            gameOverLabel.TabIndex = 1;
            gameOverLabel.Text = "GAME OVER";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeLabel.ForeColor = Color.WhiteSmoke;
            timeLabel.Location = new Point(309, 231);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(182, 41);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "Time: 00:00";
            // 
            // restartButton
            // 
            restartButton.BackColor = Color.ForestGreen;
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            restartButton.ForeColor = Color.White;
            restartButton.Location = new Point(223, 304);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(150, 50);
            restartButton.TabIndex = 3;
            restartButton.Text = "Restart (R)";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += restartButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Firebrick;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(412, 304);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(150, 50);
            exitButton.TabIndex = 4;
            exitButton.Text = "Exit (ESC)";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // instructionLabel
            // 
            instructionLabel.AutoSize = true;
            instructionLabel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            instructionLabel.ForeColor = Color.LightGray;
            instructionLabel.Location = new Point(263, 380);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Size = new Size(270, 24);
            instructionLabel.TabIndex = 5;
            instructionLabel.Text = "Press R to restart or ESC to exit";
            instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameOverForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 483);
            Controls.Add(instructionLabel);
            Controls.Add(exitButton);
            Controls.Add(restartButton);
            Controls.Add(timeLabel);
            Controls.Add(gameOverLabel);
            Controls.Add(scoreLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameOverForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameOverForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreLabel;
        private Label gameOverLabel;
        private Label timeLabel;
        private Button restartButton;
        private Button exitButton;
        private Label instructionLabel;
    }
}