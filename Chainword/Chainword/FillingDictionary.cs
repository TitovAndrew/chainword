using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Chainword
{
    public partial class FillingDictionary : Form
    {
        bool open_next = false;
        FileWorker fw;
        string writePath;
        List<string> all_concepts_list = new List<string>(); // Список всех понятий в словаре

        public FillingDictionary(string writePath)
        {
            this.writePath = writePath;
            InitializeComponent();
            FillAvailableWords();
            AddConcept_button.Enabled = false;
            DeleteConcept_button.Enabled = false;
            fw = new FileWorker();
            all_concepts_list.Clear();
            foreach (var item in AvailableWords.Items)
            {
                all_concepts_list.Add((string)item);
            }
        }

        // Добавляем в список все понятия, которые есть в словаре
        void FillAvailableWords()
        {
            using (StreamReader fs = new StreamReader(writePath))
            {
                string concept = null;
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    temp += "\n";
                    concept += temp;
                }
                if (concept != null)
                {
                    string[] arr_concepts = concept.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arr_concepts.Length; i++)
                    {
                        all_concepts_list.Add(arr_concepts[i]);
                    }
                    UpdateListBox(AvailableWords, all_concepts_list); // Обновляем листобкс
                }

            }
        }

        // Добавить определение
        private void AddConcept_button_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(AddWord_textBox.Text, "^[А-Яа-я]+$"))
            {
                MessageBox.Show("Слово должно состоять из кириллицы и не содержать пробелов");
            }
            else if (!Regex.IsMatch(AddDefinition_textBox.Text, "^[А-Яа-я\\s,-.:;?!]+$"))
            {
                MessageBox.Show("Определение должно состоять из кириллицы, пробелов и знаков препинания");
            }
            else
            {
                // Добавляем в список слова из листбокса и проверяем на совпдение
                List<string> added_words = new List<string>();
                foreach(var item in AvailableWords.Items)
                {
                    if (item.ToString().Split(' ')[0] == AddWord_textBox.Text.ToUpper())
                    {
                        MessageBox.Show("Такое понятие уже существует");
                        AddWord_textBox.Text = "Слово";
                        AddWord_textBox.ForeColor = System.Drawing.Color.Gray;
                        AddDefinition_textBox.Text = "Определение";
                        AddDefinition_textBox.ForeColor = System.Drawing.Color.Gray;
                        AddConcept_button.Enabled = false;
                        return;
                    }    
                }
                string new_concept = AddWord_textBox.Text.ToUpper() + " " + AddDefinition_textBox.Text;
                AvailableWords.Items.Add(new_concept);
                all_concepts_list.Add(new_concept);
                AddWord_textBox.Text = "Слово";
                AddWord_textBox.ForeColor = System.Drawing.Color.Gray;
                AddDefinition_textBox.Text = "Определение";
                AddDefinition_textBox.ForeColor = System.Drawing.Color.Gray;
                AddConcept_button.Enabled = false;
            }
        }

        static void SampleThreadMethod()
        {
            ProgressBar pb = new ProgressBar();
            pb.Show();
            pb.BringToFront();
        }

        // Удалить определение
        private void DeleteConcept_button_Click(object sender, EventArgs e)
        {
            List<string> tmp_list = new List<string>();
            string delete_concept = null; // Понятие, которое будем удалять
            foreach (var item in AvailableWords.SelectedItems)
            {
                delete_concept = (string)item;
            }
            // Ищем слово в списке и добавляем все слова в новый список, кроме того, что удаляем
            foreach (var item in all_concepts_list)
            {
                if (!delete_concept.Equals(item))
                {
                    tmp_list.Add(item);
                }
            }
            all_concepts_list.Clear();
            // Вовзращаем в наш список понятий, теперь не имея удаленного слова
            foreach (var item in tmp_list)
            {
                all_concepts_list.Add(item);
            }
            AvailableWords.Items.Clear();
            UpdateListBox(AvailableWords, all_concepts_list); // Обновляем листобкс
            DeleteConcept_button.Enabled = false;
            
        }

        void UpdateListBox(ListBox listBox, List<string> list)
        {
            Thread thread = new Thread(SampleThreadMethod);
            thread.Start();
            try
            {
                for (int i = 0; i < list.Count; i++)
                    listBox.Items.Add(list[i]);
            }
            catch
            {
                MessageBox.Show("Не удалось обновить список понятий");
            }
            thread.Abort();
        }

        // Поиск слова
        private void WordSearch_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
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

        private void AddWord_textBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (AddWord_textBox.ForeColor == System.Drawing.Color.Gray)
            {
                AddWord_textBox.Text = "";
                AddWord_textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void AddWord_textBox_Leave(object sender, EventArgs e)
        {
            if (AddWord_textBox.Text == "")
            {
                AddWord_textBox.Text = "Слово";
                AddWord_textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void AddDefinition_textBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (AddDefinition_textBox.ForeColor == System.Drawing.Color.Gray)
            {
                AddDefinition_textBox.Text = "";
                AddDefinition_textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void AddDefinition_textBox_Leave(object sender, EventArgs e)
        {
            if (AddDefinition_textBox.Text == "")
            {
                AddDefinition_textBox.Text = "Определение";
                AddDefinition_textBox.ForeColor = System.Drawing.Color.Gray;
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

        // Сортировка слов
        void SortingListBox(int x)
        {
            Thread thread = new Thread(SampleThreadMethod);
            if (AvailableWords.Items.Count > 500)
                thread.Start();

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
            if (AvailableWords.Items.Count > 500)
                thread.Abort();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            fw.SaveDictionary(writePath, all_concepts_list);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!open_next)
            {
                Form ma = new MenuAdmin();
                ma.ShowDialog();
            }
            else
            {
                Form ma = new MenuAdmin();
                ma.Show();
            }
        }

        private void SaveExit_button_Click(object sender, EventArgs e)
        {
            open_next = true;
            try
            {
                fw.SaveDictionary(writePath, all_concepts_list);
            }
            catch {
                MessageBox.Show("Ошибка сохранения");
            }
            this.Close();
        }

        private void AddWord_textBox_TextChanged(object sender, EventArgs e)
        {
            if (AddWord_textBox.ForeColor != System.Drawing.Color.Gray &&
                AddDefinition_textBox.ForeColor != System.Drawing.Color.Gray &&
                AddWord_textBox.Text.Length != 0 &&
                AddDefinition_textBox.Text.Length != 0)
            {
                AddConcept_button.Enabled = true;
            }
            else AddConcept_button.Enabled = false;
        }

        private void AvailableWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteConcept_button.Enabled = true;
        }

        private void AddDefinition_textBox_TextChanged(object sender, EventArgs e)
        {
            if (AddWord_textBox.ForeColor != System.Drawing.Color.Gray &&
                AddDefinition_textBox.ForeColor != System.Drawing.Color.Gray &&
                AddWord_textBox.Text.Length != 0 &&
                AddDefinition_textBox.Text.Length != 0)
            {
                AddConcept_button.Enabled = true;
            }
            else AddConcept_button.Enabled = false;
        }

        private void WordSearch_TextChanged(object sender, EventArgs e)
        {
            if (WordSearch.Text.Length == 0 && WordSearch.ForeColor == System.Drawing.Color.Black)
            {
                search_button_Click_1(sender, e);
            }
        }

        private void search_button_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(SampleThreadMethod);
            thread.Start();
            if (WordSearch.ForeColor == System.Drawing.Color.Gray || WordSearch.Text == "")
            {
                AvailableWords.Items.Clear();
                UpdateListBox(AvailableWords, all_concepts_list); // Обновляем листобкс
            }
            else
            {
                AvailableWords.Items.Clear();
                List<string> suitable_concepts_list = new List<string>();
                foreach (var item in all_concepts_list)
                {
                    string[] words = ((string)item).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (words[0].Contains(WordSearch.Text.ToUpper()))
                        suitable_concepts_list.Add(item);
                }
                AvailableWords.Items.Clear();
                UpdateListBox(AvailableWords, suitable_concepts_list); // Обновляем листобкс
            }
            thread.Abort();
        }
    }
}





