using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalShooterGame.Models
{
    namespace SurvivalShooterGame.Models
    {
        public class Bullet
        {
            public PictureBox Picture { get; private set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float DirectionX { get; private set; }
            public float DirectionY { get; private set; }
            public float Speed { get; private set; }
            public bool IsActive { get; set; }

            public Bullet(Point startPosition, Point targetPosition)
            {
                X = startPosition.X;
                Y = startPosition.Y;
                Speed = 15f;
                IsActive = true;

                // Розрахунок напрямку руху до цільової точки
                float deltaX = targetPosition.X - startPosition.X;
                float deltaY = targetPosition.Y - startPosition.Y;
                float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                if (distance > 0)
                {
                    DirectionX = deltaX / distance;
                    DirectionY = deltaY / distance;
                }

                // Створення візуального представлення кулі
                Picture = new PictureBox
                {
                    Width = 8,
                    Height = 8,
                    BackColor = Color.Yellow,
                    Location = new Point((int)X, (int)Y)
                };
            }

            public void Update()
            {
                if (!IsActive) return;

                X += DirectionX * Speed;
                Y += DirectionY * Speed;
                Picture.Location = new Point((int)X, (int)Y);
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

            public bool IsOutOfBounds(int windowWidth, int windowHeight)
            {
                return X < 0 || X > windowWidth || Y < 0 || Y > windowHeight;
            }
        }
    }
}
