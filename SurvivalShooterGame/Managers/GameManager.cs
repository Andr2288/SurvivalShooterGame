using SurvivalShooterGame.Models;
using SurvivalShooterGame.Models.SurvivalShooterGame.Models;
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
        private const int HUD_HEIGHT = 100;

        public Player Player { get; private set; }
        public List<Bullet> Bullets { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public int Score { get; private set; }
        public float GameTime { get; private set; }
        public bool IsGameOver { get; private set; }

        private float _enemySpawnTime = 0f;
        private Random _random;

        public GameManager()
        {
            Player = new Player();
            Bullets = new List<Bullet>();
            Enemies = new List<Enemy>();
            Score = 0;
            GameTime = 0f;
            IsGameOver = false;
            _random = new Random();
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
            UpdateBullets(parentControl);
            UpdateEnemies(parentControl);
            CheckCollisions(parentControl);

            GameTime += deltaTime;
            _enemySpawnTime += deltaTime;

            // Спавн ворогів
            if (_enemySpawnTime >= ENEMY_SPAWN_INTERVAL)
            {
                _enemySpawnTime = 0f;
                SpawnEnemy(parentControl);
            }

            // Перевірка Game Over
            if (Player.IsDead)
            {
                GameOver();
            }
        }

        public void Shoot(Point targetPosition)
        {
            if (IsGameOver) return;

            Point playerCenter = new Point(
                Player.X + Player.Picture.Width / 2,
                Player.Y + Player.Picture.Height / 2
            );

            Bullet bullet = new Bullet(playerCenter, targetPosition);
            Bullets.Add(bullet);
        }

        private void SpawnEnemy(Control parentControl)
        {
            Point spawnPosition = GetRandomSpawnPosition();

            // 70% шанс повільного ворога, 30% швидкого
            Enemy.EnemyType type = _random.NextDouble() < 0.7 ?
                Enemy.EnemyType.Slow : Enemy.EnemyType.Fast;

            Enemy enemy = new Enemy(spawnPosition, type);
            Enemies.Add(enemy);
        }

        private Point GetRandomSpawnPosition()
        {
            int side = _random.Next(4); // 0-3 сторони екрану
            Point position;

            switch (side)
            {
                case 0: // Зверху
                    position = new Point(_random.Next(0, WINDOW_WIDTH), 0);
                    break;
                case 1: // Справа
                    position = new Point(WINDOW_WIDTH, _random.Next(HUD_HEIGHT, WINDOW_HEIGHT));
                    break;
                case 2: // Знизу
                    position = new Point(_random.Next(0, WINDOW_WIDTH), WINDOW_HEIGHT);
                    break;
                case 3: // Зліва
                    position = new Point(0, _random.Next(HUD_HEIGHT, WINDOW_HEIGHT));
                    break;
                default:
                    position = new Point(0, HUD_HEIGHT);
                    break;
            }

            return position;
        }

        private void UpdateBullets(Control parentControl)
        {
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = Bullets[i];

                if (!bullet.IsActive)
                {
                    bullet.Remove(parentControl);
                    Bullets.RemoveAt(i);
                    continue;
                }

                bullet.Draw(parentControl);
                bullet.Update();

                // Перевіряємо чи куля за межами екрану
                if (bullet.IsOutOfBounds(WINDOW_WIDTH, WINDOW_HEIGHT))
                {
                    bullet.Remove(parentControl);
                    Bullets.RemoveAt(i);
                }
            }
        }

        private void UpdateEnemies(Control parentControl)
        {
            Point playerCenter = new Point(
                Player.X + Player.Picture.Width / 2,
                Player.Y + Player.Picture.Height / 2
            );

            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemy enemy = Enemies[i];

                if (!enemy.IsActive)
                {
                    enemy.Remove(parentControl);
                    Enemies.RemoveAt(i);
                    continue;
                }

                enemy.Draw(parentControl);
                enemy.Update(playerCenter);
            }
        }

        private void CheckCollisions(Control parentControl)
        {
            Rectangle playerBounds = new Rectangle(Player.X, Player.Y,
                Player.Picture.Width, Player.Picture.Height);

            // Колізії куль з ворогами
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = Bullets[i];
                Rectangle bulletBounds = new Rectangle((int)bullet.X, (int)bullet.Y,
                    bullet.Picture.Width, bullet.Picture.Height);

                for (int j = Enemies.Count - 1; j >= 0; j--)
                {
                    Enemy enemy = Enemies[j];

                    if (enemy.IsCollidingWith(bulletBounds))
                    {
                        // Знищуємо ворога і кулю
                        enemy.TakeDamage(1);
                        bullet.Remove(parentControl);
                        Bullets.RemoveAt(i);

                        if (!enemy.IsActive)
                        {
                            enemy.Remove(parentControl);
                            Enemies.RemoveAt(j);
                            AddScore(10); // 10 очок за ворога
                        }

                        break;
                    }
                }
            }

            // Колізії ворогів з гравцем
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemy enemy = Enemies[i];

                if (enemy.IsCollidingWith(playerBounds))
                {
                    Player.TakeDamage(enemy.Damage);
                    enemy.Remove(parentControl);
                    Enemies.RemoveAt(i);
                }
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

            // Очищуємо кулі
            foreach (var bullet in Bullets)
            {
                bullet.IsActive = false;
            }
            Bullets.Clear();

            // Очищуємо ворогів
            foreach (var enemy in Enemies)
            {
                enemy.IsActive = false;
            }
            Enemies.Clear();
        }
    }
}
