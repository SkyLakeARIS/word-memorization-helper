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
    public partial class TestMeanForm : Form
    {
        public TestMeanForm()
        {
            InitializeComponent();
        }

        private void TestMeanForm_Load(object sender, EventArgs e)
        {
            MeanListView.Items.Clear();
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
            // 뜻 추가
            MeanListView.BeginUpdate();

            MeanListView.Items.Add(InputMean.Text);

            MeanListView.EndUpdate();

            InputMean.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(MeanListView.Items.Count <= 0)
            {
                MessageBox.Text = "뜻을 하나 이상 등록하세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 제출 후, list view에 있는 뜻 문자열과 문제 단어에서 불러온 데이터와 비교.
            InputMean.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void InputMean_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnAddMean_Click(sender, e);
                MessageBox.Text = $"pressed enter : {e.KeyChar.ToString()}";
            }
        }

        private void MeanListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MeanListView.SelectedItems.Count <= 0)
            {
                return;
            }
            string selectedData = $"제거됨 : {MeanListView.SelectedItems[0].Text}.";

            MeanListView.BeginUpdate();

            MeanListView.Items.Remove(MeanListView.SelectedItems[0]);

            MeanListView.EndUpdate();
            MessageBox.Text = selectedData;
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

    }
}
