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
            SuspendLayout();
            // 
            // mainGameTimer
            // 
            mainGameTimer.Enabled = true;
            mainGameTimer.Interval = 17;
            mainGameTimer.Tick += mainGameTimer_Tick;
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainGameForm";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer mainGameTimer;
    }
}