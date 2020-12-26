using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    // Класс задания параметров будущего кроссворда - первый этап создания кроссворда
    public partial class CreateCross : Form
    {
        bool open_next = false;

        // Конструктор класс, который инициализирует компоненты на форме + выдает список доступных словарей
        public CreateCross()
        {
            InitializeComponent();
            NameCross_textBox.TextChanged += NameCross_textBox_TextChanged;
            AvailableDictionary.SelectedIndexChanged += AvailableDictionary_SelectedIndexChanged;
            TypeCross_comboBox.SelectedIndex = 0;
            AmountLetters_comboBox.SelectedIndex = 0;
            LengthCross_comboBox.SelectedIndex = 7;
            ShowAllFiles(Environment.CurrentDirectory, "*.dict", AvailableDictionary);
            CreateCross_button.Enabled = false;
        }

        // Метод вывода всех достпуных словарей в comboBox
        void ShowAllFiles(string rootDirectory, string fileExtension, ComboBox files)
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

        // Событийный метод. Срабатывает при закрытии формы. Открывает форму авторизации
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!open_next)
            {
                Form ifrm = Application.OpenForms[0];
                ifrm.Show();
            }
        }

        // Кнопка создания кроссворда. Проверяет уникальность имени нового кроссворда, а также открывает форму заполнения кроссворда
        // Если стоит галочка "Сгенерировать автоматически", выполняет код в классе CreateCross
        private void CreateCross_button_Click(object sender, EventArgs e)
        {
            open_next = true;
            Thread thread = new Thread(SampleThreadMethod);
            thread.Start();

            string result_path = null; // Путь к выбранному словарю
            string[] f = Directory.GetFiles(Environment.CurrentDirectory, "*.dict"); // массив путей до файлов dict
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].Contains(AvailableDictionary.Text))
                {
                    result_path = f[i];
                }
            }
            if (!Regex.IsMatch(NameCross_textBox.Text, "^[A-Za-zА-Яа-я0-9_]+$"))
            {
                thread.Abort();
                MessageBox.Show("Имя кроссворда должно состоять из букв латинского, русского алфавита, цифр и нижнего подчеркивания");            
                open_next = false;
                return;
            }
            else if (checkBox1.Checked == false)
            {
                string writePath = Environment.CurrentDirectory + "\\" + NameCross_textBox.Text + ".cros";
                try
                {
                    using (StreamReader fs = new StreamReader(writePath))
                    { }
                    thread.Abort();
                    MessageBox.Show("Данный файл уже существует!");                 
                    open_next = false;
                    return;
                }
                catch
                {
                    Form ifrm = new FillingCross(
                        NameCross_textBox.Text,
                        result_path,
                        TypeCross_comboBox.SelectedIndex,
                        int.Parse(AmountLetters_comboBox.Text),
                        int.Parse(LengthCross_comboBox.Text));
                    ifrm.Show();
                    ifrm.BringToFront();
                    this.Close();
                }           
            }
            else if (checkBox1.Checked == true)
            {
                string writePath = Environment.CurrentDirectory + "\\" + NameCross_textBox.Text + ".cros";
                try
                {
                    using (StreamReader fs = new StreamReader(writePath))
                    { }
                    thread.Abort();
                    MessageBox.Show("Данный файл уже существует!");
                    open_next = false;
                    return;
                }
                catch
                {
                    AutoCreateCross acc = new AutoCreateCross(
                        NameCross_textBox.Text,
                        result_path, TypeCross_comboBox.SelectedIndex,
                        int.Parse(AmountLetters_comboBox.Text),
                        int.Parse(LengthCross_comboBox.Text));
                    acc.CreateCross();
                    Form ma = new MenuAdmin();
                    ma.Show();
                    this.Close();
                }
            }

            thread.Abort();
        }

        // Прогрессбар
        static void SampleThreadMethod()
        {
            ProgressBar pb = new ProgressBar();
            pb.ShowDialog();
            pb.BringToFront();
        }

        // Событийный метод. Возникает при изменения текста в поле ввода имени кроссворда
        // В зависимости от заполнения поля, задает кнопку создания кроссворда доступной или недоступной
        private void NameCross_textBox_TextChanged(object sender, EventArgs e)
        {
            if (AvailableDictionary.Text != "" && NameCross_textBox.Text != "")
            {
                CreateCross_button.Enabled = true;
            }
            else
            {
                CreateCross_button.Enabled = false;
            }
        }

        // Событийный метод. Возникает при выборе элемента из списка доступных словарей.
        // В зависимости от выбора словаря, задает кнопку создания кроссворда доступной или недоступной
        private void AvailableDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvailableDictionary.Text != "" && NameCross_textBox.Text != "")
            {
                CreateCross_button.Enabled = true;
            }
            else
            {
                CreateCross_button.Enabled = false;
            }
        }
    }
}
