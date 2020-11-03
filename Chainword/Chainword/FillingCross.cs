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
        public FillingCross(string temp)
        {
            InitializeComponent();
            try
            {
                path = temp;
                using (StreamReader fs = new StreamReader(temp))
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
            catch
            {

            }
        }

        private void AddWord_Click(object sender, EventArgs e)
        {
            string last_char = null;
            foreach (var item in AvailableWords.SelectedItems)
            {
                string str = (string)item;
                string[] result = { str.Split(' ')[0] };
                AddedWords.Items.AddRange(result);
                last_char = result[0].Substring(result[0].Length - 1);
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
                    if (tmp[0].CompareTo(last_char[0]) == 0)
                        words += tmp;
                }
                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    AvailableWords.Items.AddRange(arr_words);
                }
                else MessageBox.Show("В словаре невозможно найти слово, начинающееся с буквы " + last_char[0]);
            }
        }

        private void DeleteLastWord_Click(object sender, EventArgs e)
        {
            //AddedWords.SelectedIndex = AddedWords.Items.Count - 2;
            string last_char = null;
            foreach (var item in AddedWords.SelectedItems)
            {
                string str = (string)item;
                string[] result = { str.Split(' ')[0] };
                AddedWords.Items.AddRange(result);
                last_char = result[0].Substring(result[0].Length - 1);
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
                    if (tmp[0].CompareTo(last_char[0]) == 0)
                        words += tmp;
                }
                if (words != null)
                {
                    string[] arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    AvailableWords.Items.AddRange(arr_words);
                }
                else MessageBox.Show("В словаре невозможно найти слово, начинающееся с буквы " + last_char[0]);
            }

            AddedWords.Items.RemoveAt(AddedWords.SelectedIndex = AddedWords.Items.Count - 1); // удаляем последнее слово

        }
    }
}
