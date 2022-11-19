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
 
    public partial class AddWordForm : Form
    {

        //public const WordClassData[] WordClassTypes = new WordClassData[8] {
        //WordClassData(eWordClass.NOUN, "명사" ),
        //WordClassData(eWordClass.VERB, "동사" ),
        //WordClassData(eWordClass.ADJECTIVE, "형용사" ),
        //WordClassData(eWordClass.PREPOSITION, "전치사" ),
        //WordClassData(eWordClass.CONJUNCTION, "접속사" ),
        //WordClassData(eWordClass.PRONOUN, "대명사" ),
        //WordClassData(eWordClass.INTERJECTION, "감탄사" )
        //};
        private WordClassData mSelectedWorldClass;

        public AddWordForm()
        {
            InitializeComponent();
        }

        private void AddWordForm_Load(object sender, EventArgs e)
        {
            // 초기 세팅 
            // 메세지나 그런 안내문자 그리고 기본 값 세팅

            // 콤보 박스 데이터 바인드
            WordClassCombo.DataSource = WordClassData.DataList;
            WordClassCombo.DisplayMember = "WordClassName";
            WordClassCombo.ValueMember = "WordClassName";

            // 리스트 뷰 초기화 
            // 빈 데이터가 하나 들어있는 상태이기 때문에 나중에 일일이 처리해줄바에
            // 비우는게 좋음.
            MeanListView.Items.Clear();
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
            string inputMean = InputMean.Text;
            if(String.IsNullOrEmpty(inputMean) || String.IsNullOrWhiteSpace(inputMean))
            {
                MessageBox.Text = "뜻을 입력해주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if(mSelectedWorldClass.WordClassType == eWordClass.NULL)
            {
                MessageBox.Text = "품사를 설정해주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            MeanListView.BeginUpdate();

            string meanString = $"({mSelectedWorldClass.WordClassName[0]}){inputMean}";
            MeanListView.Items.Add(meanString);

            MeanListView.EndUpdate();

            mSelectedWorldClass = null;
            InputMean.Text = string.Empty;
            WordClassCombo.SelectedIndex = 0;

            MessageBox.Text = "잘못 추가했다면 리스트 항목을 더블클릭하여 제거할 수 있습니다.";
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void WordClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox wordClass = sender as ComboBox;
            // eWordClass와 같은 정수 값과 매칭되도록 ComboBox를 설정.
            if(wordClass.SelectedIndex == -1)
            {
                MessageBox.Text = "품사가 선택되지 않았습니다.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 선택한 품사 데이터를 저장해서 뜻 추가할 때 문자열로 만들 것.
            mSelectedWorldClass = WordClassData.DataList[wordClass.SelectedIndex];
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            // 입력 값 체크

            // 단어 입력 검사
            if(string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력하세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 영어인지 체크. 정규식
            if(true)
            {

            }

            // 뜻 체크
            if(MeanListView.Items.Count <= 0)
            {
                MessageBox.Text = "뜻을 하나 이상 등록하세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 단어 추가 및 파일 생성
            
            // 파일을 처리하는 클래스를 만드는것도..file Manager : 파일 생성, 삭제, 갱신, 데이터 임포트, 익스포트
            
            // 리스트에서 제거 확인 코드
            MeanListView.BeginUpdate();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in MeanListView.Items)
            {
                stringBuilder.AppendLine(item.ToString());

            }
            MeanListView.EndUpdate();
            MessageBox.Text = stringBuilder.ToString();
            MessageBox.ForeColor = System.Drawing.Color.Black;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            return;
        }

        private void MeanListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MeanListView.SelectedItems.Count <= 0)
            {
                return;
            }

            string selectedData = $"제거됨 : {MeanListView.SelectedItems[0].Text}.";

            MeanListView.BeginUpdate();

            MeanListView.SelectedItems[0].Remove();

            MeanListView.EndUpdate();

            MessageBox.Text = selectedData;
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void InputMean_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnAddMean_Click(sender, e);
            }
        }
    }
}
