using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animation
{
    public class ball
    {
        public int x = 50;
        public int y = 50;
        public int xspeed;
        public int yspeed;
        int width;
        int height;
        public Rectangle hitbox;

        public bool Update(Size ClientSize)
        {
            x += xspeed;
            y += yspeed;
            if (x + 50 > ClientSize.Width)
            {
                xspeed *= -1;
            }
            if (y + 50 > ClientSize.Height)
            {
                x = 10;
                y = 110;
                return true;
            }
            if (x < 0)
            {
                xspeed *= -1;
            }
            if (y < 0)
            {
                yspeed *= -1;
            }
            hitbox.X = x;
            hitbox.Y = y;

            System.Diagnostics.Debug.WriteLine("X: " + x);
            System.Diagnostics.Debug.WriteLine("Y: " + y);
            return false;
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Red, x, y, width, height);
        }

        public ball(int X, int Y, int Width, int Height, int Xspeed, int Yspeed)
        {
            x = X; y = Y; width = Width; height = Height; xspeed = Xspeed; yspeed = Yspeed;
            hitbox = new Rectangle(x, y, width, height);
        }
    }
}
