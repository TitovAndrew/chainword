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
            TypeCross_comboBox.SelectedIndex = 0;
            AmountLetters_comboBox.SelectedIndex = 0;
            LengthCross_comboBox.SelectedIndex = 7;
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", comboBox2);
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
            for(int i = 0; i < f.Length; i++)
            {
                if (f[i].Contains(comboBox2.Text))
                    result_path = f[i];
            }
            MessageBox.Show(result_path);
            if (!Regex.IsMatch(NameCross_textBox.Text, "^[A-Za-zА-Яа-я0-9_]+$"))
            {
                MessageBox.Show("Имя кроссворда должно состоять из букв латинского, русского алфавита, цифр и нижнего подчеркивания");
            }
        }

        private void CreateCross_Load(object sender, EventArgs e)
        {
            checkBox1.Size = new Size(40, 40);
        }
    }
}
