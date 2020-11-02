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
using System.Text.RegularExpressions;

namespace Chainword
{
    public partial class AuthorizationForm : Form
    {
        //private readonly char[] theCharacetrers = new[] { '&', '\\', '/', '!', '%', '#', '^', '(', ')', '?', '|', '~', '+', ' ', '{', '}', '*', ',', '[', ']', '$', ';', ':', '=' };

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void Entry_button_Click(object sender, EventArgs e)
        {
            bool check = true;
            bool checkadmin = true;
            string log = login.Text;
            string pas = password.Text;
            string writePath = Environment.CurrentDirectory + "\\" + "data_user.usr";

            try
            {
                using (StreamReader fs = new StreamReader(writePath))
                {
                    string login = "";
                    while (true)
                    {
                        string temp = fs.ReadLine();
                        if (temp == null) break;
                        temp += "\n";
                        login += temp;
                    }

                    string[] char_user = login.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < char_user.Length; i++)
                    {
                        string[] login1 = char_user[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (log == login1[0] && GetHash(pas) == login1[1])
                        {
                            if (log == "admin" && GetHash(pas) == login1[1])
                            {
                                checkadmin = true;
                                Form ma = new MenuAdmin();
                                ma.Show();
                                password.Text = "";
                                this.Hide();
                                break;
                            }
                            check = true;
                            break;
                        }
                        else
                        {
                            check = false;
                            checkadmin = false;
                        }

                    }
                    if (check)
                    {
                        Form mu = new MenuUser();
                        mu.Show();
                        password.Text = "";
                        this.Hide();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось авторизоваться");
            }
            if (!check && !checkadmin)
            {
                MessageBox.Show("Неправильно введен логин или пароль");
            }
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

            //if (log.IndexOfAny(theCharacetrers) != -1)
               // MessageBox.Show("Логин и пароль должны состоять из букв и цифр");
            if (log == "" || pas == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if (log.Length < 3 || log.Length > 15)
            {
                MessageBox.Show("Длина логина должна быть от 3 до 15 символов");
            }
            else if (pas.Length < 3 || pas.Length > 15)
            {
                MessageBox.Show("Длина пароля должна быть от 3 до 15 символов");
            }
            else if (!Regex.IsMatch(log, "^[A-Za-z0-9_]+$"))
            {
                MessageBox.Show("Логин должен состоять из латинских букв, цифр и нижнего подчеркивания");
            }
            else if (!Regex.IsMatch(pas, "^[A-Za-z0-9_]+$"))
            {
                MessageBox.Show("Пароль должен состоять из латинских букв, цифр и нижнего подчеркивания");
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
                            temp += "\n";
                            login += temp;
                        }

                        string x = null;
                        string[] char_user = login.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                        string[] result = new string[char_user.Length];
                        for (int i = 0; i < char_user.Length; i++)
                        {
                            string[] login1 = char_user[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            result[i] = login1[0];
                        }
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i].Equals(log))
                            {
                                check = false;
                                MessageBox.Show("Пользователь с данным логином уже существует");
                            }
                        }
                    }
                    if (check)
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLineAsync(data_user);
                        }
                }
                catch
                {
                    MessageBox.Show("Не удалось зарегистрироваться");
                }

                if (check)
                    MessageBox.Show("Вы зарегистрировались!");
            }
        }

        private void Info_button_Click(object sender, EventArgs e)
        {
            Form inf = new Info();
            inf.Show();
        }
    }
}
