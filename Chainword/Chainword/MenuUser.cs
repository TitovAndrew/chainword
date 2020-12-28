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
    // Класс меню игрока
    public partial class MenuUser : Form
    {
        string login_name;
        bool open_next = false;

        // Конструктор класса
        public MenuUser(string log)
        {
            InitializeComponent();
            Open_Button.Enabled = false;
            this.login_name = log;
            if (!Directory.Exists(Environment.CurrentDirectory + "\\" + login_name))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + login_name);

            try
            {
                ShowAllFiles(Environment.CurrentDirectory, "*.cros", StartedCross_ListBox);
                ShowAllFiles(Environment.CurrentDirectory, "*.cros", NewCross_ListBox);
            }
            catch
            {
                MessageBox.Show("Системные файлы пользователя повреждены.");
                this.Close();
                Application.Restart();
            }
        }

        // Отобразить список новых и начатых кроссвордов
        private void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
        {
            List<string> list_new_cross = new List<string>(); // все
            DirectoryInfo new_cross = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (var item in new_cross.GetFiles())
            {
                if (item.Name.ToString().Contains("cros"))
                    list_new_cross.Add(item.Name.ToString());
            }

            List<string> suitable_list_new_cross = new List<string>(); // реально новые
            List<string> started_cross = new List<string>(); // начатые
            bool check = true;
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\" + login_name);
            bool isStarted = false;
            foreach (var item in dir.GetFiles())
            {
                foreach (var lns in list_new_cross)
                {
                    if (item.ToString().Contains("cros") && item.Name.ToString() == lns)
                    {
                        isStarted = true;
                        break;
                    }
                    else isStarted = false;
                }
                if (isStarted)
                    started_cross.Add(item.Name.ToString());
                else
                {
                    string[] f = Directory.GetFiles(Environment.CurrentDirectory + "\\" + login_name, item.Name.ToString());
                    File.Delete(f[0]);
                }
            }
            foreach (var lns in list_new_cross)
            {
                foreach (var item in started_cross)
                {
                    if (item != lns)
                    {
                        check = true;
                    }
                    else if (item == lns)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    suitable_list_new_cross.Add(lns);
            }
            string[] suitable_arr_new_cross = new string[suitable_list_new_cross.Count];
            string[] arr_started_cross = new string[started_cross.Count];
            int k = 0;
            foreach (var item in suitable_list_new_cross)
            {
                suitable_arr_new_cross[k] = item.Split('.')[0];
                k++;
            }
            int z = 0;
            foreach (var item in started_cross)
            {
                Crossword cross = new Crossword();
                FileStream stream = File.OpenRead(Environment.CurrentDirectory + "\\" + login_name + "\\" + item);
                BinaryFormatter formatter = new BinaryFormatter();
                cross = formatter.Deserialize(stream) as Crossword;
                stream.Close();

                if (cross.Progress == 100)
                {
                    arr_started_cross[z] = item.Split('.')[0] + " (Завершен)";
                }
                else
                    arr_started_cross[z] = item.Split('.')[0] + " (" + String.Format("{0:0.00}", cross.Progress) + "%)";
                z++;
            }

            if (files.Name == "NewCross_ListBox") // Если кроссворд новый
            {
                files.Items.AddRange(suitable_arr_new_cross);
            }
            if (files.Name == "StartedCross_ListBox") // Если кроссворд начатый
            {
                files.Items.AddRange(arr_started_cross);
            }
        }

        // Событийный метод. Срабатывает при закрытии формы. Открывает форму меню администратора
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!open_next)
            {
                Form ifrm = Application.OpenForms[0];
                ifrm.Show();
            }
        }

        // Кнопка, открывающая выбранный кроссворд
        private void Open_Button_Click(object sender, EventArgs e)
        {
            open_next = true;
            foreach (var item in StartedCross_ListBox.SelectedItems)
            {
                string[] file_name = ((string)item).Split(' ');
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name[0] + ".cros");
                if (file_name[1].Contains("Завершен"))
                {
                    DialogResult result = MessageBox.Show(
                         "Вы полностью разгадали данный кроссворд.\nНачать разгадывать заново?",
                         "Сообщение",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information,
                         MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string[] fn = f[0].Split('\\');
                            string file_cross = fn[fn.Length - 1];
                            System.IO.File.Delete(Environment.CurrentDirectory + "\\" + login_name + "\\" + file_cross);
                        }
                        catch { return; }
                    }
                    else
                    {
                        open_next = false;
                        return;
                    }
                }
                Form solving = new SolvingCrossword(f[0], login_name);
                solving.Show();
                solving.BringToFront();
                this.Close();
            }
            foreach (var item in NewCross_ListBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".cros");
                Form solving = new SolvingCrossword(f[0], login_name);
                solving.Show();
                solving.BringToFront();
                this.Close();
            }
        }

        #region Методы запрета открытия сразу нескольких файлов 
        private void NewCross_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NewCross_ListBox.SelectedIndex != -1)
            {
                Open_Button.Enabled = true;
                StartedCross_ListBox.SelectedIndex = -1;
            }
        }

        private void StartedCross_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StartedCross_ListBox.SelectedIndex != -1)
            {
                Open_Button.Enabled = true;
                NewCross_ListBox.SelectedIndex = -1;
            }
        }
        #endregion
    }
}