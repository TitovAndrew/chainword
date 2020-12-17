using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        // Отобразить справку
        private void InfoSystem_button_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + "\\" + "userguide.html");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
}
