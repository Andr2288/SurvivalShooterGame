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
        private const int WINDOW_WIDTH = 300 * 4;
        private const int WINDOW_HEIGHT = 300 * 3;

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

        private bool _moveLeft = false;
        private bool _moveRight = false;
        private bool _moveUp = false;
        private bool _moveDown = false;

        public MainGameForm()
        {
            InitializeComponent();

            this.Width = WINDOW_WIDTH;
            this.Height = WINDOW_HEIGHT;

            this.BackColor = WINDOW_COLOR;

            player = new Player();
        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                _moveLeft = true;

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                _moveRight = true;

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                _moveUp = true;

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                _moveDown = true;
        }

        private void MainGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                _moveLeft = false;

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                _moveRight = false;

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                _moveUp = false;

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                _moveDown = false;
        }

        private void MainUpdate()
        {
            if (_moveLeft)
            {
                player.Direction = Direction.Left;
                player.IsMoving = true;
            }
            else if (_moveRight)
            {
                player.Direction = Direction.Right;
                player.IsMoving = true;
            }
            else if (_moveUp)
            {
                player.Direction = Direction.Up;
                player.IsMoving = true;
            }
            else if (_moveDown)
            {
                player.Direction = Direction.Down;
                player.IsMoving = true;
            }
            else
            {
                player.IsMoving = false;
            }

            player.Update(this);
            this.Invalidate();
        }

        public void MainDraw()
        {
            player.Draw(this, new Point(WINDOW_WIDTH / 2 - player.Picture.Width / 2, WINDOW_HEIGHT / 2 + 50));
        }

        private void mainGameTimer_Tick(object sender, EventArgs e)
        {
            MainUpdate();
            MainDraw();
        }
    }
}