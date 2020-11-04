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
            InitializeComponent();
            Dictionary_listBox.MouseDoubleClick += new MouseEventHandler(Dictionary_listBox_DoubleClick);

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        /*private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Text = "New Name";
        }*/

        private void Dictionary_listBox_DoubleClick(object sender, EventArgs e)
        {
            if (Dictionary_listBox.SelectedItem != null)
            {
                MessageBox.Show(Dictionary_listBox.SelectedItem.ToString());
            }
        }

        void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
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

        private void Download_button_Click(object sender, EventArgs e)
        {
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", Dictionary_listBox);
        }

        private void Createcross_button_Click(object sender, EventArgs e)
        {
            Form cc = new CreateCross();
            cc.Show();
            this.Hide();
        }
    }
}
