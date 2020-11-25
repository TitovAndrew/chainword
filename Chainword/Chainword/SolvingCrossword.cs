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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class SolvingCrossword : Form
    {
        int index; //индекс вида отображения
        string[] words;
        string name_cross, dictionary;
        int cross_letters; // пересечение букв
        Panel Panel1;
        Panel PanelQuestion;
        List<int> IndexWords = new List<int>();
        Label Question;

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
            Panel1.Location = new Point(2, 50);
            Panel1.AutoScroll = true;

            PanelQuestion = new Panel();
            PanelQuestion.AutoScroll = true;
            this.Controls.Add(PanelQuestion);

            label1 = new Label();
            label1.Font = new Font("Calibri", 14);
            label1.Text = cross.Name.ToUpper();
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            this.Controls.Add(label1);

            Question = new Label();
            Question.Font = new Font("Calibri", 12);
            Question.AutoSize = true;
            PanelQuestion.Controls.Add(Question);
            PanelQuestion.Visible = false;

            if (index == 0)
                ShowSnake();
            else if (index == 1)
                ShowLinear();
            else
                ShowSpiral();
        }

        #region линейное отображение
        //добавить подсказки
        //добавить вопросы
        public void ShowLinear()
        {
            this.Size = new Size(720, 380);
            GenericTextBox();
        }

        void CreateTB_Linear(int count_symbols)
        {
            bool ls = false;
            Panel1.Size = new Size(690, 150);
            this.Controls.Add(Panel1);
            int kostyl = 0;
            for (int i = 1; i <= count_symbols; i++)
            {
                foreach (var item in IndexWords)
                {
                    if (cross_letters == 1)
                    {
                        if (i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else if (cross_letters == 2)
                    {
                        if (i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else
                    {
                        if (i != count_symbols - 2 && i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }

                    if (i == item && ls == true)
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
                        break;
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
            }
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                textbox.TextChanged += TextBox_TextChanged;
                textbox.Click += TextBox_Click;
                textbox.MouseDown += TextBox_InfoClick;
            }
        }
        #endregion

        #region спиральное отображение

        public void ShowSpiral()
        {
            GenericTextBox();
        }

        void CreateTB_Spiral(int count_symbols)
        {
            bool ls = false;
            int prevX = 0, prevY = 0;
            this.Controls.Add(Panel1);




            if (count_symbols < 20)
            {
                this.Size = new Size(400, 400);
                Panel1.Size = new Size(400, 400);
                prevX = 170;
                prevY = 100;
            }
            else if (count_symbols < 50)
            {
                this.Size = new Size(560, 500);
                Panel1.Size = new Size(560, 500);
                prevX = 265;
                prevY = 170;
            }
            else if (count_symbols < 100)
            {
                this.Size = new Size(630, 600);
                Panel1.Size = new Size(630, 605);
                prevX = 285;
                prevY = 250;
            }
            else
            {
                this.Size = new Size(700, 750);
                Panel1.Size = new Size(700, 750);
                prevX = 350;
                prevY = 300;
            }

            int kostyl = 0;

            int kp = 0; //длина стороны
            int kn = 0;
            int direction = 1;

            Point locate = new Point(0, 0);


            for (int i = 1; i <= count_symbols; i++)
            {
                if (i == 1)
                {
                    locate = new Point(prevX, prevY);
                    direction = 1;
                    kp = 1;
                    kn = 1;
                }
                else
                {
                    switch (direction)
                    {
                        case 1:
                            locate = new Point(prevX - 35, prevY);
                            prevX -= 35;
                            kn++;
                            if (kn > kp)
                            {
                                direction = 2;
                                kp = kn;
                                kn = 1;
                            }
                            break;
                        case 2:
                            locate = new Point(prevX, prevY - 35);
                            prevY -= 35;
                            kn++;
                            if (kn > kp)
                            {
                                direction = 3;
                                kp = kn;
                                kn = 1;
                            }
                            break;
                        case 3:
                            locate = new Point(prevX + 35, prevY);
                            prevX += 35;
                            kn++;
                            if (kn > kp)
                            {
                                direction = 4;
                                kp = kn;
                                kn = 1;
                            }
                            break;
                        case 4:
                            locate = new Point(prevX, prevY + 35);
                            prevY += 35;
                            kn++;
                            if (kn > kp)
                            {
                                direction = 1;
                                kp = kn;
                                kn = 1;
                            }
                            break;
                    }
                }

                foreach (var item in IndexWords)
                {
                    if (cross_letters == 1)
                    {
                        if (i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else if (cross_letters == 2)
                    {
                        if (i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else
                    {
                        if (i != count_symbols - 2 && i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    if (i == item && ls == true)
                    {
                        Panel1.Controls.Add(new TextBox()
                        {
                            Name = ("TextBox" + i.ToString()),
                            Location = locate,
                            Text = "" + i,
                            Font = new Font("Areal", 16),
                            Size = new Size(30, 30),
                            BackColor = Color.Aqua,
                            Multiline = true,
                            TextAlign = HorizontalAlignment.Center,
                            MaxLength = 1
                        });
                        kostyl++;
                        break;
                    }
                    else kostyl = 0;
                }
                if (kostyl == 0)
                {
                    Panel1.Controls.Add(new TextBox()
                    {
                        Name = ("TextBox" + i.ToString()),
                        Location = locate,
                        Text = "" + i,
                        Font = new Font("Areal", 16),
                        Size = new Size(30, 30),
                        Multiline = true,
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1
                    });
                }
            }
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                textbox.TextChanged += TextBox_TextChanged;
                textbox.Click += TextBox_Click;
                textbox.MouseDown += TextBox_InfoClick;
            }
        }
        #endregion

        #region отображение змейка
        public void ShowSnake()
        {
            GenericTextBox();
        }

        void CreateTB_Snake(int count_symbols)
        {
            bool ls = false;
            this.Controls.Add(Panel1);
            int width_cross = 0;
            if (count_symbols < 20)
            {
                width_cross = 8;
                this.Size = new Size(315, 400);
                Panel1.Size = new Size(315, 400);
            }
            else if (count_symbols < 50)
            {
                width_cross = 15;
                this.Size = new Size(560, 400);
                Panel1.Size = new Size(560, 400);
            }
            else if (count_symbols < 100)
            {
                width_cross = 17;
                this.Size = new Size(630, 500);
                Panel1.Size = new Size(630, 505);
            }
            else
            {
                width_cross = 20;
                this.Size = new Size(740, 600);
                Panel1.Size = new Size(740, 600);
            }

            int kostyl = 0, turn = width_cross, down = 0, locate_X = 1;
            bool left_to_right = true;
            Point locate = new Point(0, 0);
            for (int i = 1; i <= count_symbols; i++)
            {
                if (turn > 0)
                {
                    locate = new Point(10 + 35 * (locate_X - 1), 20 + 35 * down);
                    locate_X++;
                    turn--;
                }
                else if (turn == 0)
                {
                    down++;
                    locate = new Point(10 + 35 * (locate_X - 2), 20 + 35 * down);
                    if (down % 2 == 0)
                    {
                        if (left_to_right)
                        {
                            turn = -width_cross + 1;
                            left_to_right = false;
                        }
                        else if (!left_to_right)
                        {
                            turn = width_cross - 1;
                            left_to_right = true;
                        }
                    }
                }
                else if (turn < 0)
                {
                    locate_X--;
                    locate = new Point(10 + 35 * (locate_X - 2), 20 + 35 * down);
                    turn++;
                }

                foreach (var item in IndexWords)
                {
                    if (cross_letters == 1)
                    {
                        if (i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else if (cross_letters == 2)
                    {
                        if (i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    else
                    {
                        if (i != count_symbols - 2 && i != count_symbols - 1 && i != count_symbols)
                            ls = true;
                        else ls = false;
                    }
                    if (i == item && ls == true)
                    {
                        Panel1.Controls.Add(new TextBox()
                        {
                            Name = ("TextBox" + i.ToString()),
                            Location = locate,
                            Text = "",
                            Font = new Font("Areal", 16),
                            Size = new Size(30, 30),
                            BackColor = Color.Aqua,
                            Multiline = true,
                            TextAlign = HorizontalAlignment.Center,
                            MaxLength = 1
                        });
                        kostyl++;
                        break;
                    }
                    else kostyl = 0;
                }
                if (kostyl == 0)
                {
                    Panel1.Controls.Add(new TextBox()
                    {
                        Name = ("TextBox" + i.ToString()),
                        Location = locate,
                        Text = "",
                        Font = new Font("Areal", 16),
                        Size = new Size(30, 30),
                        Multiline = true,
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1
                    });
                }
            }
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                textbox.TextChanged += TextBox_TextChanged;
                textbox.Click += TextBox_Click;
                textbox.MouseDown += TextBox_InfoClick;
            }
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
                count_symbols += cs.Length;

            // Создаем текстбоксы
            if (index == 0)
                CreateTB_Snake(count_symbols);
            else if (index == 1)
                CreateTB_Linear(count_symbols);
            else
                CreateTB_Spiral(count_symbols);
        }

        private string GetDefinition(int id_TextBox)
        {
            PanelQuestion.Visible = true;
            int id = 0;
            string definition = "";
            foreach (var item in IndexWords)
            {
                if (item == id_TextBox)
                    break;
                else id++;
            }
            string suitable_word = words[id].ToUpper();

            using (StreamReader fs = new StreamReader(dictionary))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    if (temp.Split(' ')[0] == suitable_word)
                    {
                        temp = temp.Remove(0, temp.IndexOf(' ') + 1);
                        definition += temp;
                    }
                }
            }
            return definition;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                if (textbox.Focused)
                {
                    textbox.SelectionStart = 0;
                    textbox.SelectionLength = textbox.Text.Length;
                    return;
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int amount_textbox = 0;
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                amount_textbox++;
            }
            for (int i = 1; i <= amount_textbox; i++)
            {
                foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                {
                    if (textbox.Name == ("TextBox" + i) && textbox.Focused && textbox.Text != "")
                    {
                        foreach (var textbox1 in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                        {
                            if (textbox1.Name == ("TextBox" + (i + 1).ToString()))
                            {
                                textbox1.Focus();
                                textbox1.SelectionStart = 0;
                                textbox1.SelectionLength = textbox1.Text.Length;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void TextBox_InfoClick(object sender, EventArgs e)
        {
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                if (textbox.BackColor == System.Drawing.Color.Aqua && textbox.Focused)
                {
                    if (index == 0)
                    {

                    }
                    else if (index == 1)
                    {
                        PanelQuestion.Size = new Size(690, 50);
                        PanelQuestion.Location = new Point(2, 200);

                        int id_TextBox;
                        int.TryParse(string.Join("", textbox.Name.ToString().Where(c => char.IsDigit(c))), out id_TextBox);
                        Question.Text = GetDefinition(id_TextBox);
                    }
                    else
                    {

                    }
                    break;
                }
            }
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
