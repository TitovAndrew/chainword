using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chainword
{
    public partial class FillingDictionary : Form
    {
        public FillingDictionary()
        {
            InitializeComponent();
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
                concept_definition.Add(new string[] { str.Split(' ')[0], str.Substring(str.IndexOf(' ')) });
            }
            AvailableWords.Items.Clear();

            NameComparer nc = new NameComparer(x);

            concept_definition.Sort(nc);

            for (int i = 0; i < concept_definition.Count; i++)
                AvailableWords.Items.Add(concept_definition[i][0] + " " + concept_definition[i][1]);
        }

        private void AddWord_Click(object sender, EventArgs e)
        {

        }
    }
}





