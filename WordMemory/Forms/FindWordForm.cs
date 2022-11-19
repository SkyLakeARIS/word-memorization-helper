using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemory.BindingData;

namespace WordMemory
{
    public partial class FindWordForm : Form
    {
        public FindWordForm()
        {
            InitializeComponent();
        }

        private void FindWordForm_Load(object sender, EventArgs e)
        {
            // 초기 세팅
            // 콤보 박스 데이터 바인드
            WordClassCombo.DataSource = WordClassData.DataList;
            WordClassCombo.DisplayMember = "WordClassName";
            WordClassCombo.ValueMember = "WordClassName";


            // 리스트 뷰 초기화 
            // 빈 데이터가 하나 들어있는 상태이기 때문에 나중에 일일이 처리해줄바에
            // 비우는게 좋음.
            MeanListView.Items.Clear();

        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 검색 시작

            // 해시 테이블에서 찾아서 데이터들 초기화

            // 안내 메세지
            MessageBox.Text = "단어 이름을 제외한 나머지 내용만 수정시 반영됩니다.";
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(InputMean.Text) || string.IsNullOrWhiteSpace(InputMean.Text))
            {
                MessageBox.Text = "뜻을 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            if(WordClassCombo.SelectedIndex == -1 || WordClassData.DataList[WordClassCombo.SelectedIndex].WordClassType == eWordClass.NULL)
            {
                MessageBox.Text = "품사를 선택해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            // 수정 : 뜻 추가

            string wordClassString = WordClassData.DataList[WordClassCombo.SelectedIndex].WordClassName;
            string meanString = $"({wordClassString[0]}){InputMean.Text}";

            MeanListView.BeginUpdate();

            MeanListView.Items.Add(meanString);

            MeanListView.EndUpdate();

            InputMean.Text = string.Empty;
            WordClassCombo.SelectedIndex = 0;
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnFindWord_Click(sender, e);
            }
        }

        private void btnModifyWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (MeanListView.Items.Count <= 0)
            {
                MessageBox.Text = "뜻이 하나 이상 존재해야 합니다.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 데이터가 변경된 것이 있는지 체크. 

            // 단어명은 체크하지 않는다. (그렇다면 입력되서 변경된 단어 이름을 따로 알아낼 방법 고려)

            // 변경되었으면 더티비트 체크
        }

        private void InputMean_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnAddMean_Click(sender, e);
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
