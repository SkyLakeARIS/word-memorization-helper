using System;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;
using WordMemory.Data;
using Timer = System.Windows.Forms.Timer;
using WMPLib;


namespace WordMemory
{
    public partial class MainForm : Form
    {
	    private WordData mFirstData = null;
	    private WordData mSecondData = null;

        private Timer mWordRefreshTimer = null;
        private WindowsMediaPlayer mAudioPlayer = null;
        

	    public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 초기 설정
            mAudioPlayer = new WMPLib.WindowsMediaPlayer();
            mAudioPlayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(onAudioPlayerStateChange);

            mWordRefreshTimer = new Timer();
            mWordRefreshTimer.Interval = Setting.GetRefreshTimeMilliseconds();
            mWordRefreshTimer.Tick += new EventHandler(btnRefreshWord_Click);
            mWordRefreshTimer.Enabled = true;

            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "";
            header1.Name = "Mean";
            header1.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;
            MeanListViewFirst.View = View.Details;
            MeanListViewFirst.Columns.Add(header1);
            MeanListViewFirst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "";
            header2.Name = "Mean";
            header2.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;

            MeanListViewSecond.View = View.Details;
            MeanListViewSecond.Columns.Add(header2);
            MeanListViewSecond.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            btnRefreshWord_Click(this, null);
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
	        mWordRefreshTimer.Stop();

            AddWordForm addWordForm = new AddWordForm();

            DialogResult result = addWordForm.ShowDialog();
            if (result == DialogResult.OK)
            {
	            btnRefreshWord_Click(this, null);
            }

            addWordForm.Close();
            mWordRefreshTimer.Start();
        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
	        mWordRefreshTimer.Stop();

            FindWordForm findWordForm = new FindWordForm();

            DialogResult result = findWordForm.ShowDialog();
            if (result == DialogResult.OK)
            {
	            btnRefreshWord_Click(this, null);
            }
            findWordForm.Close();
            mWordRefreshTimer.Start();

        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
	        mWordRefreshTimer.Stop();

            RemoveWordForm removeWordForm = new RemoveWordForm();

            DialogResult result = removeWordForm.ShowDialog();
            if (result == DialogResult.OK)
            {
	            btnRefreshWord_Click(this, null);
            }

            removeWordForm.Close();

            mWordRefreshTimer.Start();

        }

        private void btnTestWord_Click(object sender, EventArgs e)
        {
	        mWordRefreshTimer.Stop();

            TestForm testForm = new TestForm();

            testForm.ShowDialog();
            testForm.Close();

            mWordRefreshTimer.Start();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            mWordRefreshTimer.Stop();
            DialogResult result = settingForm.ShowDialog();
            if (DialogResult.Cancel == result)
            {
                settingForm.Close();
                // 타이머 값이 변경되었으면 타이머 업데이트.
                if (Setting.GetRefreshTimeMilliseconds() != (Int32)mWordRefreshTimer.Interval)
                {
                    // 현재 타이머에 남은 시간이 새로 바뀐 타이머 간격보다 짧으면 다음 간격에 새로운 값이 반영되고,
                    // 그렇지 않으면(남은 시간이 더 길면) 새로운 타이머 시간으로 변경하도록 하고 싶은데
                    // 남은 시간을 관리 할 수 있도록 따로 기능을 만들어야 할 듯.
                    mWordRefreshTimer.Interval = Setting.GetRefreshTimeMilliseconds();
                }
            }
            mWordRefreshTimer.Start();
        }

