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
            string[] arr_words, arr_only_words, result = null;
            string only_words = "";
            Random rand = new Random((int)DateTime.Now.Ticks);

            #region получаем в массив arr_only_words все слова, которые есть в словаре
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
            #endregion

            #region Сам процесс получения рандомных слов из arr_only_words в массив result
            try
            {
                result = new string[length_cross];
                int i = 0;
                while (i < length_cross)
                {
                    int index = rand.Next(0, arr_only_words.Length);
                    if (i != 0)
                    {
                        // Вернет список с подходящими словами
                        List<string> sw =
                                SearchWordsMask(arr_only_words, result[i - 1].Substring(result[i - 1].Length - cross_letters).ToCharArray());
                        if (!sw.Any())
                            i -= 2;
                        else
                        {
                            string[] arr_sw = new string[sw.Count];
                            int k = 0;
                            foreach (var item in sw)
                            {
                                arr_sw[k] = item;
                                k++;
                            }
                            index = rand.Next(0, arr_sw.Length);
                            result[i] = arr_sw[index];
                        }
                    }
                    if (i == 0)
                        result[i] = arr_only_words[index];
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось составить кроссворд из данного словаря автоматически! Попробуйте составить вручную.");
            }
            #endregion

            return result;
        }

        private List<string> SearchWordsMask(string[] arr_only_words, char[] letters)
        {
            List<string> suitable_words = new List<string>();
            for (int i = 0; i < arr_only_words.Length; i++)
            {
                if (cross_letters == 1)
                {
                    if (arr_only_words[i][0] == letters[0])
                    {
                        suitable_words.Add(arr_only_words[i]);
                    }
                }
                else if(cross_letters == 2)
                {
                    if (arr_only_words[i][0] == letters[0] && 
                        arr_only_words[i][1] == letters[1])
                    {
                        suitable_words.Add(arr_only_words[i]);
                    }
                }
                else
                {
                    if (arr_only_words[i][0] == letters[0] && 
                        arr_only_words[i][1] == letters[1] && 
                        arr_only_words[i][2] == letters[2])
                    {
                        suitable_words.Add(arr_only_words[i]);
                    }
                }
            }
            return suitable_words;
        }
    }
}

