using SurvivalShooterGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurvivalShooterGame.Forms.MainGameForm;

namespace SurvivalShooterGame.Managers
{
    public class GameManager
    {
        private const int WINDOW_WIDTH = 300 * 4;
        private const int WINDOW_HEIGHT = 300 * 3;
        private const float ENEMY_SPAWN_INTERVAL = 2f;

        public Player Player { get; private set; }
        public int Score { get; private set; }
        public float GameTime { get; private set; }
        public bool IsGameOver { get; private set; }

        private float _enemySpawnTime = 0f;

        public GameManager()
        {
            Player = new Player();
            Score = 0;
            GameTime = 0f;
            IsGameOver = false;
        }

        public void Initialize(Control parentControl)
        {
            Point startPosition = new Point(
                WINDOW_WIDTH / 2 - Player.Picture.Width / 2,
                WINDOW_HEIGHT / 2 + 50
            );

            Player.Draw(parentControl, startPosition);
        }

        public void Update(Control parentControl, float deltaTime)
        {
            if (IsGameOver) return;

            Player.Update(parentControl);

            GameTime += deltaTime;
            _enemySpawnTime += deltaTime;

            if (_enemySpawnTime >= ENEMY_SPAWN_INTERVAL)
            {
                _enemySpawnTime = 0f;
                // TODO: Spawn enemy
            }
        }

        public string GetFormattedTime()
        {
            int minutes = (int)(GameTime / 60);
            int seconds = (int)(GameTime % 60);
            return $"{minutes:D2}:{seconds:D2}";
        }

        public void HandlePlayerMovement(Direction? direction, bool isMoving)
        {
            if (direction.HasValue)
            {
                Player.Direction = direction.Value;
            }
            Player.IsMoving = isMoving;
        }

        public void AddScore(int points)
        {
            Score += points;
        }

        public void GameOver()
        {
            IsGameOver = true;
        }

        public void Reset()
        {
            Score = 0;
            GameTime = 0f;
            IsGameOver = false;
            _enemySpawnTime = 0f;
            Player = new Player();
        }
    }
}
