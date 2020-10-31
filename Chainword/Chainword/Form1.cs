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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MinimizeBox = false;
        }

        private void entry_button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(log + " " + pas);
        }

        private readonly char[] theCharacetrers = new[] { '&', '\\', '/', '!', '%', '#', '^', '(', ')', '?', '|', '~', '+', ' ', '{', '}', '*', ',', '[', ']', '$', ';', ':', '=' };

        private void register_button_Click(object sender, EventArgs e)
        {
            string log = login.Text;
            string pas = password.Text;

            string a = " ";



            if (log.IndexOfAny(theCharacetrers) != -1)
            {
                MessageBox.Show("Логин и пароль должны состоять из букв и цифр");
            }
            else
            {
                string writePath = @"D:\4 курс\Программная инженерия\chainword\Chainword\data_user.usr";

                string data_user = log + " " + pas;
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLineAsync(data_user);
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

                MessageBox.Show("Вы зарегистрировались!");
            }
        }
    }
}
