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
    public partial class titlescreen : Form
    {
        Random gen = new Random();
        Color[] colors = { Color.Red, Color.Blue, Color.Lime, Color.Gold };
        public titlescreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void titlescreen_Shown(object sender, EventArgs e)
        {
            this.FindForm().BackColor = colors[gen.Next(0, colors.Length)];
        }
    }
}
