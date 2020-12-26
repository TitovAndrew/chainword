using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    // Класс пользовательских данных
    class UserData
    {
        // Метод хеширования пароля
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        // Авторизация
        public void AuthorizationUser(string writePath, string log, string pas, bool checkadmin, bool check, Form Menu, Form main)
        {
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
                                main.Hide();
                                checkadmin = true;
                                Form ma = new MenuAdmin();
                                ma.ShowDialog();
                                check = false;
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
                        main.Hide();
                        Form mu = new MenuUser(log);
                        mu.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось авторизоваться");
            }
            if (!check && !checkadmin)
            {
                MessageBox.Show("Не удалось авторизоваться. \nВведите корректные данные");
            }
        }

        // Создание нового пользователя
        public void CreateUser(string writePath, string login, string log, bool check, string data_user, Form Menu)
        {
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
}
