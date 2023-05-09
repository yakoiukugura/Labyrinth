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

        // Declaram un array de PictureBox-uri pentru harta labirintului
        PictureBox[] map1;
        // Setam calea catre folderul cu resursele imaginilor
        string PATH = @"C:\Users\TheBoss\OneDrive\Desktop\Labyrinth\Labyrinth\Resources";


        // În functia Form1_Load se inițializează obiectele PictureBox și se setează anumite proprietăți ale lor.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Aici se pot adauga harti:
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
            /*
            map2 = new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                   pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                                   pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                                   pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20,
                                   pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25,
                                   pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
                                   pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35,
                                   pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40,
                                   pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45,
                                   pictureBox46 };

            map3 = new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                   pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                                   pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                                   pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20,
                                   pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25,
                                   pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
                                   pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35,
                                   pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40,
                                   pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45,
                                   pictureBox46 };
            */

            // Setam background-ul pentru fiecare PictureBox la negru si le facem vizibile si activate
            for (int i = 0; i < map1.Length; i++)
            {
                map1[i].BackColor = Color.Black;
                map1[i].Visible = true;
                map1[i].Enabled = true;
            }
        }

        //   Functia checkCollision verifică dacă obiectul player a intrat în coliziune cu pereții labirintului sau dacă a ieșit din
        // limitele ecranului.
        private bool checkCollision()
        {
            if (player.Location.X < 0 || player.Location.X + player.Width > 608)
                return true;
            if (player.Location.Y < 0 || player.Location.Y + player.Height > 633)
                return true;
            for (int i = 0; i < map1.Length; i++)
                if (player.Bounds.IntersectsWith(map1[i].Bounds))
                    return true;
            return false;
        }

        //  În functia Form1_KeyDown se verifică ce buton a fost apăsat de utilizator și se mută playerul în consecință. Dacă playerul intră în
        //coliziune cu pereții labirintului, se revine la poziția anterioară.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.Image = Image.FromFile(PATH + "\\left.png");
                player.Left -= 5;
                if (checkCollision())
                    player.Left += 5;
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.Image = Image.FromFile(PATH + "\\right.png");
                player.Left += 5;
                if (checkCollision())
                    player.Left -= 5;
            }
            else if (e.KeyCode == Keys.Up)
            {
                player.Image = Image.FromFile(PATH + "\\up.png");
                player.Top -= 5;
                if (checkCollision())
                    player.Top += 5;
            }
            else if (e.KeyCode == Keys.Down)
            {
                player.Image = Image.FromFile(PATH + "\\down.png");
                player.Top += 5;
                if (checkCollision())
                    player.Top -= 5;
            }
        }

        // Functia timer1_Tick verifică dacă player a ajuns la finish. În caz afirmativ, se afișează un meniu care oferă opțiunea de a juca din
        //nou sau de a ieși din joc.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(finish.Bounds))
            {
                timer1.Enabled = false;

                menu.Enabled = true;
                menu.Visible = true;

                title.Text = "You Win!";
                title.Enabled = true;
                title.Visible = true;

                start_button.Text = "Play Again";
                start_button.Enabled = true;
                start_button.Visible = true;

                quit_button.Enabled = true;
                quit_button.Visible = true;
            }
        }

        // În metoda start_button_Click se resetează poziția player-ului și se pornește timer-ul pentru a începe jocul din nou.
        private void start_button_Click(object sender, EventArgs e)
        {
            menu.Enabled = false;
            menu.Visible = false;

            title.Enabled = false;
            title.Visible = false;

            start_button.Enabled = false;
            start_button.Visible = false;

            quit_button.Enabled = false;
            quit_button.Visible = false;

            player.Location = new Point(5, 6);
            timer1.Enabled = true;
        }

        // În metoda quit_button_Click se afișează un mesaj de confirmare înainte de a închide aplicația.
        private void quit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
