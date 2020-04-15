using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap image;
        public int score;
        paddle paddle1;
        ball ball1;
        public List<brick> bricks = new List<brick>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            image = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(image);
            paddle1 = new paddle(230, 340, 20, 90, 10);
            ball1 = new ball(100, 140, 50, 50, 5, 5);
            int x = 0;
            for (int row = 0; row < 3; row++)
            {
                x = 0;
                for (int i = 0; i < 18; i++)
                {
                    bricks.Add(new brick(x, row * 35 + 10, 30, 30));
                    x += 33;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            paddle1.Update();

            if (paddle1.hitbox.IntersectsWith(ball1.hitbox))
            {
                ball1.yspeed = Math.Abs(ball1.yspeed) * -1;
                //System.Media.SoundPlayer begin = new System.Media.SoundPlayer(@"C:/\Users\Ernest\Music\spaghetti.wav");
                //begin.Play();
            }

            if(ball1.hitbox.IntersectsWith(paddle1.paddlehitboxleft))
            {
                ball1.yspeed *= -1;
            }

            if(ball1.hitbox.IntersectsWith(paddle1.paddlehitboxright))
            {
                ball1.yspeed = Math.Abs(ball1.yspeed) * -1;
            }

            if (ball1.hitbox.IntersectsWith(paddle1.hitbox))
            {
                score += 5938475;
                label1.Text = string.Format("Score: {0}", score);
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                var brick = bricks[i];
                bool isDead = false;

                if (ball1.hitbox.IntersectsWith(brick.hitbox))
                {
                    ball1.yspeed = ball1.yspeed * -1;
                    isDead = true;
                }

                else if (ball1.hitbox.IntersectsWith(brick.hitboxtop))
                {
                    ball1.yspeed = ball1.yspeed * -1;
                    isDead = true;
                }

                if (ball1.hitbox.IntersectsWith(brick.hitboxleft))
                {
                    ball1.xspeed = ball1.xspeed * -1;
                    isDead = true;
                }

                else if (ball1.hitbox.IntersectsWith(brick.hitboxright))
                {
                    ball1.xspeed = ball1.xspeed * -1;
                    isDead = true;
                }

                if (isDead)
                {
                    bricks.Remove(brick);
                    i--;
                    score += 19867206;
                    label1.Text = string.Format("Score: {0}", score);
                }
                if(bricks.Count == 0)
                {
                    //All bricks have been hit
                    //Close();
                    timer2.Start();
                    label2.Text = "You win";
                }
            }

            if (ball1.Update(ClientSize) == true)
            {
                deathLabel.Text = "you lose";
                pictureBox1.SendToBack();
                deadTimer.Enabled = true;
                score -= score/2;
                label1.Text = string.Format("Score: {0}", score);
            }

            ball1.Draw(gfx);
            paddle1.Draw(gfx);
            foreach (var brick in bricks)
            {
                brick.Draw(gfx);
            }

            paddle1.x += paddleMoveSpeed;

            //Clamp paddle.x not to exceed screen size
            paddle1.x = clamp(paddle1.x, 0, ClientSize.Width - paddle1.hitbox.Width);
            pictureBox1.Image = image;
        }

        private int clamp(int testValue, int min, int max)
        {
            if(testValue > max)
            {
                return max;
            }
            else if(testValue < min)
            {
                return min;
            }
            return testValue;
        }

        int paddleMoveSpeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys pressed = e.KeyCode;
            if (pressed == Keys.W)
            {
                paddleMoveSpeed = 3;
            }
            else if (pressed == Keys.S)
            {
                paddleMoveSpeed = -3;
            }
            else if (pressed == Keys.D)
            {
                paddleMoveSpeed = 8;
            }
            else if (pressed == Keys.A)
            {
                paddleMoveSpeed = -8;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            paddleMoveSpeed = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Hide();
            titlescreen form = new titlescreen();
            form.ShowDialog();
            Close();
        }

        private void deadTimer_Tick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
