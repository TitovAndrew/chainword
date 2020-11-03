using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericCross
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // Линейный
        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            TextBox[] tb = new TextBox[0];
            tb = new TextBox[10];
            for (int i = 0; i < tb.Length; i++)
            {
                count++;
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(10 + i * 25, 10);
                tb[i].Size = new System.Drawing.Size(20, 25);
                tb[i].Text = count.ToString();
                Controls.Add(tb[i]);
            }
        }

        // Змейка
        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[,] tb = new TextBox[8, 8];

            /*for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    Controls.Remove(tb[i, j]);
                    tb[i, j].Dispose();
                }
            }*/

            int count = 0;
            int k = 0;
            int last_cell = tb.GetLength(1) - 1;
            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    tb[i, j] = new System.Windows.Forms.TextBox();
                    if (i % 2 != 0)
                    {
                        if (k % 2 != 0)
                            tb[i, j].Location = new System.Drawing.Point(10 - j * 25, 10 + i * 25);
                        else
                            tb[i, j].Location = new System.Drawing.Point(10 + last_cell * 25, 10 + i * 25);
                    }
                    else
                    {
                        if (k % 2 == 0)
                            tb[i, j].Location = new System.Drawing.Point(10 + j * 25, 10 + i * 25);
                        else
                            tb[i, j].Location = new System.Drawing.Point((25 * last_cell + 10) - j * 25, 10 + i * 25);
                    }
                    count++;
                    tb[i, j].Size = new System.Drawing.Size(20, 25);
                    tb[i, j].Text = count.ToString();
                    Controls.Add(tb[i, j]);
                    if (i % 2 != 0)
                    {
                        k++;
                        break;
                    }
                }

            }
        }

        // Спираль
        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[,] tb = new TextBox[5, 5];

            /*for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    Controls.Remove(tb[i, j]);
                    tb[i, j].Dispose();
                }
            }*/

            for (int i = 0; i < tb.GetLength(0); i++)
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    tb[i, j] = new System.Windows.Forms.TextBox();
                    tb[i, j].Location = new System.Drawing.Point(200 + j * 25, 100 + i * 25);
                    tb[i, j].Size = new System.Drawing.Size(20, 25);
                    Controls.Add(tb[i, j]);
                }
        }
    }
}
