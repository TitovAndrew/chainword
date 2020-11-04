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
        string path;

        string last_chars;
        string[] first_chars  = new string[20];
        int k = 0;

        public FillingCross(string temp)
        {

            InitializeComponent();
            DeleteLastWord.Enabled = false;
            CreateCross_button.Enabled = false;

            try
            {
                path = temp;
                File_Reader();
            }
            catch
            {

            }
        }

        void File_Reader()
        {
            AvailableWords.Items.Clear();
            using (StreamReader fs = new StreamReader(path))
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
                string[] result = { str.Split(' ')[0] };
                AddedWords.Items.AddRange(result);
                last_chars = result[0].Substring(result[0].Length - 1);
                first_chars[k] = result[0];
                k++;
            }

            AvailableWords.Items.Clear();
            using (StreamReader fs = new StreamReader(path))
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
                    AvailableWords.Items.AddRange(arr_words);
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
            using (StreamReader fs = new StreamReader(path))
            {
                string words = null;
                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";
                    if (tmp[0].CompareTo(first_chars[k-1][0]) == 0)
                        words += tmp;
                }             
                string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                AvailableWords.Items.AddRange(arr_words);
            }
            k--;
            AddedWords.Items.RemoveAt(AddedWords.SelectedIndex = AddedWords.Items.Count - 1); // удаляем последнее слово
            if (AddedWords.Items.Count == 0)
            {
                DeleteLastWord.Enabled = false;
                File_Reader();
            }
        }
    }
}
