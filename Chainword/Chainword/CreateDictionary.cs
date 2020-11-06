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
    public partial class CreateDictionary : Form
    {
        public CreateDictionary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, "^[A-Za-z0-9А-Яа-я_]+$"))
            {
                MessageBox.Show("Пароль должен состоять из латинских букв, цифр и нижнего подчеркивания");
            }
            else
            {
                string writePath = Environment.CurrentDirectory + "\\" + textBox1.Text + ".dict";
                try
                {
                    using (StreamReader fs = new StreamReader(writePath))
                    { }
                    MessageBox.Show("Данный файл уже существует!");
                }
                catch
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    { }
                    Form fd = new FillingDictionary();
                    fd.Show();
                    this.Close();
                }

            }
        }
    }
}
