using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainword
{
    class Crossword
    {
        private string name;
        private int length;
        private string[] allwords;
        private int id;
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

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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
