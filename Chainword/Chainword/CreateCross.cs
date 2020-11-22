using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class CreateCross : Form
    {
        public CreateCross()
        {
            InitializeComponent();
            NameCross_textBox.TextChanged += NameCross_textBox_TextChanged;
            AvailableDictionary.SelectedIndexChanged += AvailableDictionary_SelectedIndexChanged;
            TypeCross_comboBox.SelectedIndex = 0;
            AmountLetters_comboBox.SelectedIndex = 0;
            LengthCross_comboBox.SelectedIndex = 7;
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", AvailableDictionary);
            CreateCross_button.Enabled = false;
        }

        void ShowAllFiles(string rootDirectory, string fileExtension, ComboBox files)
        {
            string test = null;
            string[] f = Directory.GetFiles(rootDirectory, fileExtension); // массив путей до файлов dict
            for (int i = 0; i < f.Length; i++)
            {
                //разбиваем наш путь на части
                string[] path = f[i].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < path.Length; j++)
                {
                    test += path[j] + "\n";
                    if (path[j].Contains("dict"))// выбираем тот кусок раздробленного пути, где содержится dict
                    {
                        string[] result = { path[j].Split('.')[0] };//удаляем все после точки у файла и выводим лишь название
                        files.Items.AddRange(result);
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void CreateCross_button_Click(object sender, EventArgs e)
        {
            string result_path = null; // Путь к выбранному словарю
            string[] f = Directory.GetFiles(Environment.CurrentDirectory, "*.dict"); // массив путей до файлов dict
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].Contains(AvailableDictionary.Text))
                {
                    result_path = f[i];
                }
            }
            if (!Regex.IsMatch(NameCross_textBox.Text, "^[A-Za-zА-Яа-я0-9_]+$"))
            {
                MessageBox.Show("Имя кроссворда должно состоять из букв латинского, русского алфавита, цифр и нижнего подчеркивания");
            }
            else if (checkBox1.Checked == false)
            {
                Form ifrm = new FillingCross(NameCross_textBox.Text, result_path, TypeCross_comboBox.SelectedIndex, int.Parse(AmountLetters_comboBox.Text), int.Parse(LengthCross_comboBox.Text));
                ifrm.Show();
                this.Close();
            }
        }
        private void NameCross_textBox_TextChanged(object sender, EventArgs e)
        {
            if (AvailableDictionary.Text != "" && NameCross_textBox.Text != "")
            {
                CreateCross_button.Enabled = true;
            }
            else
            {
                CreateCross_button.Enabled = false;
            }
        }

        private void AvailableDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvailableDictionary.Text != "" && NameCross_textBox.Text != "")
            {
                CreateCross_button.Enabled = true;
            }
            else
            {
                CreateCross_button.Enabled = false;
            }
        }
    }
}
