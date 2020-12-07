using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainword
{
    [Serializable]
    class Crossword
    {
        // Поля основываются на форме CreateCross
        private string login_user; // Первичный ключ - Будем сохранять инфу пользователя о кроссворде по login_user
        private string name; // Имя кроссворда
        private int length; // Длина кроссворда в словах

        private string[] allwords; // Массив всех слов
        // Добавил своего
        private int display_type; // Вид отображения
        private string dictionary; // Словарь
        private int cross_letters; // Количество букв в пересечении
        private char[] all_symbols;
        private int hint; // Подсказки
        private double progress;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public string[] Allwords
        {
            get
            {
                return allwords;
            }
        }

        public string LoginUser
        {
            get
            {
                return login_user;
            }
            set
            {
                login_user = value;
            }
        }

        public int DisplayType
        {
            get
            {
                return display_type;
            }
            set
            {
                display_type = value;
            }
        }

        public string Dictionary
        {
            get
            {
                return dictionary;
            }
            set
            {
                dictionary = value;
            }
        }

        public double Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
            }
        }

        public int CrossLetters
        {
            get
            {
                return cross_letters;
            }
            set
            {
                cross_letters = value;
            }
        }

        public char[] AllSymbols
        {
            get
            {
                return all_symbols;
            }
            set
            {
                all_symbols = value;
            }
        }

        public int Hint
        {
            get
            {
                return hint;
            }
            set
            {
                hint = value;
            }
        }

        public void AddWords(string[] words, int length)
        {
            allwords = new string[length];
            for (int i = 0; i < length; i++)
            {
                allwords[i] = words[i];
            }
        }
    }
}
