using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordMemory
{
    public partial class TestWordForm : Form
    {
        public TestWordForm()
        {
            InitializeComponent();
        }

        private void TestWordForm_Load(object sender, EventArgs e)
        {

            MeanListView.Items.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Word.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if(e.KeyChar == KEY_ENTER)
            {
                btnSubmit_Click(sender, e);
            }
        }
    }
}
