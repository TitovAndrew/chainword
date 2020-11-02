using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chainword
{
    public partial class CreateCross : Form
    {
        public CreateCross()
        {
            InitializeComponent();
            TypeCross_comboBox.SelectedIndex = 0;
            AmountLetters_comboBox.SelectedIndex = 0;
            LengthCross_comboBox.SelectedIndex = 7;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void CreateCross_button_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(NameCross_textBox.Text, "^[A-Za-zА-Яа-я0-9_]+$"))
            {
                MessageBox.Show("Имя кроссворда должно состоять из букв латинского, русского алфавита, цифр и нижнего подчеркивания");
            }
        }

        private void CreateCross_Load(object sender, EventArgs e)
        {
            checkBox1.Size = new Size(40, 40);
        }
    }
}
