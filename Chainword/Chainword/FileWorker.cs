using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    class FileWorker
    {
        //Создание словаря
        public void CreateDictionary(string writePath, Form form)
        {
            try
            {
                using (StreamReader fs = new StreamReader(writePath))
                { }
                MessageBox.Show("Данный файл уже существует!");
            }
            catch
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                { }
                Form fd = new FillingDictionary(writePath);
                fd.Show();
                form.Close();
            }
        }

        //Сохранение словаря
        public void SaveDictionary(string writePath, List<string> all_concepts_list)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.UTF8))
            {
                foreach (var item in all_concepts_list)
                {
                    sw.WriteLineAsync(item);
                }
            }
        }
    }
}
