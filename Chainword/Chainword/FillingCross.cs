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

        public FillingCross(string namecross, string dictionary, string typecross, int crossletters, int lengthcross)
        {
            TopMost = true;
            InitializeComponent();
            DeleteLastWord.Enabled = false;
            CreateCross_button.Enabled = false;
            WordSearch.Enter += new EventHandler(WordSearch_OnFocus);

            try
            {
                this.dictionary = dictionary;
                this.namecross = namecross;
                this.typecross = typecross;
                this.crossletters = crossletters;
                this.lengthcross = lengthcross;

                File_Reader();
            }
            catch
            {

            }
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
                last_chars = result[0].Substring(result[0].Length - 1);
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
                    if (tmp[0].CompareTo(last_chars[0]) == 0)
                        words += tmp;
                }
                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> arr_words_list = new List<string>();
                    string[] x = null;
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
                else MessageBox.Show("В словаре невозможно найти слово, начинающееся с буквы " + last_chars[0]);
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
                    if (AddedWords.Items.Count < 8)
                    {
                        if (tmp[0].CompareTo(first_chars[k - 1][3]) == 0)
                        {                                                     
                            words += tmp;
                        }
                    }
                    else
                    {
                        if (tmp[0].CompareTo(first_chars[k - 1][4]) == 0)
                        {                                                     
                            words += tmp;
                        }
                    }

                }
                string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> arr_words_list = new List<string>();
                string[] x = null;
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

                    //MessageBox.Show(last_word.Substring(last_word.Length - 1));
                    char[] f = (last_word.Substring(last_word.Length - 1)).ToCharArray();
                    if (AddedWords.Items.Count < 8)
                    {
                        if (tmp[0].CompareTo(f[0]) == 0)
                        {
                            words += tmp;
                        }
                    }
                    else
                    {
                        if (tmp[0].CompareTo(f[0]) != 0)
                        {
                            words += tmp;
                        }
                    }
                }

                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> arr_words_list = new List<string>();

                    for (int i = 0; i < arr_words.Length; i++)
                    {
                        if (arr_words[i].Contains(WordSearch.Text.ToUpper()))
                        {
                            arr_words_list.Add(arr_words[i]);
                        }
                    }
                    for (int i = 0; i < arr_words_list.Count; i++)
                        AvailableWords.Items.Add(arr_words_list[i]);
                }
                if (words.Length == 0)
                {
                    MessageBox.Show("Ошибка");
                    //string y = "Ошибка";
                }

            }
        }

        void WordSearch_OnFocus(object sender, System.EventArgs e)
        {
            WordSearch.Text = "";
        }
        
    }
}
