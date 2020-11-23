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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            //TopMost = true;
            InitializeComponent();
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", Dictionary_listBox);
            ShowAllFiles(Environment.CurrentDirectory, "*.cros", CrossWord_listBox);
            Edit_button.Enabled = false;
            Delete_button.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.WindowState = FormWindowState.Normal;
        }

        void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
        {
            string test = null;
            string[] f = Directory.GetFiles(rootDirectory, fileExtension); // массив путей до файлов dict/cross
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
                    if (path[j].Contains("cros"))// выбираем тот кусок раздробленного пути, где содержится cros
                    {
                        string[] result = { path[j].Split('.')[0] };//удаляем все после точки у файла и выводим лишь название
                        files.Items.AddRange(result);
                    }
                }
            }
        }

        private void Create_button_Click_1(object sender, EventArgs e)
        {
            Form cd = new CreateDictionary();
            cd.Show();
            this.Hide();
        }

        private void Createcross_button_Click_1(object sender, EventArgs e)
        {
            Form cc = new CreateCross();
            cc.Show();
            this.Hide();
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {
            foreach (var item in Dictionary_listBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".dict");
                Form fd = new FillingDictionary(f[0]);
                fd.Show();
                this.Close();
            }
            foreach (var item in CrossWord_listBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".cros");
                Form fc = new FillingCross(f[0]);
                fc.Show();
                this.Close();
            }
            Edit_button.Enabled = false;
            Delete_button.Enabled = false;
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            foreach (var item in Dictionary_listBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".dict");
                File.Delete(f[0]);
            }
            Dictionary_listBox.Items.Clear();
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", Dictionary_listBox);
            foreach (var item in CrossWord_listBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".cros");
                File.Delete(f[0]);
            }
            CrossWord_listBox.Items.Clear();
            ShowAllFiles(Environment.CurrentDirectory, "*.cros", CrossWord_listBox);
            Edit_button.Enabled = false;
            Delete_button.Enabled = false;
        }

        private void CrossWord_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit_button.Enabled = true;
            Delete_button.Enabled = true;
        }

        private void Dictionary_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit_button.Enabled = true;
            Delete_button.Enabled = true;
        }
    }
}
