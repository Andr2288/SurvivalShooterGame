using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurvivalShooterGame.Forms
{
    public partial class GameOverForm : Form
    {
        public bool ShouldRestart { get; private set; }
        public bool ShouldExit { get; private set; }

        public GameOverForm(int score, string gameTime)
        {
            InitializeComponent();

            // Налаштування форми
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(40, 40, 40);

            // Відображення результатів
            scoreLabel.Text = $"Score: {score}";
            timeLabel.Text = $"Time: {gameTime}";

            ShouldRestart = false;
            ShouldExit = false;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            ShouldRestart = true;
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ShouldExit = true;
            this.Close();
        }

        private void GameOverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R || e.KeyCode == Keys.Enter)
            {
                restartButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                exitButton_Click(sender, e);
            }
        }
    }
}
