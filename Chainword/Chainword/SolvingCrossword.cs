using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class SolvingCrossword : Form
    {
        int index = 0; //индекс вида отображения
        string[] words = { "актив", "иваново", "вокабола", "ландау", "аукцион" };
        int CrossLetters = 2;
        List<int> IndexWords = new List<int>();

        public SolvingCrossword()
        {
            InitializeComponent();
            /*TextBox x = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(25, 25)
            };*/



            if (index == 0)
            {
                ShowLinear();
            }
            else if (index == 1)
            {
                ShowSpiral();
            }
            else
            {
                ShowSnake();
            }
        }

        //линейное отображение
        public void ShowLinear()
        {
            this.Size = new Size(720, 320);
            this.Controls.Add(new Button() { Name = "PrevButton", Location = new Point(25, 124), Text = "<", Size = new Size(60, 32) });
            this.Controls.Add(new Button() { Name = "NextButton", Location = new Point(625, 124), Text = ">", Size = new Size(60, 32) });

            List<char[]> AllSymbols = new List<char[]>();

            int k = 1;
            for (int i = 0; i < words.Length; i++)
            {
                if (k == 1)
                {
                    IndexWords.Add(k);
                }

                k += words[i].Substring(CrossLetters).Length;

                if (k != 1)
                {
                    if (CrossLetters == 1)
                    {
                        IndexWords.Add(k);
                    }
                    else if (CrossLetters == 2)
                    {
                        IndexWords.Add(k);
                        IndexWords.Add(k + 1);
                    }
                    else
                    {
                        IndexWords.Add(k);
                        IndexWords.Add(k + 1);
                        IndexWords.Add(k + 2);
                    }
                }

                if (i == 0)
                    AllSymbols.Add(words[i].ToCharArray());
                else
                    AllSymbols.Add(words[i].Substring(CrossLetters).ToCharArray());
            }
            string z = "";
            foreach (var item in IndexWords)
            {
                z += item + " ";

            }
            MessageBox.Show(z);

            int x = 0;
            int kostyl = 0;
            foreach (var Symbol in AllSymbols)
            {
                x += Symbol.Count();
            }

            for (int i = 1; i < 16; i++)
            {
                foreach (var item in IndexWords)
                {
                    if (i == item)
                    {
                        this.Controls.Add(new TextBox() { Name = ("TextBox" + i.ToString()), Location = new Point(60 + 35 * i, 125), Text = "", Font = new Font("Areal", 16), Size = new Size(30, 30), BackColor = Color.Aqua, Multiline = true, TextAlign = HorizontalAlignment.Center });
                        kostyl++;
                    }
                }
                if (kostyl == 0)
                {
                    this.Controls.Add(new TextBox() { Name = ("TextBox" + i.ToString()), Location = new Point(60 + 35 * i, 125), Text = "", Font = new Font("Areal", 16), Size = new Size(30, 30), Multiline = true, TextAlign = HorizontalAlignment.Center });
                }
                kostyl = 0;
            }
        }

        //спиральное отображение
        public void ShowSpiral()
        {

        }

        //змеиное отображение
        public void ShowSnake()
        {

        }
        private void SolvingCrossword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                //TextBox2.Focus();
                //this.ActiveControl = TextBox2;
            }
        }

        private void QWERTY_TextChanged(object sender, EventArgs e)
        {
            //this.ActiveControl = TextBox2;
        }
    }
}
