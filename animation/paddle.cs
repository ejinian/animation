using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animation
{
    public class paddle
    {
        public int x = 100;
        int y = 240;
        int xspeed;
        int width;
        int height;
        public Rectangle hitbox;
        public Rectangle paddlehitboxleft;
        public Rectangle paddlehitboxright;

        public paddle(int X, int Y, int Xspeed, int Width, int Height)
        {
            x = X; y = Y; xspeed = Xspeed; width = Width; height = Height;
            hitbox = new Rectangle(x, y + height, width, 1);
            paddlehitboxleft = new Rectangle(x, y, 1, height);
            paddlehitboxright = new Rectangle(x + width, y, 1, height);
        }

        public void Update()
        {
            hitbox.X = x;
            hitbox.Y = y;
            paddlehitboxleft.X = x;
            paddlehitboxleft.Y = y;
            paddlehitboxright.X = x;
            paddlehitboxright.Y = y;
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Blue, x, y, width, height);
            //Drawing hitboxes
            gfx.FillRectangle(Brushes.Red, hitbox);
            gfx.FillRectangle(Brushes.Red, paddlehitboxleft);
            gfx.FillRectangle(Brushes.Red, paddlehitboxright);
        }
    }
}
