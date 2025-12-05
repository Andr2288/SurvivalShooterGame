using SurvivalShooterGame.Managers;
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
        private GameManager _gameManager;

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

            _gameManager = new GameManager();
            _gameManager.Initialize(this);
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
            Direction? direction = null;
            bool isMoving = false;

            if (_moveLeft)
            {
                direction = Direction.Left;
                isMoving = true;
            }
            else if (_moveRight)
            {
                direction = Direction.Right;
                isMoving = true;
            }
            else if (_moveUp)
            {
                direction = Direction.Up;
                isMoving = true;
            }
            else if (_moveDown)
            {
                direction = Direction.Down;
                isMoving = true;
            }

            _gameManager.HandlePlayerMovement(direction, isMoving);

            float deltaTime = 0.017f;
            _gameManager.Update(this, deltaTime);

            UpdateHUD();

            // Перевірка Game Over
            if (_gameManager.IsGameOver)
            {
                ShowGameOverScreen();
            }

            this.Invalidate();
        }

        private void ShowGameOverScreen()
        {
            mainGameTimer.Stop();

            GameOverForm gameOverForm = new GameOverForm(_gameManager.Score, _gameManager.GetFormattedTime());
            gameOverForm.ShowDialog(this);

            if (gameOverForm.ShouldRestart)
            {
                RestartGame();
            }
            else if (gameOverForm.ShouldExit)
            {
                this.Close();
            }
        }

        private void RestartGame()
        {
            // Скидаємо прапорці руху
            _moveLeft = false;
            _moveRight = false;
            _moveUp = false;
            _moveDown = false;

            _gameManager.ClearForm(this);
            _gameManager.Reset();
            _gameManager.Initialize(this);
            mainGameTimer.Start();
        }

        private void UpdateHUD()
        {
            hpLabel.Text = $"HP: {_gameManager.Player.Health}";
            scoreLabel.Text = $"Score: {_gameManager.Score}";
            timeLabel.Text = $"Time: {_gameManager.GetFormattedTime()}";
        }   

        private void mainGameTimer_Tick(object sender, EventArgs e)
        {
            MainUpdate();
        }

        private void MainGameForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _gameManager.Shoot(e.Location);
            }
        }
    }
}