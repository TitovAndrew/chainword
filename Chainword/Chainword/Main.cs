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
        UserData ud;
        public AuthorizationForm()
        {
            InitializeComponent();
            ud = new UserData();
        }
        private void Entry_button_Click(object sender, EventArgs e)
        {
            bool check = true;
            bool checkadmin = true;
            string log = login.Text;
            string pas = password.Text;
            string writePath = Environment.CurrentDirectory + "\\" + "data_user.usr";
            if(login.Text.Length == 0 || password.Text.Length == 0)
            {
                MessageBox.Show("Для авторизации необходимо заполнить оба поля");
                return;
            }
            AuthorizationForm menu = this;
            ud.AuthorizationUser(writePath, log, pas, checkadmin, check, menu, this);
            password.Text = "";
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            bool check = true;
            string log = login.Text;
            string pas = password.Text;

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

                string data_user = log + " " + ud.GetHash(pas);
                AuthorizationForm menu = this;
                ud.CreateUser(writePath, login, log, check, data_user, menu);
            }
        }

        private void Info_button_Click(object sender, EventArgs e)
        {
            Form inf = new Info();
            inf.Show();
        }
    }
}
