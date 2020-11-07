using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Chainword
{
    public partial class FillingDictionary : Form
    {
        string writePath;
        List<string> all_concepts_list = new List<string>(); // Список всех понятий в словаре

        public FillingDictionary(string writePath)
        {
            this.writePath = writePath;
            InitializeComponent();
            FillAvailableWords(); // Добавляем в список все понятия, которые есть в словаре
        }

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
                    UpdateListBox(AvailableWords); // Обновляем листобкс
                }

            }
        }

        private void AddConcept_button_Click(object sender, EventArgs e)
        {
            // Добавляем понятия в листбокс и в список понятий
            string new_concept = AddWord_textBox.Text.ToUpper() + " " + AddDefinition_textBox.Text;
            AvailableWords.Items.Add(new_concept);
            all_concepts_list.Add(new_concept);
            AddWord_textBox.Text = "";
            AddDefinition_textBox.Text = "";
        }

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
            UpdateListBox(AvailableWords); // Обновляем листобкс
        }

        void UpdateListBox(ListBox listBox)
        {
            try
            {
                for (int i = 0; i < all_concepts_list.Count; i++)
                    listBox.Items.Add(all_concepts_list[i]);
            }
            catch
            {
                MessageBox.Show("Не удалось обновить список понятий");
            }

        }

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

        private void search_button_Click(object sender, EventArgs e)
        {
            AvailableWords.Items.Clear();
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

        private void Save_button_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in all_concepts_list)
                {
                    sw.WriteLineAsync(item);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void SaveExit_button_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in all_concepts_list)
                {
                    sw.WriteLineAsync(item);
                }
            }
            this.Close();
        }
    }
}





