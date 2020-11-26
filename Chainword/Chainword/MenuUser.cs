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
        string login_name;

        public MenuUser(string log)
        {
            InitializeComponent();
            Open_Button.Enabled = false;
            this.login_name = log;
            if (!Directory.Exists(Environment.CurrentDirectory + "\\" + login_name)) 
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + login_name);

            ShowAllFiles(Environment.CurrentDirectory, "*.cros", StartedCross_ListBox);
            ShowAllFiles(Environment.CurrentDirectory, "*.cros", NewCross_ListBox);
        }

        void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
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
            foreach (var item in dir.GetFiles())
            {
                if (item.ToString().Contains("cros"))
                    started_cross.Add(item.Name.ToString());
            }
            foreach (var lns in list_new_cross)
            {
                foreach (var item in started_cross)
                {
                    if (item != lns)
                    {
                        check = true;
                    }
                    else if(item == lns)
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
                arr_started_cross[z] = item.Split('.')[0];
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
                Form solving = new SolvingCrossword(f[0], login_name);
                solving.Show();
                this.Close();
            }
            foreach (var item in NewCross_ListBox.SelectedItems)
            {
                string file_name = (string)item;
                string[] f = Directory.GetFiles(Environment.CurrentDirectory, file_name + ".cros");
                Form solving = new SolvingCrossword(f[0], login_name);
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
