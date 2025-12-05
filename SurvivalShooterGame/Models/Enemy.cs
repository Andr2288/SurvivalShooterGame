using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalShooterGame.Models
{
    public class Enemy
    {
        public PictureBox Picture { get; private set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        public bool IsActive { get; set; }
        public EnemyType Type { get; private set; }

        public enum EnemyType
        {
            Slow,   // повільний ворог
            Fast    // швидкий ворог
        }

        public Enemy(Point spawnPosition, EnemyType type = EnemyType.Slow)
        {
            X = spawnPosition.X;
            Y = spawnPosition.Y;
            Type = type;
            IsActive = true;

            // Налаштування параметрів залежно від типу
            switch (type)
            {
                case EnemyType.Slow:
                    Health = 1;
                    Speed = 2f;
                    Damage = 10;
                    break;
                case EnemyType.Fast:
                    Health = 1;
                    Speed = 4f;
                    Damage = 15;
                    break;
            }

            // Створення візуального представлення зі спрайтами
            Picture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.AutoSize,
                Image = Properties.Resources.zdown, // початковий спрайт
                Location = new Point((int)X, (int)Y)
            };
        }

        public void Update(Point playerPosition)
        {
            if (!IsActive) return;

            // Розрахунок напрямку до гравця
            float deltaX = playerPosition.X - X;
            float deltaY = playerPosition.Y - Y;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance > 0)
            {
                // Нормалізація вектору і рух до гравця
                float directionX = deltaX / distance;
                float directionY = deltaY / distance;

                X += directionX * Speed;
                Y += directionY * Speed;

                // Зміна спрайту залежно від напрямку руху
                UpdateSprite(directionX, directionY);

                Picture.Location = new Point((int)X, (int)Y);
            }
        }

        private void UpdateSprite(float directionX, float directionY)
        {
            Image spriteToUse;

            // Визначаємо основний напрямок руху
            if (Math.Abs(directionX) > Math.Abs(directionY))
            {
                // Горизонтальний рух
                spriteToUse = directionX > 0 ?
                    Properties.Resources.zright :
                    Properties.Resources.zleft;
            }
            else
            {
                // Вертикальний рух
                spriteToUse = directionY > 0 ?
                    Properties.Resources.zdown :
                    Properties.Resources.zup;
            }

            Picture.Image = spriteToUse;

            // Швидкі вороги можуть мати інший відтінок
            if (Type == EnemyType.Fast)
            {
                Picture.BackColor = Color.FromArgb(100, Color.Red); // червоний відтінок для швидких
            }
            else
            {
                Picture.BackColor = Color.Transparent;
            }
        }

        public void Draw(Control parentControl)
        {
            if (!parentControl.Controls.Contains(Picture))
            {
                parentControl.Controls.Add(Picture);
            }
        }

        public void Remove(Control parentControl)
        {
            if (parentControl.Controls.Contains(Picture))
            {
                parentControl.Controls.Remove(Picture);
            }
            IsActive = false;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                IsActive = false;
            }
        }

        public bool IsCollidingWith(Rectangle other)
        {
            Rectangle enemyBounds = new Rectangle((int)X, (int)Y, Picture.Width, Picture.Height);
            return enemyBounds.IntersectsWith(other);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, Picture.Width, Picture.Height);
        }
    }
}
