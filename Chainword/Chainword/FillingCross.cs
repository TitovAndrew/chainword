using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class FillingCross : Form
    {
        string dictionary;
        string namecross, typecross;
        int crossletters, lengthcross;

        int check = 0;
        string last_chars;
        string[] first_chars = new string[20];
        int k = 0;

        // Конструктор для редактирования кроссвордов
        public FillingCross(string PathToFile)
        {
            TopMost = true;
            InitializeComponent();
            DeleteLastWord.Enabled = false;
            CreateCross_button.Enabled = false;

            try
            {
                // Тут надо будет инициализировать поля, взяв данные из файла .cros, который в параметре конструктора
                /*this.dictionary = dictionary;
                this.namecross = namecross;
                this.typecross = typecross;
                this.crossletters = crossletters;
                this.lengthcross = lengthcross;*/

                File_Reader();
            }
            catch { }
        }

        // Конструктор для создания кроссворда
        public FillingCross(string namecross, string dictionary, string typecross, int crossletters, int lengthcross)
        {
            TopMost = true;
            InitializeComponent();
            DeleteLastWord.Enabled = false;
            CreateCross_button.Enabled = false;

            try
            {
                this.dictionary = dictionary;
                this.namecross = namecross;
                this.typecross = typecross;
                this.crossletters = crossletters;
                this.lengthcross = lengthcross;

                File_Reader();
            }
            catch { }
        }

        void File_Reader()
        {
            AvailableWords.Items.Clear();
            using (StreamReader fs = new StreamReader(dictionary))
            {
                string words = null;
                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";
                    words += tmp;
                }
                string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                AvailableWords.Items.AddRange(arr_words);
            }
        }

        private void AddWord_Click(object sender, EventArgs e)
        {
            foreach (var item in AvailableWords.SelectedItems)
            {
                string str = (string)item;
                string[] result = { (AddedWords.Items.Count + 1) + ". " + str.Split(' ')[0] };
                AddedWords.Items.AddRange(result);
                last_chars = result[0].Substring(result[0].Length - 3);
                first_chars[k] = result[0];
                k++;
            }

            AvailableWords.Items.Clear();
            using (StreamReader fs = new StreamReader(dictionary))
            {
                string words = null;
                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";

                    if (crossletters == 1)
                    {
                        if (tmp[0].CompareTo(last_chars[2]) == 0)
                            words += tmp;
                    }
                    else if (crossletters == 2)
                    {
                        if (tmp[0].CompareTo(last_chars[1]) == 0 && tmp[1].CompareTo(last_chars[2]) == 0)
                            words += tmp;
                    }
                    else
                    {
                        if (tmp[0].CompareTo(last_chars[0]) == 0 && tmp[1].CompareTo(last_chars[1]) == 0 && tmp[2].CompareTo(last_chars[2]) == 0)
                            words += tmp;
                    }
                }
                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> arr_words_list = new List<string>();
                    string[] x;
                    for (int i = 0; i < arr_words.Length; i++)
                    {
                        foreach (var item in AddedWords.Items)
                        {
                            x = ((string)item).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (arr_words[i].Contains(x[1] + " "))
                            {
                                check++;
                            }
                        }
                        if (check == 0)
                        {
                            arr_words_list.Add(arr_words[i]);
                        }
                        check = 0;
                    }

                    for (int i = 0; i < arr_words_list.Count; i++)
                        AvailableWords.Items.Add(arr_words_list[i]);
                }
                else
                {
                    if (crossletters == 1)
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с буквы " + last_chars[2]);
                    else if (crossletters == 2)
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с букв " + last_chars[1] + last_chars[2]);
                    else
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с букв " + last_chars[0] + last_chars[1] + last_chars[2]);
                }

            }
            DeleteLastWord.Enabled = true;

            if (AvailableWords.Items.Count > 2)
            {
                CreateCross_button.Enabled = true;
            }
        }
        private void DeleteLastWord_Click(object sender, EventArgs e)
        {
            AvailableWords.Items.Clear();
            AddedWords.Items.RemoveAt(AddedWords.SelectedIndex = AddedWords.Items.Count - 1); // удаляем последнее слово
            using (StreamReader fs = new StreamReader(dictionary))
            {
                string words = null;

                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";
                    if (AddedWords.Items.Count < 9)
                    {
                        if (crossletters == 1)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][3]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else if (crossletters == 2)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][3]) == 0 &&
                                tmp[1].CompareTo(first_chars[k - 1][4]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][3]) == 0 &&
                                tmp[1].CompareTo(first_chars[k - 1][4]) == 0 &&
                                tmp[2].CompareTo(first_chars[k - 1][5]) == 0)
                            {
                                words += tmp;
                            }
                        }
                    }
                    else
                    {
                        if (crossletters == 1)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][4]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else if (crossletters == 2)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][4]) == 0
                                && tmp[1].CompareTo(first_chars[k - 1][5]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][4]) == 0 &&
                                tmp[1].CompareTo(first_chars[k - 1][5]) == 0 &&
                                tmp[2].CompareTo(first_chars[k - 1][6]) == 0)
                            {
                                words += tmp;
                            }
                        }
                    }
                }
                string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> arr_words_list = new List<string>();
                string[] x;
                for (int i = 0; i < arr_words.Length; i++)
                {
                    foreach (var item in AddedWords.Items)
                    {
                        x = ((string)item).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr_words[i].Contains(x[1] + " "))
                        {
                            check++;
                        }
                    }

                    if (check == 0)
                    {
                        arr_words_list.Add(arr_words[i]);
                    }
                    check = 0;
                }
                for (int i = 0; i < arr_words_list.Count; i++)
                    AvailableWords.Items.Add(arr_words_list[i]);
            }
            k--;

            if (AddedWords.Items.Count == 0)
            {
                DeleteLastWord.Enabled = false;
                File_Reader();
            }
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            AvailableWords.Items.Clear();
            using (StreamReader fs = new StreamReader(dictionary))
            {
                string words = null;
                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";

                    string last_word = null;
                    foreach (var item in AddedWords.Items)
                    {
                        last_word = (string)item;
                    }

                    if (last_word != null)
                    {
                        char[] f = (last_word.Substring(last_word.Length - 3)).ToCharArray();
                        if (crossletters == 1)
                        {
                            if (tmp[0].CompareTo(f[2]) == 0)
                                words += tmp;
                        }
                        else if (crossletters == 2)
                        {
                            if (tmp[0].CompareTo(f[1]) == 0 && tmp[1].CompareTo(f[2]) == 0)
                                words += tmp;
                        }
                        else
                        {
                            if (tmp[0].CompareTo(f[0]) == 0 && tmp[1].CompareTo(f[1]) == 0 && tmp[2].CompareTo(f[2]) == 0)
                                words += tmp;
                        }
                    }
                    else words += tmp;
                }

                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> arr_words_list = new List<string>();
                    string[] x;
                    for (int i = 0; i < arr_words.Length; i++)
                    {
                        foreach (var item in AddedWords.Items)
                        {
                            x = ((string)item).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (arr_words[i].Contains(x[1] + " "))
                            {
                                check++;
                            }
                        }
                        if (check == 0)
                        {
                            if (arr_words[i].Contains(WordSearch.Text.ToUpper()))
                            {
                                arr_words_list.Add(arr_words[i]);
                            }
                        }
                        check = 0;
                    }
                    for (int i = 0; i < arr_words_list.Count; i++)
                        AvailableWords.Items.Add(arr_words_list[i]);

                    if (arr_words_list.Count == 0)
                    {
                        MessageBox.Show("Нет подходящих вхождений");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void WordSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (WordSearch.ForeColor == System.Drawing.Color.Gray)
            {
                WordSearch.Text = "";
                WordSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void WordSearch_Leave(object sender, EventArgs e)
        {
            if (WordSearch.Text == "")
            {
                WordSearch.Text = "Поиск слова";
                WordSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                SortingListBox(2);
            else if (comboBox1.SelectedIndex == 1)
                SortingListBox(3);
            else if (comboBox1.SelectedIndex == 2)
                SortingListBox(0);
            else
                SortingListBox(1);
        }

        private void CreateCross_button_Click(object sender, EventArgs e)
        {

        }

        void SortingListBox(int x)
        {
            List<string[]> concept_definition = new List<string[]>();

            foreach (var item in AvailableWords.Items)
            {
                string str = (string)item;
                concept_definition.Add(new string[] { str.Split(' ')[0], str.Substring(str.IndexOf(' ') + 1) });
            }
            AvailableWords.Items.Clear();

            NameComparer nc = new NameComparer(x);

            concept_definition.Sort(nc);

            for (int i = 0; i < concept_definition.Count; i++)
                AvailableWords.Items.Add(concept_definition[i][0] + " " + concept_definition[i][1]);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
}
