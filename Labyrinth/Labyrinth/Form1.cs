using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] map1;

        private void Form1_Load(object sender, EventArgs e)
        {
            map1 = new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                   pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                                   pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                                   pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20,
                                   pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25,
                                   pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
                                   pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35,
                                   pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40,
                                   pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45,
                                   pictureBox46 };

            for (int i = 0; i < map1.Length; i++)
            {
                map1[i].BackColor = Color.Black;
                map1[i].Visible = true;
                map1[i].Enabled = true;
            }
        }

        private bool checkCollision()
        {
            for (int i = 0; i < map1.Length; i++)
                if (player.Bounds.IntersectsWith(map1[i].Bounds))
                    return true;
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.Left -= 5;
                if (checkCollision())
                    player.Left += 5;
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.Left += 5;
                if (checkCollision())
                    player.Left -= 5;
            }
            else if (e.KeyCode == Keys.Up)
            {
                player.Top -= 5;
                if (checkCollision())
                    player.Top += 5;
            }
            else if (e.KeyCode == Keys.Down)
            {
                player.Top += 5;
                if (checkCollision())
                    player.Top -= 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(finish.Bounds))
            {
                timer1.Enabled = false;
                MessageBox.Show("You Win!");
                this.Close();
            }
        }
    }
}
