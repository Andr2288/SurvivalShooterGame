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

        public int _health { get; private set; } 
        public int _speed { get; private set; } 
        public bool isDead { get; private set; }
        public Direction Direction { get; set; }
        public bool IsMoving { get; set; }

        public Player()
        {
            _health = 100;
            _speed = 10;
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
                X -= _speed;
            }

            if (Direction == Direction.Right && Picture.Left + Picture.Width < parentControl.Width)
            {
                Picture.Image = Properties.Resources.right;
                X += _speed;
            }

            if (Direction == Direction.Up && Picture.Top > 0)
            {
                Picture.Image = Properties.Resources.up;
                Y -= _speed;
            }

            if (Direction == Direction.Down && Picture.Top + Picture.Height < parentControl.Height)
            {
                Picture.Image = Properties.Resources.down;
                Y += _speed;
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
    }
}
