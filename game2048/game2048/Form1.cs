using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2048
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        int n = 4;
        int r1, r1_x, r1_y, r2, r2_x, r2_y, Random_index;

        public Form1()
        {
            InitializeComponent();
            game_board = new Label[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    game_board[i, j] = new Label();
                    //    game_board[i, j].Text = "2";
                    game_board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    game_board[i, j].Font = new Font("Tahoma", 32);
                    tableLayoutPanel1.BackColor = Color.FromArgb(187, 173, 160);
                    game_board[i, j].BackColor = Color.FromArgb(238, 228, 218);
                    game_board[i, j].ForeColor = Color.FromArgb(119, 110, 101);
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin = Margin;
                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);

                }

            }

            Random r = new Random();

            int[] init_numbers = { 2, 2, 2, 2, 2, 4 };
            Random_index = r.Next(0, init_numbers.Length);
            r1 = init_numbers[Random_index];
            r1_x = r.Next(0, 3);
            r1_y = r.Next(0, 3);
            Random_index = r.Next(0, init_numbers.Length);
            r2 = init_numbers[Random_index];
            do
            {
                r2_x = r.Next(0, 3);
                r2_y = r.Next(0, 3);
            } while (r1_x == r2_x && r1_y == r2_y);

            game_board[r1_x, r1_y].Text = Convert.ToString(r1);
            game_board[r2_x, r2_y].Text = Convert.ToString(r2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void make_random()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 2, 2, 4 };
            bool epty;
            do
            {
                epty = true;
                r1_x = rand.Next(0, n - 1);
                r1_y = rand.Next(0, n - 1);
                if (game_board[r1_x, r1_y].Text != "")
                    epty = false;
            } while (epty == false);
            r1 = (num[rand.Next(0, num.Length)]);
            game_board[r1_x, r1_y].Text = r1.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool move = false;

            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (game_board[i, j].Text != "")
                        {
                            if (e.KeyData == Keys.Up)
                            {


                                if (j > 0 && game_board[i, j - 1].Text == "")
                                {
                                    move = true;

                                    game_board[i, j - 1].Text = game_board[i, j].Text;
                                 
                                    game_board[i, j].Text = "";
                                }


                            }
                            else if (e.KeyData == Keys.Down)
                            {

                                if (j < n - 1 && game_board[i, j + 1].Text == "")
                                {
                                    move = true;

                                    game_board[i, j + 1].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                }

                            }
                            else if (e.KeyData == Keys.Left)
                            {
                                if (i > 0 && game_board[i - 1, j].Text == "")
                                {
                                    move = true;

                                    game_board[i - 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                }

                            }
                            else if (e.KeyData == Keys.Right)
                            {
                                if (i < n - 1 && game_board[i + 1, j].Text == "")
                                {
                                    move = true;

                                    game_board[i + 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";
                                }

                            }
                        }
                    }


                }
            }
            if (move == true)
                make_random();
            sumlable();
            color();
        }

        public void color()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (game_board[i, j].Text == "")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.DarkMagenta;
                    }
                    if (game_board[i, j].Text == "2")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.LightGray;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "4")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.Gray;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "8")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.Orange;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "16")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.OrangeRed;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "32")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.DarkOrange;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "64")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.LightPink;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "128")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.Red;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "256")
                    {
                        game_board[i, j].BackColor = Color.DarkRed;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "512")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.LightBlue;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "1024")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.Blue;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (game_board[i, j].Text == "2048")
                    {
                        game_board[i, j].BackColor = System.Drawing.Color.Green;
                        game_board[i, j].ForeColor = System.Drawing.Color.White;
                    }

                }
            }
          
        }
        private void sumlable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(game_board[i,j]== game_board[i, j - 1])
                    {
                        game_board[i, j].Text = game_board[i, j].Text + game_board[i, j - 1];
                        game_board[i, j  - 1].Text = "";

                    }
                    else if (game_board[i, j] == game_board[i, j + 1])
                    {
                        game_board[i, j].Text = game_board[i, j].Text + game_board[i, j + 1];
                        game_board[i, j + 1].Text = "";
                    }
                    else if (game_board[i, j] == game_board[i+1, j ])
                    {
                        game_board[i, j].Text = game_board[i, j].Text + game_board[i+1, j ];
                        game_board[i + 1, j].Text = "";
                    }
           
                    else if (game_board[i, j] == game_board[i-1, j ])
                    {
                        game_board[i, j].Text = game_board[i, j].Text + game_board[i-1, j];
                        game_board[i-1, j].Text = "";
                    }
                }
            }
        }
    }
}












