using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class SolvingCrossword : Form
    {
        int index; //индекс вида отображения
        string[] words;
        string name_cross, dictionary;
        // пересечение букв, количество кликов
        int cross_letters, NumberOfParts = 0;
        Panel Panel1;
        List<int> IndexWords = new List<int>();

        public SolvingCrossword(string PathToFile)
        {
            TopMost = true;
            InitializeComponent();

            Crossword cross = new Crossword();
            FileStream stream = File.OpenRead(PathToFile);
            BinaryFormatter formatter = new BinaryFormatter();
            cross = formatter.Deserialize(stream) as Crossword;
            stream.Close();

            this.dictionary = cross.Dictionary;
            this.name_cross = cross.Name;
            this.index = cross.DisplayType;
            this.cross_letters = cross.CrossLetters;
            this.words = cross.Allwords;

            Panel1 = new Panel();
            Panel1.Location = new Point(9, 126);
            Panel1.Size = new Size(683, 150);
            Panel1.BackColor = System.Drawing.Color.Gray;
            Panel1.AutoScroll = true;

            label1 = new Label();
            label1.Font = new Font("Calibri", 20);
            label1.Text = "Разгадывание кросворда";
            label1.Size = new Size(313, 33);



            if (index == 0)
            {
                ShowSnake();
            }
            else if (index == 1)
            {
                ShowLinear();
            }
            else
            {
                ShowSpiral();
            }
        }

        #region линейное отображение
        public void ShowLinear()
        {
            this.Size = new Size(720, 320);
            GenericTextBox();
            /*this.Controls.Add(new Panel()
            {
                Name = "Panel1",
                AutoScroll = true,
                Location = new Point(625, 124),
                Size = new Size(500, 300)
            });*/

            /*this.Controls.Add(new Button() { Name = "PrevButton", Location = new Point(25, 124), Text = "<", Size = new Size(60, 32) });
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
            GenericTextBox(NumberOfParts, true);*/
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
                            //AllLetters[i + 15 * k - 16] = tmp;
                            break;
                        }
                    }
                }
            }
            NumberOfParts--;
            //GenericTextBox(NumberOfParts, false);
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
                            //AllLetters[i + 15 * k - 16] = tmp;
                            break;
                        }
                    }
                }
            }
            NumberOfParts++;
            //GenericTextBox(NumberOfParts, false);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int amount_textbox = 0;
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                amount_textbox++;
            }
            MessageBox.Show("" + amount_textbox);
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                for (int i = 1; i <= amount_textbox; i++)
                {
                    if (textbox.Focused && textbox.Text != "")
                    {
                        foreach (var textbox1 in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                        {
                            if (textbox1.Name == ("TextBox" + i + 1))
                                textbox1.Focus();
                        }
                    }
                }
            }

            /*if ((Controls["TextBox" + i.ToString()] as TextBox).Focused &&
                (Controls["TextBox" + i.ToString()] as TextBox).Text != "")
                        (Controls["TextBox" + (i + 1).ToString()] as TextBox).Focus();*/

            /* if ((Controls["TextBox" + ("1").ToString()] as TextBox).Focused &&
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
             (Controls["TextBox" + ("15").ToString()] as TextBox).Focus();*/
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
            this.Size = new Size(1000, 500);
            GenericTextBox();
        }
        #endregion

        private List<char[]> GetArrayCharAllSymbols()
        {
            List<char[]> AllSymbols = new List<char[]>();
            int k = 1;
            for (int i = 0; i < words.Length; i++)
            {
                if (k == 1)
                {
                    IndexWords.Add(k);
                }

                k += words[i].Substring(cross_letters).Length;

                if (k != 1)
                {
                    if (cross_letters == 1)
                    {
                        IndexWords.Add(k);
                    }
                    else if (cross_letters == 2)
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
                    AllSymbols.Add(words[i].Substring(cross_letters).ToCharArray());
            }

            return AllSymbols;
        }

        void GenericTextBox()
        {
            // Записываем в список all_symbols слова в виде массивов символов + указываем в IndexWords индексы начала слов
            List<char[]> all_symbols = GetArrayCharAllSymbols();

            // Записываем в count_symbols количество всех символов исходных слов
            int count_symbols = 0;
            foreach (var cs in all_symbols)
            {
                count_symbols += cs.Length;
            }

            // Создаем текстбоксы
            if (cross_letters == 1)
            {
                CreateTB_Linear(count_symbols);
            }
            else if (cross_letters == 2)
            {

            }
            else
            {

            }

        }

        void CreateTB_Linear(int count_symbols)
        {
            this.Controls.Add(Panel1);
            label1.Location = new Point(196, 9);
            this.Controls.Add(label1);
            MessageBox.Show("" + count_symbols);
            int kostyl = 0;
            for (int i = 1; i <= count_symbols; i++)
            {
                foreach (var item in IndexWords)
                {
                    if (i == item && i != count_symbols)
                    {
                        Panel1.Controls.Add(new TextBox()
                        {
                            Name = ("TextBox" + i.ToString()),
                            Location = new Point(35 * (i - 1), 50),
                            Text = "",
                            Font = new Font("Areal", 16),
                            Size = new Size(30, 30),
                            BackColor = Color.Aqua,
                            Multiline = true,
                            TextAlign = HorizontalAlignment.Center,
                            MaxLength = 1
                        });
                        kostyl++;
                    }
                    else kostyl = 0;
                }
                if (kostyl == 0)
                {
                    Panel1.Controls.Add(new TextBox()
                    {
                        Name = ("TextBox" + i.ToString()),
                        Location = new Point(35 * (i - 1), 50),
                        Text = "",
                        Font = new Font("Areal", 16),
                        Size = new Size(30, 30),
                        Multiline = true,
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1
                    });
                }
                //(Controls["TextBox" + i.ToString()] as TextBox).TextChanged += new System.EventHandler(TextBox_TextChanged);
            }
            /*foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    c.TextChanged += new System.EventHandler(TextBox_TextChanged);
                }
            }*/
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                textbox.TextChanged += TextBox_TextChanged;
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.WindowState = FormWindowState.Normal;
        }
    }

    static class TextBoxExtends
    {
        public static IEnumerable<Control> GetAllChildren(this Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                yield return next;
            }
        }
    }
}
