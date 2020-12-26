using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    // Класс работы с файлами словарей
    class FileWorker
    {
        public bool IsNext;
        // Метод создания словаря
        public void CreateDictionary(string writePath, Form form)
        {
            try
            {
                using (StreamReader fs = new StreamReader(writePath))
                { }
                MessageBox.Show("Данный файл уже существует!");
                IsNext = false;
               
            }
            catch
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                { }
                IsNext = true;
                Form fd = new FillingDictionary(writePath);
                fd.Show();
                form.Close();            
            }
        }

        // Метод сохранения словаря
        public void SaveDictionary(string writePath, List<string> all_concepts_list)
        {
            File.WriteAllLines(writePath, all_concepts_list);
        }
    }
}
