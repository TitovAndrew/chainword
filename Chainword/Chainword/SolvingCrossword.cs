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
        // пересечение букв, количество кликов
        int CrossLetters = 2, NumberOfParts = 0, prevLeft = 0;
        List<int> IndexWords = new List<int>();
        char[] AllLetters;

        public SolvingCrossword()
        {
            TopMost = true;
            InitializeComponent();

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

        #region линейное отображение
        public void ShowLinear()
        {
            this.Size = new Size(720, 320);
            this.Controls.Add(new Button() { Name = "PrevButton", Location = new Point(25, 124), Text = "<", Size = new Size(60, 32) });
            this.Controls.Add(new Button() { Name = "NextButton", Location = new Point(625, 124), Text = ">", Size = new Size(60, 32) });
            (Controls["PrevButton"] as Button).Click += new System.EventHandler(PrevButton_Click);
            (Controls["NextButton"] as Button).Click += new System.EventHandler(NextButton_Click);
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


            int x = 0;
            foreach (var Symbol in AllSymbols)
            {
                x += Symbol.Count();
            }
            AllLetters = new char[x]; // массив букв всех слов
            MessageBox.Show(z + "!!!" + AllLetters.Length);
            NumberOfParts = 1;
            GenericTextBox(NumberOfParts, true);
        }

        //кнопки для линейного отображения
        private void PrevButton_Click(object sender, EventArgs e)
        {
            for (int k = 1; k < 15; k++)
            {
                if (NumberOfParts == k)
                {
                    //добавляем в массив букв те буквы, которые ввел пользователь в текстбоксы
                    for (int i = 1; i < 16; i++)
                    {
                        foreach (var tmp in (Controls["TextBox" + i.ToString()] as TextBox).Text)
                        {
                            AllLetters[i + 15 * k - 16] = tmp;
                            break;
                        }
                    }
                }
            }
            NumberOfParts--;
            GenericTextBox(NumberOfParts, false);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            for (int k = 1; k < 15; k++)
            {
                if (NumberOfParts == k)
                {
                    //добавляем в массив букв те буквы, которые ввел пользователь в текстбоксы
                    for (int i = 1; i < 16; i++)
                    {
                        foreach (var tmp in (Controls["TextBox" + i.ToString()] as TextBox).Text)
                        {
                            AllLetters[i + 15 * k - 16] = tmp;
                            break;
                        }
                    }
                }
            }
            NumberOfParts++;
            GenericTextBox(NumberOfParts, false);
        }

        void GenericTextBox(int NumberOfParts, bool FirstTime)
        {
            int kostyl = 0;
            for (int i = 1; i < 16; i++)
            {
                foreach (var item in IndexWords)
                {
                    if (i + 15 * NumberOfParts - 15 == item &&
                        item != AllLetters.Length &&
                        item != AllLetters.Length - 1)
                    {
                        if (!FirstTime)
                            this.Controls.Remove(Controls["TextBox" + i.ToString()]);
                        this.Controls.Add(new TextBox()
                        {
                            Name = ("TextBox" + i.ToString()),
                            Location = new Point(60 + 35 * i, 125),
                            Text = "",
                            Font = new Font("Areal", 16),
                            Size = new Size(30, 30),
                            BackColor = Color.Aqua,
                            Multiline = true,
                            TextAlign = HorizontalAlignment.Center,
                            MaxLength = 1
                        });
                        kostyl++;
                        (Controls["TextBox" + i.ToString()] as TextBox).TextChanged += new System.EventHandler(TextBox_TextChanged);
                    }
                    else kostyl = 0;
                }
                if (kostyl == 0)
                {
                    if (!FirstTime)
                        this.Controls.Remove(Controls["TextBox" + i.ToString()]);
                    this.Controls.Add(new TextBox()
                    {
                        Name = ("TextBox" + i.ToString()),
                        Location = new Point(60 + 35 * i, 125),
                        Text = "",
                        Font = new Font("Areal", 16),
                        Size = new Size(30, 30),
                        Multiline = true,
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1
                    });
                    (Controls["TextBox" + i.ToString()] as TextBox).TextChanged += new System.EventHandler(TextBox_TextChanged);
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if ((Controls["TextBox" + ("1").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("1").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("2").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("2").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("2").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("3").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("3").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("3").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("4").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("4").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("4").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("5").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("5").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("5").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("6").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("6").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("6").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("7").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("7").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("7").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("8").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("8").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("8").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("9").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("9").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("9").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("10").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("10").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("10").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("11").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("11").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("11").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("12").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("12").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("12").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("13").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("13").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("13").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("14").ToString()] as TextBox).Focus();

            else if ((Controls["TextBox" + ("14").ToString()] as TextBox).Focused &&
                (Controls["TextBox" + ("14").ToString()] as TextBox).Text != "")
                (Controls["TextBox" + ("15").ToString()] as TextBox).Focus();
        }
        #endregion

        #region спиральное отображение
        public void ShowSpiral()
        {

        }
        #endregion

        #region отображение змейка
        public void ShowSnake()
        {

        }
        #endregion


    }
}
