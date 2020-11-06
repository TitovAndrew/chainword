using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainword
{
    class NameComparer : IComparer<string[]>
    {
        int check;

        public NameComparer(int check)
        {
            this.check = check;
        }

        public int Compare(string[] o1, string[] o2)
        {
            if (check == 0)
            {
                if (o1[0].Length > o2[0].Length)
                {
                    return 1;
                }
                else if (o1[0].Length < o2[0].Length)
                {
                    return -1;
                }
            }
            else if (check == 1)
            {
                if (o1[0].Length > o2[0].Length)
                {
                    return -1;
                }
                else if (o1[0].Length < o2[0].Length)
                {
                    return 1;
                }
            }
            else if (check == 2)
            {
                if (o1[0].CompareTo(o2[0]) > 0)
                {
                    return 1;
                }
                else if (o1[0].CompareTo(o2[0]) < 0)
                {
                    return -1;
                }
            }
            else
            {
                if (o1[0].CompareTo(o2[0]) > 0)
                {
                    return -1;
                }
                else if (o1[0].CompareTo(o2[0]) < 0)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
