using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WordMemory
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

            // Setting 클래스에서 정보 초기화
            // 1. 뷰모드 초기화
            switch (Setting.ViewMode)
			{
            case EViewMode.SHOW_ONLY_NOT_REMEMBER:
	            rbtnViewNotRemember.Checked = true;
	            break;
            case EViewMode.SHOW_ONLY_REMEMBER:
	            rbtnViewRemember.Checked = true;
	            break;
            case EViewMode.SHOW_MIXED:
	            rbtnViewMixed.Checked = true;
                break;
            default:
                Debug.Assert(false, $"ViewMode 열거형 데이터가 잘못 되었습니다. {(Int32)Setting.ViewMode}");
                break;
			}

            // 2. 갱신 모드 초기화
            switch (Setting.RefreshMode)
            {
            case ERefreshMode.MANUAL:
	            rbtnManualRefresh.Checked = true;
	            break;
            case ERefreshMode.TIMER:
	            rbtnTimerRefresh.Checked = true;
	            break;
            default:
	            Debug.Assert(false, $"RefreshMode 열거형 데이터가 잘못 되었습니다. {(Int32)Setting.RefreshMode}");
	            MessageBox.Text = "데이터 표시에 문제가 발생했습니다.";
	            MessageBox.ForeColor = Color.Red;
	            break;
            }

            // 3. 타이머 값 초기화
            InputTimerCount.Value = Setting.GetRefreshTimeMinutes();


            // 4. 윈도우 시작시 자동실행 여부 초기화
            if (Setting.AutoStart == EAutoStart.SET_AUTO_START)
            {
	            AutoStartBox.Checked = true;
            }
            else
            {
	            AutoStartBox.Checked = false;
            }

            MessageBox.Text = "설정이 로드되었습니다.";
            MessageBox.ForeColor = Color.Green;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
	        // 1. 뷰모드 적용
	        if (rbtnViewNotRemember.Checked)
	        {
		        Setting.ViewMode = EViewMode.SHOW_ONLY_NOT_REMEMBER;

	        }
            else if (rbtnViewRemember.Checked)
	        {
		        Setting.ViewMode = EViewMode.SHOW_ONLY_REMEMBER;
	        }
            else
	        {
		        Setting.ViewMode = EViewMode.SHOW_MIXED;
	        }

	        // 2. 갱신 모드 적용
	        if (rbtnManualRefresh.Checked)
	        {
		        Setting.RefreshMode = ERefreshMode.MANUAL;
	        }
	        else
	        {
		        Setting.RefreshMode = ERefreshMode.TIMER;
	        }

            // 3. 타이머 값 적용
            Setting.RefreshTimeMilliseconds = (Int32)InputTimerCount.Value;

            // 4. 설정 값 저장
            Setting.SaveSettingData();

            MessageBox.Text = "설정이 저장되었습니다.";
            MessageBox.ForeColor = Color.Green;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnExportWordData_Click(object sender, EventArgs e)
        {
            WordManager.ExportWordData();
        }

        private void btnImportWordData_Click(object sender, EventArgs e)
        {
	        WordManager.ImportWordData();
        }

        private void AutoStartBox_CheckedChanged(object sender, EventArgs e)
        {
            
	        if (AutoStartBox.Checked)
	        {
		        Setting.AutoStart = EAutoStart.SET_AUTO_START;
		        //Write(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", "WordMemory", "\"" + Application.ExecutablePath.ToString() + "\"");

                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("WordMemory", Application.ExecutablePath);
            }
            else
	        {
		        Setting.AutoStart = EAutoStart.UNSET_AUTO_START;
		        RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		        key.DeleteValue("WordMemory", false);
	        }
        }

        public bool Write(RegistryKey baseKey, string keyPath, string KeyName, object Value)
        {

		        // Setting 
		        RegistryKey rk = baseKey;
		        // I have to use CreateSubKey 
		        // (create or open it if already exits), 
		        // 'cause OpenSubKey open a subKey as read-only 
		        RegistryKey sk1 = rk.CreateSubKey(keyPath);
		        // Save the value 
		        sk1.SetValue(KeyName.ToUpper(), Value);

		        return true;

        }
    }
}
