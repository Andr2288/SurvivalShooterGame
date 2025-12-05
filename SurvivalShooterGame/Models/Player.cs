using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SurvivalShooterGame.Forms.MainGameForm;

namespace SurvivalShooterGame.Models
{
    public class Player
    {
        public PictureBox Picture { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Health { get; private set; }
        public int Speed { get; private set; }
        public bool IsDead { get; private set; }
        public Direction Direction { get; set; }
        public bool IsMoving { get; set; }

        public Player()
        {
            Health = 100;
            Speed = 10;
            IsMoving = false;

            Picture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.AutoSize,
                Image = Properties.Resources.up
            };

            Direction = Direction.Up;
        }

        public void Update(Control parentControl)
        {
            if (!IsMoving) return;

            if (Direction == Direction.Left && Picture.Left > 0)
            {
                Picture.Image = Properties.Resources.left;
                X -= Speed;
            }

            if (Direction == Direction.Right && Picture.Left + Picture.Width < parentControl.Width)
            {
                Picture.Image = Properties.Resources.right;
                X += Speed;
            }

            if (Direction == Direction.Up && Picture.Top > 100)
            {
                Picture.Image = Properties.Resources.up;
                Y -= Speed;
            }

            if (Direction == Direction.Down && Picture.Top + Picture.Height < parentControl.Height)
            {
                Picture.Image = Properties.Resources.down;
                Y += Speed;
            }

            Picture.Location = new Point(X, Y);
        }

        public void Draw(Control control, Point position)
        {
            if (!control.Controls.Contains(Picture))
            {
                X = position.X;
                Y = position.Y;
                Picture.Location = new Point(X, Y);
                control.Controls.Add(Picture);
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                IsDead = true;
                Picture.Image = Properties.Resources.dead;
            }
        }

        public void Heal(int amount)
        {
            if (IsDead) return;

            Health += amount;
            if (Health > 100)
            {
                Health = 100;
            }
        }
    }
}
