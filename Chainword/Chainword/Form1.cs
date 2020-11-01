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
using System.Security.Cryptography;

namespace Chainword
{
    public partial class Form1 : Form
    {
        private readonly char[] theCharacetrers = new[] { '&', '\\', '/', '!', '%', '#', '^', '(', ')', '?', '|', '~', '+', ' ', '{', '}', '*', ',', '[', ']', '$', ';', ':', '=' };

        public Form1()
        {
            InitializeComponent();
            MinimizeBox = false;
        }

        private void Entry_button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(log + " " + pas);
        }

        string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            bool check = true;
            string log = login.Text;
            string pas = password.Text;

            if (log.IndexOfAny(theCharacetrers) != -1)
                MessageBox.Show("Логин и пароль должны состоять из букв и цифр");
            else if(log == "" || pas == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                string writePath = Environment.CurrentDirectory + "\\" + "data_user.usr";

                string login = "";

                string data_user = log + " " + GetHash(pas);
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        
                    }
                    using (StreamReader fs = new StreamReader(writePath))
                    {
                        while (true)
                        {
                            string temp = fs.ReadLine();
                            if (temp == null) break;
                            login += temp;
                        }
                        // Надо будет разделить строку на пробелы, удалить четные элементы, а потом проверять
                        MessageBox.Show(login);
                        if (login.Contains(log + " "))
                        {
                            MessageBox.Show("Пользователь с данным логином уже существует");
                            check = false;
                        }
                    }
                    if (check)
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLineAsync(data_user);
                        }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

                if (check)
                    MessageBox.Show("Вы зарегистрировались!");
            }
        }
    }
}
