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
    public partial class RemoveWordForm : Form
    {
        public RemoveWordForm()
        {
            InitializeComponent();
        }

        private void RemoveWordForm_Load(object sender, EventArgs e)
        {
            // 초기 설정

            MeanListView.Items.Clear();
        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 데이터 관리 클래스에서 가져와서 ui에 초기화

            // 

            Word.Text = String.Empty;
        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            // 삭제
            if (string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            // 검색된 상태인지 ( 선택된 단어가 있는지) 검사

            // 확인 버튼이 설정되어 있는지(실수 방지용으로 확인 용 라디오버튼)

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 닫기
            DialogResult = DialogResult.Cancel;
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnFindWord_Click(sender, e);
            }
        }
    }
}
