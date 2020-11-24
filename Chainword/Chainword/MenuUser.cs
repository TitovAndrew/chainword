using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class MenuUser : Form
    {
        public MenuUser()
        {
            InitializeComponent();
            Open_Button.Enabled = false;
            ShowAllFiles(Environment.CurrentDirectory, "*.cros", StartedCross_ListBox);
            ShowAllFiles(Environment.CurrentDirectory, "*.cros", NewCross_ListBox);
        }

        void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
        {
            string test = null;
            string[] f = Directory.GetFiles(rootDirectory, fileExtension); // массив путей до файлов cross
            for (int i = 0; i < f.Length; i++)
            {
                //разбиваем наш путь на части
                string[] path = f[i].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < path.Length; j++)
                {
                    test += path[j] + "\n";
                    if (path[j].Contains("cros"))// выбираем тот кусок раздробленного пути, где содержится cros
                    {
                        string[] result = { path[j].Split('.')[0] }; //удаляем все после точки у файла и выводим лишь название

                        Crossword cross = new Crossword();
                        FileStream stream = File.OpenRead(f[i]);
                        BinaryFormatter formatter = new BinaryFormatter();
                        cross = formatter.Deserialize(stream) as Crossword;
                        stream.Close();

                        if (cross.AllSymbols == null && files.Name == "NewCross_ListBox") // Если кроссворд новый
                        {
                            files.Items.AddRange(result);
                        }
                        if (cross.AllSymbols != null && files.Name == "StartedCross_ListBox") // Если кроссворд начатый
                        {
                            files.Items.AddRange(result);
                        }
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.WindowState = FormWindowState.Normal;
        }

        private void Open_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in StartedCross_ListBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".cros");
                Form solving = new SolvingCrossword(f[0]);
                solving.Show();
                this.Close();
            }
            
        }

        private void NewCross_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Open_Button.Enabled = true;
        }

        private void StartedCross_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Open_Button.Enabled = true;
        }
    }
}