        private void btnRefreshWord_Click(object sender, EventArgs e)
        {

            switch (Setting.ViewMode)
	        {
		        case EViewMode.SHOW_ONLY_NOT_REMEMBER:
		        {
			        mFirstData = WordManager.GetWodDataOrNullBy(ERememberType.NOT_REMEMBER);
			        mSecondData = WordManager.GetWodDataOrNullBy(ERememberType.NOT_REMEMBER);
			        break;
		        }
		        case EViewMode.SHOW_ONLY_REMEMBER:
		        {
			        mFirstData = WordManager.GetWodDataOrNullBy(ERememberType.REMEMBER);
			        mSecondData = WordManager.GetWodDataOrNullBy(ERememberType.REMEMBER);
			        break;
		        }

		        case EViewMode.SHOW_MIXED:
		        {
			        mFirstData = WordManager.GetWodDataOrNullBy(ERememberType.NOT_REMEMBER);
			        mSecondData = WordManager.GetWodDataOrNullBy(ERememberType.REMEMBER);
			        // 암기된 단어가 없으면 미암기 데이터로 표기.
			        if (mSecondData == null)
			        {
				        mSecondData = WordManager.GetWodDataOrNullBy(ERememberType.NOT_REMEMBER);
			        }
			        break;
		        }
		        default:
			        Debug.Assert(false, $"잘못된 ViewMode 데이터입니다. {Setting.ViewMode}");
			        break;
	        }

            // 추가된 데이터가 없을 경우. (혹은 표시할 데이터가 없을 경우.)
            if (mFirstData == null)
            {
	            WordFirst.Text = string.Empty;
	            MeanListViewFirst.BeginUpdate();
	            MeanListViewFirst.Items.Clear();
	            MeanListViewFirst.EndUpdate();
	            MemoFirst.Text = string.Empty;
	            rbtnNotRememberFirst.Checked = false;
	            rbtnRememberFirst.Checked = false;
	            return;
            }

            // 같은 데이터이면 하나 제거.
            if (mFirstData.WordName.Equals(mSecondData.WordName))
            {
	            mSecondData = null;
            }

            // 첫번째 단어 UI로 데이터 갱신
            WordFirst.Text = mFirstData.WordName;
            MeanListViewFirst.BeginUpdate();
            MeanListViewFirst.Items.Clear();
            foreach (string mean in mFirstData.MeanList)
            {
	            MeanListViewFirst.Items.Add(mean);
            }
            MeanListViewFirst.EndUpdate();
            MemoFirst.Text = mFirstData.Memo;

            if (mFirstData.RememberType == ERememberType.REMEMBER)
            {
	            rbtnRememberFirst.Checked = true;
            }
            else
            {
	            rbtnNotRememberFirst.Checked = true;
            }

            // 표시할 데이터가 없을 경우.
            if (mSecondData == null)
            {
	            WordSecond.Text = string.Empty;
	            MeanListViewSecond.BeginUpdate();
	            MeanListViewSecond.Items.Clear();
	            MeanListViewSecond.EndUpdate();
	            MemoSecond.Text = string.Empty;
	            rbtnRememberSecond.Checked = false;
	            rbtnNotRememberSecond.Checked = false;
                return;
            }

            // 두번째 단어 UI로 데이터 갱신
            WordSecond.Text = mSecondData.WordName;
            MeanListViewSecond.BeginUpdate();
            MeanListViewSecond.Items.Clear();
            foreach (string mean in mSecondData.MeanList)
            {
	            MeanListViewSecond.Items.Add(mean);
            }
            MeanListViewSecond.EndUpdate();
            MemoSecond.Text = mSecondData.Memo;

            if (mSecondData.RememberType == ERememberType.REMEMBER)
            {
	            rbtnRememberSecond.Checked = true;
            }
            else
            {
	            rbtnNotRememberSecond.Checked = true;
            }
        }

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
	        mFirstData = null;
	        mSecondData = null;
	        mAudioPlayer.close();
	        mAudioPlayer = null;
	        mWordRefreshTimer.Tick -= btnRefreshWord_Click;
            mWordRefreshTimer.Dispose();
            mWordRefreshTimer = null;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbtnRememberFirst_CheckedChanged(object sender, EventArgs e)
        {
	        if (rbtnRememberFirst.Checked)
	        {
		        changeRememberTypeOfWordData(mFirstData, ERememberType.REMEMBER);
	        }
            else
	        {
		        changeRememberTypeOfWordData(mFirstData, ERememberType.NOT_REMEMBER);
	        }
        }


        private void rbtnRememberSecond_CheckedChanged(object sender, EventArgs e)
        {
	        if (rbtnRememberSecond.Checked)
	        {
		        changeRememberTypeOfWordData(mSecondData, ERememberType.REMEMBER);
	        }
	        else
	        {
		        changeRememberTypeOfWordData(mSecondData, ERememberType.NOT_REMEMBER);
	        }
        }


        private void changeRememberTypeOfWordData(WordData word, ERememberType newType)
        {
	        if (word == null)
	        {
		        return;
	        }

	        if (word.RememberType != newType)
	        {
		        word.UpdateRememberType(newType);

		        if (newType == ERememberType.NOT_REMEMBER)
		        {
			        WordManager.MoveWordDataToNotRememberList(word.WordName);
		        }
                else
		        {
			        WordManager.MoveWordDataToRememberList(word.WordName);
		        }
	        }
        }
        private void btnPronounceWordFirst_Click(object sender, EventArgs e)
        {
	        if (mFirstData == null)
	        {
		        return;
	        }

	        audioPlayerPlay(WordFirst.Text);
        }

        private void btnPronounceWordSecond_Click(object sender, EventArgs e)
        {
	        if (mSecondData == null)
	        {
		        return;
	        }
            audioPlayerPlay(WordSecond.Text);
        }

        private void audioPlayerPlay(string wordName)
        {

	        if (!File.Exists($"{FileManager.AUDIO_DIRECTORY_PATH}\\{wordName}.mp3"))
	        {
		        if (DialogResult.Yes == MessageBox.Show("음성 파일을 받으시겠습니까?", "음성 파일이 존재하지 않습니다!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
		        {
			        FileManager.DownloadAudioFile(wordName);
		        }
	        }
	        else
	        {
		        mAudioPlayer.URL = $"{Application.StartupPath}//{FileManager.AUDIO_DIRECTORY_PATH}//{wordName}.mp3";
		        mAudioPlayer.controls.play();
            }
        }

        private void onAudioPlayerStateChange(int newState)
        {
	        if ((WMPLib.WMPPlayState)newState == WMPLib.WMPPlayState.wmppsStopped)
	        {
		        mAudioPlayer.close();
	        }
        }
    }
}
