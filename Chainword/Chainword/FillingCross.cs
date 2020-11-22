using System;
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
    public partial class FillingCross : Form
    {
        string dictionary;
        string name_cross;
        int cross_letters, length_cross, type_cross;

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
                Crossword cross = new Crossword();
                FileStream stream = File.OpenRead(PathToFile);
                BinaryFormatter formatter = new BinaryFormatter();
                cross = formatter.Deserialize(stream) as Crossword;
                stream.Close();

                this.dictionary = cross.Dictionary;
                this.name_cross = cross.Name;
                this.type_cross = cross.DisplayType;
                this.cross_letters = cross.CrossLetters;
                this.length_cross = cross.Length;
                LoadCrossword(cross.Allwords);
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить кроссворд!");
            }
            if (AddedWords.Items.Count >= cross_letters)
                AddWord.Enabled = false;
        }

        // Конструктор для создания кроссворда
        public FillingCross(string name_cross, string dictionary, int type_cross, int cross_letters, int length_cross)
        {
            TopMost = true;
            InitializeComponent();
            DeleteLastWord.Enabled = false;
            CreateCross_button.Enabled = false;
            if (AddedWords.Items.Count >= cross_letters)
                AddedWords.Enabled = false;

            try
            {
                this.dictionary = dictionary;
                this.name_cross = name_cross;
                this.type_cross = type_cross;
                this.cross_letters = cross_letters;
                this.length_cross = length_cross;

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

        private void LoadCrossword(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string str = (string)words[i];
                string[] result = { (AddedWords.Items.Count + 1) + ". " + str };
                AddedWords.Items.AddRange(result);
                last_chars = result[0].Substring(result[0].Length - 3);
                first_chars[k] = result[0];
                k++;
            }
            if (words.Length > 0)
            {
                DeleteLastWord.Enabled = true;
                CreateCross_button.Enabled = true;
            }
            UpdateAvailableWords();
        }

        private void UpdateAvailableWords()
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

                    if (cross_letters == 1)
                    {
                        if (tmp[0].CompareTo(last_chars[2]) == 0)
                            words += tmp;
                    }
                    else if (cross_letters == 2)
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
                    if (cross_letters == 1)
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с буквы " + last_chars[2]);
                    else if (cross_letters == 2)
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с букв " + last_chars[1] + last_chars[2]);
                    else
                        MessageBox.Show("В словаре невозможно найти слово, начинающееся с букв " + last_chars[0] + last_chars[1] + last_chars[2]);
                }
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
            UpdateAvailableWords();

            DeleteLastWord.Enabled = true;
            if (AvailableWords.Items.Count > 2)
                CreateCross_button.Enabled = true;
            if (AddedWords.Items.Count >= cross_letters)
                AddWord.Enabled = false;
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
                        if (cross_letters == 1)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][3]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else if (cross_letters == 2)
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
                        if (cross_letters == 1)
                        {
                            if (tmp[0].CompareTo(first_chars[k - 1][4]) == 0)
                            {
                                words += tmp;
                            }
                        }
                        else if (cross_letters == 2)
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
                CreateCross_button.Enabled = false;
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
                        if (cross_letters == 1)
                        {
                            if (tmp[0].CompareTo(f[2]) == 0)
                                words += tmp;
                        }
                        else if (cross_letters == 2)
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
            string[] words = GetWords();
            Crossword cross = new Crossword();
            cross.Name = name_cross;
            cross.Length = length_cross;
            cross.DisplayType = type_cross;
            cross.Dictionary = dictionary;
            cross.CrossLetters = cross_letters;
            cross.AddWords(words, words.Length);

            FileStream stream = File.Create(name_cross + ".cros");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, cross);
            stream.Close();

            Form ma = new MenuAdmin();
            ma.Show();
            this.Close();
        }

        private string[] GetWords()
        {
            string[] words_to_cross = new string[AddedWords.Items.Count];
            string[] x;
            int i = 0;
            foreach (var item in AddedWords.Items)
            {
                x = ((string)item).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                words_to_cross[i] = x[1];
                i++;
            }
            return words_to_cross;
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
