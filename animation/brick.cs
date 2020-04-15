using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animation
{
    public class brick
    {
        int x = 50;
        public int y = 50;
        int width;
        int height;
        public Rectangle hitbox;
        public Rectangle hitboxleft;
        public Rectangle hitboxright;
        public Rectangle hitboxtop;

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Yellow, x, y, width, height);
            //Drawing hitboxes
            gfx.FillRectangle(Brushes.Red, hitbox);
            gfx.FillRectangle(Brushes.Red, hitboxleft);
            gfx.FillRectangle(Brushes.Red, hitboxright);
            gfx.FillRectangle(Brushes.Red, hitboxtop);
        }

        public void Update()
        {
            hitbox.X = x;
            hitbox.Y = y;
            hitboxleft.X = x;
            hitboxleft.Y = y;
            hitboxright.X = x;
            hitboxright.Y = y;
            hitboxtop.X = x;
            hitboxtop.Y = y;
        }

        public brick(int X, int Y, int Width, int Height)
        {
            x = X; y = Y; width = Width; height = Height;
            hitbox = new Rectangle(x, y + height, width, 1);
            hitboxleft = new Rectangle(x, y, 1, height);
            hitboxright = new Rectangle(x + width, y, 1, height);
            hitboxtop = new Rectangle(x, y, width, 1);
        }
    }

}
