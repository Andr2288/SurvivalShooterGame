using SurvivalShooterGame.Models;
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
    public partial class MainGameForm : Form
    {
        private const int WINDOW_WIDTH = 800;
        private const int WINDOW_HEIGHT = 600;

        private readonly Color WINDOW_COLOR = Color.FromArgb(64, 64, 64);

        private enum GameState
        {
            Menu,
            Playing,
            GameOver
        }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        private GameState _currentState = GameState.Menu;

        private int _score = 0;
        private float _gameTime = 0f;
        private float _enemySpawnTimer = 0f;
        private const float ENEMY_SPAWN_INTERVAL = 2f;

        private Player player;

        public MainGameForm()
        {
            InitializeComponent();

            this.Width = WINDOW_WIDTH;
            this.Height = WINDOW_HEIGHT;

            this.BackColor = WINDOW_COLOR;

            player = new Player();
        }

        private void MainUpdate()
        {
            player.Update(this);
        }

        public void MainDraw()
        {
            player.Draw(this, new Point(0, 0));
        }

        private void mainGameTimer_Tick(object sender, EventArgs e)
        {
            MainUpdate();
        }
    }
}
