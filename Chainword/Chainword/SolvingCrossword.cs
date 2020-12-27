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
    // Класс разгадывания кроссворда
    public partial class SolvingCrossword : Form
    {
        int index, count_symbols; //индекс вида отображения
        string[] words;
        string name_cross, dictionary, login_name;
        int cross_letters; // пересечение букв
        Panel Panel1, PanelQuestion;
        List<int> IndexWords = new List<int>();
        Label Question, HintLabel;
        int locateY_TB = 0, id_TB_hint;
        Crossword cross;
        bool isNew = true;
        List<char[]> all_symbols;
        Button GetHintButton, SaveButton;
        double progress;
        bool open_next = false;

        // Конструктор класса
        public SolvingCrossword(string PathToFile, string login_name)
        {
            InitializeComponent();

            if (!Directory.Exists(Environment.CurrentDirectory + "\\" + login_name))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + login_name);

            try
            {
                string[] file_name = PathToFile.Split('\\');
                string file_cross = file_name[file_name.Length - 1];
                cross = new Crossword();
                FileStream stream = File.OpenRead(Environment.CurrentDirectory + "\\" + login_name + "\\" + file_cross);
                BinaryFormatter formatter = new BinaryFormatter();
                cross = formatter.Deserialize(stream) as Crossword;
                stream.Close();
                isNew = false;
            }
            catch
            {
                cross = new Crossword();
                FileStream stream = File.OpenRead(PathToFile);
                BinaryFormatter formatter = new BinaryFormatter();
                cross = formatter.Deserialize(stream) as Crossword;
                stream.Close();
                isNew = true;
            }

            this.dictionary = cross.Dictionary;
            this.name_cross = cross.Name;
            this.index = cross.DisplayType;
            this.cross_letters = cross.CrossLetters;
            this.words = cross.Allwords;
            this.login_name = login_name;

            Panel1 = new Panel();
            Panel1.Location = new Point(2, 50);
            Panel1.AutoScroll = true;

            PanelQuestion = new Panel();
            PanelQuestion.AutoScroll = true;
            this.Controls.Add(PanelQuestion);

            label1 = new Label();
            label1.Font = new Font("Calibri", 14);
            label1.Text = name_cross.ToUpper();
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            this.Controls.Add(label1);

            HintLabel = new Label();
            HintLabel.Font = new Font("Calibri", 14);
            HintLabel.Text = "Осталось подсказок: " + cross.Hint;
            HintLabel.AutoSize = true;
            this.Controls.Add(HintLabel);

            Question = new Label();
            Question.Font = new Font("Calibri", 12);
            Question.AutoSize = true;
            PanelQuestion.Controls.Add(Question);
            PanelQuestion.Visible = false;

            GetHintButton = new Button();
            GetHintButton.Size = new Size(30, 30);
            GetHintButton.Font = new Font("Calibri", 14);
            GetHintButton.Text = "?";
            GetHintButton.Click += Click_GetHintButton;
            if (cross.Hint <= 0)
                GetHintButton.Enabled = false;
            this.Controls.Add(GetHintButton);

            Button CheckButton = new Button();
            CheckButton.Size = new Size(140, 32);
            CheckButton.Text = "Проверить";
            CheckButton.Click += Click_CheckButton;
            this.Controls.Add(CheckButton);

            SaveButton = new Button();
            SaveButton.Size = new Size(140, 32);
            SaveButton.Text = "Сохранить";
            SaveButton.Click += Click_SaveButton;
            this.Controls.Add(SaveButton);

            Button SaveExitButton = new Button();
            SaveExitButton.Size = new Size(140, 32);
            SaveExitButton.Text = "Сохранить и выйти";
            SaveExitButton.Click += Click_SaveExitButton;
            this.Controls.Add(SaveExitButton);

            if (index == 0)
            {
                ShowSnake();

                foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                {
                    int id_TextBox;
                    int.TryParse(string.Join("", textbox.Name.ToString().Where(c => char.IsDigit(c))), out id_TextBox);

                    if (id_TextBox == count_symbols)
                    {
                        locateY_TB = textbox.Location.Y + 100;
                        break;
                    }
                }

                if (count_symbols < 20)
                {
                    PanelQuestion.Size = new Size(330, 50);
                    PanelQuestion.Location = new Point(2, locateY_TB);
                    CheckButton.Size = new Size(80, 32);
                    SaveButton.Size = new Size(80, 32);
                }
                else if (count_symbols < 50)
                {
                    PanelQuestion.Size = new Size(575, 50);
                    PanelQuestion.Location = new Point(2, locateY_TB);
                }
                else if (count_symbols < 100)
                {
                    PanelQuestion.Size = new Size(610, 50);
                    PanelQuestion.Location = new Point(2, locateY_TB);
                }                
                else if (count_symbols < 170) 
                {
                    PanelQuestion.Size = new Size(720, 50);
                    PanelQuestion.Location = new Point(2, locateY_TB);
                }
                else
                {
                    PanelQuestion.Size = new Size(1020, 50);
                    PanelQuestion.Location = new Point(2, locateY_TB);
                }

                CheckButton.Location = new Point(5, locateY_TB + 60);
                SaveButton.Location = new Point(CheckButton.Location.X + CheckButton.Size.Width + 5, PanelQuestion.Location.Y + 60);
                SaveExitButton.Location = new Point(SaveButton.Location.X + SaveButton.Size.Width + 5, PanelQuestion.Location.Y + 60);

                int lx = SaveButton.Location.Y;
                if (count_symbols < 20)
                {
                    HintLabel.Text = "Подсказки: " + cross.Hint;
                    this.Size = new Size(350, lx + 80);
                }
                else if (count_symbols < 50)
                    this.Size = new Size(595, lx + 80);
                else if (count_symbols < 100)
                    this.Size = new Size(630, lx + 80);
                else if (count_symbols < 170)
                    this.Size = new Size(740, lx + 80);
                else this.Size = new Size(1020, lx + 80);
            }
            else if (index == 1)
            {
                ShowLinear();
                PanelQuestion.Size = new Size(690, 50);
                PanelQuestion.Location = new Point(2, 200);

                CheckButton.Location = new Point(5, 260);
                SaveButton.Location = new Point(150, 260);
                SaveExitButton.Location = new Point(295, 260);
            }
            else
            {
                ShowSpiral();
                if (count_symbols < 20)
                {
                    PanelQuestion.Size = new Size(365, 50);
                    PanelQuestion.Location = new Point(2, 260);
                    CheckButton.Size = new Size(80, 32);
                    SaveButton.Size = new Size(80, 32);
                }
                else if (count_symbols < 50)
                {
                    PanelQuestion.Size = new Size(540, 50);
                    PanelQuestion.Location = new Point(2, 400);
                }
                else if (count_symbols < 100)
                {
                    PanelQuestion.Size = new Size(610, 50);
                    PanelQuestion.Location = new Point(2, 525);
                }
                else if (count_symbols < 170)
                {
                    PanelQuestion.Size = new Size(680, 50);
                    PanelQuestion.Location = new Point(2, 600);
                }
                else
                {
                    PanelQuestion.Size = new Size(1020, 50);
                    PanelQuestion.Location = new Point(2, 860);
                }

                CheckButton.Location = new Point(5, PanelQuestion.Location.Y + 60);
                SaveButton.Location = new Point(CheckButton.Location.X + CheckButton.Size.Width + 5, PanelQuestion.Location.Y + 60);
                SaveExitButton.Location = new Point(SaveButton.Location.X + SaveButton.Size.Width + 5, PanelQuestion.Location.Y + 60);
            }
            id_TB_hint = -1;
        }

        #region События для кнопок
        // Метод получения подсказки
        void Click_GetHintButton(object sender, EventArgs e)
        {
            if (id_TB_hint != -1)
            {
                foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                {
                    int current_id;
                    int.TryParse(string.Join("", textbox.Name.ToString().Where(c => char.IsDigit(c))), out current_id);
                    if (current_id == id_TB_hint)
                    {
                        string tmp = "";
                        foreach (var item in all_symbols)
                        {
                            for (int z = 0; z < item.Length; z++)
                            {
                                tmp += item[z];
                            }
                        }
                        char[] original_chars = tmp.ToCharArray();
                        textbox.Text = original_chars[current_id - 1].ToString();
                        id_TB_hint = -1;
                    }
                }

                cross.Hint--;
                if (count_symbols < 20)
                    HintLabel.Text = "Подсказки: " + cross.Hint;
                else
                    HintLabel.Text = "Осталось подсказок: " + cross.Hint;
                if (cross.Hint == 0)
                    GetHintButton.Enabled = false;
                UpdateProgress();
                SaveCrossword();
            }
        }

        // Метод проверки решения
        void Click_CheckButton(object sender, EventArgs e)
        {
            UpdateProgress();
            if (progress == 100)
            {
                MessageBox.Show("Поздравляем! Вы разгадали кроссворд!");
            }
            else
                MessageBox.Show("Прогресс: " + String.Format("{0:0.00}", progress) + "%");
        }

        // Метод сохранения прогресса
        void Click_SaveButton(object sender, EventArgs e)
        {
            UpdateProgress();
            SaveCrossword();
        }

        // Метод сохранения прогресса и выхода из формы разгадывания кроссворда
        void Click_SaveExitButton(object sender, EventArgs e)
        {
            open_next = true;
            UpdateProgress();
            SaveCrossword();
            this.Close();
        }
        #endregion

        // Метод обновления прогресса решения
        void UpdateProgress()
        {
            char[] current_chars = new char[count_symbols];
            char[] original_chars;
            int i = 0;
            double k = 0;
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                if (textbox.Text != "")
                {
                    current_chars[i] = textbox.Text[0];
                    current_chars[i] = Char.ToUpper(current_chars[i]);
                }

                else current_chars[i] = '\0';
                i++;
            }

            string tmp = "";
            foreach (var item in all_symbols)
            {
                for (int z = 0; z < item.Length; z++)
                {
                    tmp += item[z];
                }
            }
            original_chars = tmp.ToCharArray();

            for (int j = 0; j < count_symbols; j++)
            {
                if (current_chars[current_chars.Length - j - 1] == original_chars[j])
                {
                    k += 1;
                }
            }
            progress = 100 * (k / count_symbols);
            cross.Progress = progress;
        }

        // Сохранение кроссворда
        void SaveCrossword()
        {
            char[] current_chars = new char[count_symbols];
            int i = 0;
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                if (textbox.Text != "")
                    current_chars[i] = textbox.Text[0];
                else current_chars[i] = '\0';
                i++;
            }

            cross.AllSymbols = current_chars;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + login_name);
            FileStream stream = File.Create(Environment.CurrentDirectory + "\\" + login_name + "\\" + name_cross + ".cros");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, cross);
            stream.Close();
        }

        #region линейное отображение
        // Отображение линейного вида
        public void ShowLinear()
        {
            this.Size = new Size(710, 340);
            GetHintButton.Location = new Point(660, 7);
            HintLabel.Location = new Point(450, 10);
            GenericTextBox();
        }

        // Создание интерфейса линейного кроссворда
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
                            CharacterCasing = CharacterCasing.Upper,
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
                        CharacterCasing = CharacterCasing.Upper,
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
                textbox.GotFocus += TextBox_Focus;
            }
            FillingTextBox();
        }
        #endregion

        #region спиральное отображение
        // Отображение вида "Спираль"
        public void ShowSpiral()
        {
            GenericTextBox();
        }

        // Создание интерфейса спирального кроссворда
        void CreateTB_Spiral(int count_symbols)
        {
            bool ls = false;
            int prevX = 0, prevY = 0;
            this.Controls.Add(Panel1);

            if (count_symbols < 20)
            {
                this.Size = new Size(385, 400);
                Panel1.Size = new Size(385, 400);
                GetHintButton.Location = new Point(335, 7);
                HintLabel.Location = new Point(125, 10);
                prevX = 170;
                prevY = 100;
            }
            else if (count_symbols < 50)
            {
                this.Size = new Size(560, 540);
                Panel1.Size = new Size(560, 540);
                GetHintButton.Location = new Point(510, 7);
                HintLabel.Location = new Point(300, 10);
                prevX = 250;
                prevY = 170;
            }
            else if (count_symbols < 100)
            {
                this.Size = new Size(630, 670);
                Panel1.Size = new Size(630, 670);
                GetHintButton.Location = new Point(580, 7);
                HintLabel.Location = new Point(370, 10);
                prevX = 285;
                prevY = 250;
            }
            else if (count_symbols < 170)
            {
                this.Size = new Size(700, 750);
                Panel1.Size = new Size(700, 750);
                GetHintButton.Location = new Point(650, 7);
                HintLabel.Location = new Point(440, 10);
                prevX = 350;
                prevY = 300;
            }
            else
            {
                this.Size = new Size(1020, 1000);
                Panel1.Size = new Size(1020, 1000);
                GetHintButton.Location = new Point(970, 7);
                HintLabel.Location = new Point(760, 10);
                prevX = 500;
                prevY = 410;
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
                            Text = "",
                            Font = new Font("Areal", 16),
                            Size = new Size(30, 30),
                            BackColor = Color.Aqua,
                            Multiline = true,
                            CharacterCasing = CharacterCasing.Upper,
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
                        CharacterCasing = CharacterCasing.Upper,
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
                textbox.GotFocus += TextBox_Focus;
            }
            FillingTextBox();
        }
        #endregion

        #region отображение змейка
        // Отображение вида "Змейка"
        public void ShowSnake()
        {
            GenericTextBox();
        }

        // Создание интерфейса вида "Змейка"
        void CreateTB_Snake(int count_symbols)
        {
            bool ls = false;
            this.Controls.Add(Panel1);
            int width_cross = 0;
            if (count_symbols < 20)
            {
                width_cross = 9;
                this.Size = new Size(350, 330);
                Panel1.Size = new Size(350, 330);
                GetHintButton.Location = new Point(300, 7);
                HintLabel.Location = new Point(140, 10);
            }
            else if (count_symbols < 50)
            {
                width_cross = 16;
                this.Size = new Size(595, 330);
                Panel1.Size = new Size(595, 330);
                GetHintButton.Location = new Point(545, 7);
                HintLabel.Location = new Point(335, 10);
            }
            else if (count_symbols < 100)
            {
                width_cross = 17;
                this.Size = new Size(630, 470);
                Panel1.Size = new Size(630, 470);
                GetHintButton.Location = new Point(580, 7);
                HintLabel.Location = new Point(370, 10);
            }
            else if (count_symbols < 170)
            {
                width_cross = 20;
                this.Size = new Size(740, 610);
                Panel1.Size = new Size(740, 610);
                GetHintButton.Location = new Point(690, 7);
                HintLabel.Location = new Point(480, 10);
            }
            else
            {
                width_cross = 28;
                this.Size = new Size(1020, 610);
                Panel1.Size = new Size(1020, 610);
                GetHintButton.Location = new Point(970, 7);
                HintLabel.Location = new Point(760, 10);
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
                            CharacterCasing = CharacterCasing.Upper,
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
                        CharacterCasing = CharacterCasing.Upper,
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
                textbox.GotFocus += TextBox_Focus;
            }
            FillingTextBox();
        }
        #endregion

        // Заполнение текстбоксов символами, сохраненными при раннем разгадывании кроссворда
        void FillingTextBox()
        {
            if (!isNew)
            {
                char[] saved_symbols = cross.AllSymbols;
                int i = 0;
                foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
                {
                    if (saved_symbols[i] != '\0')
                        textbox.Text = saved_symbols[i].ToString();
                    i++;
                }
            }
        }

        // Заполнения списка AllSymbols символами, составляющими слова из кроссворда
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

        // Генерация текстбоксов
        void GenericTextBox()
        {
            // Записываем в список all_symbols слова в виде массивов символов + указываем в IndexWords индексы начала слов
            all_symbols = GetArrayCharAllSymbols();

            // Записываем в count_symbols количество всех символов исходных слов
            count_symbols = 0;
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

        // Получения определения для определенного слова
        private string GetDefinition(int id_TextBox)
        {
            PanelQuestion.Visible = true;
            int id = 0;
            string definition = "";
            int counter = 0;

            foreach (var item in IndexWords) //IndexWords = 1-6-7-8-11-12-13
            {
                if (item == id_TextBox && id_TextBox == 1)
                {
                    break;
                }
                else
                {
                    foreach (var item1 in IndexWords)
                    {
                        if (item1 == id_TextBox)
                        {
                            break;
                        }
                        else counter++;
                    }
                    counter--;
                    id = (int)(counter / cross_letters + 1);
                }
                counter = 0;
            }

            int[] arr_iw = new int[IndexWords.Count];

            int i = 0;
            foreach (var item in IndexWords)
            {
                arr_iw[i] = item;
                i++;
            }

            string suitable_word = words[id].ToUpper();
            string[] file = dictionary.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            string dict = Environment.CurrentDirectory + "\\" + file[file.Length - 1];
            using (StreamReader fs = new StreamReader(dict))
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

        #region События для текстбоксов
        private void TextBox_Focus(object sender, EventArgs e)
        {
            foreach (var textbox in TextBoxExtends.GetAllChildren(Panel1).OfType<TextBox>())
            {
                if (textbox.Focused)
                {
                    int.TryParse(string.Join("", textbox.Name.ToString().Where(c => char.IsDigit(c))), out id_TB_hint);
                }
            }
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
                        GetDefinitionByIDTextBox(textbox);
                    else if (index == 1)
                        GetDefinitionByIDTextBox(textbox);
                    else
                        GetDefinitionByIDTextBox(textbox);
                    break;
                }
            }
        }
        #endregion

        // Метод, определяющий, для какого слова необходимо отобразить определение
        void GetDefinitionByIDTextBox(TextBox textbox)
        {
            int id_TextBox;
            int.TryParse(string.Join("", textbox.Name.ToString().Where(c => char.IsDigit(c))), out id_TextBox);
            Question.Text = GetDefinition(id_TextBox);
        }

        // Событийный метод. Срабатывает при закрытии формы. Открывает форму авторизации
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MenuUser ifrm = new MenuUser(login_name);
            ifrm.Show();
        }
    }

    // Класс работы с текстбоксами
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
