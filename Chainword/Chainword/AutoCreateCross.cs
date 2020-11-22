using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    class AutoCreateCross
    {
        string dictionary;
        string name_cross;
        int cross_letters, length_cross, type_cross;
        private Crossword cross;

        public AutoCreateCross(string name_cross, string dictionary, int type_cross, int cross_letters, int length_cross)
        {
            try
            {
                this.dictionary = dictionary;
                this.name_cross = name_cross;
                this.type_cross = type_cross;
                this.cross_letters = cross_letters;
                this.length_cross = length_cross;
                cross = new Crossword();
            }
            catch
            {
                MessageBox.Show("Не удалось создать кроссворд!");
            }

        }

        public void CreateCross()
        {
            string[] words = GetWords();
            Crossword cross = new Crossword();
            cross.Name = name_cross;
            cross.Length = length_cross;
            cross.DisplayType = type_cross;
            cross.Dictionary = dictionary;
            cross.CrossLetters = cross_letters;
            cross.AddWords(words, words.Length);

            FileStream stream = File.Create(name_cross + ".cros");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, cross);
            stream.Close();
        }

        public string[] GetWords()
        {
            int k = length_cross;
            string[] arr_words, arr_only_words;
            string only_words = "";
            Random rand = new Random((int)DateTime.Now.Ticks);
            using (StreamReader fs = new StreamReader(dictionary))
            {
                string words = null;
                while (true)
                {
                    string tmp = fs.ReadLine();
                    if (tmp == null) break;
                    tmp += "\n";
                    words += tmp;
                }
                arr_words = words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < arr_words.Length; j++)
                {
                    only_words += arr_words[j].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0] + "\n";
                }
                arr_only_words = only_words.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }


            string[] result = new string[length_cross];
            int i = 0;
            while (k > 0)
            {
                int index = rand.Next(0, arr_only_words.Length);
                if (i != 0)
                {
                    char[] f = result[i - 1].Substring(result[i - 1].Length - 1).ToCharArray();
                    while (arr_only_words[index][0] != f[0])
                    {
                        index = rand.Next(0, arr_only_words.Length);
                    }
                }
                result[i] = arr_only_words[index];
                i++;
                k--;
            }
            return result;
        }
    }
}
