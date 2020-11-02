using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class FillingCross : Form
    {
        public FillingCross(string temp)
        {
            InitializeComponent();
            label1.Text = temp;
        }
    }
}
