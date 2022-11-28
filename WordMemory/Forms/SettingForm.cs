using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Win32;
using IWshRuntimeLibrary;
using File = System.IO.File;

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
	            MessageBoxForm.Text = "데이터 표시에 문제가 발생했습니다.";
	            MessageBoxForm.ForeColor = Color.Red;
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

            // 메세지 출력
            MessageBoxForm.Text = $"설정이 로드되었습니다.";
            MessageBoxForm.ForeColor = Color.Green;

            DirectoryBox.Text = $"현재 프로그램 디렉토리{Application.StartupPath}";
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

            // 4. 자동 시작 모드 적용
			// 64비트 환경에서 32비트 레지스트리를 다루는데 문제가 있는 것 같아 알아본 코드로 적용.
            if (AutoStartBox.Checked)
            {

	            Setting.AutoStart = EAutoStart.SET_AUTO_START;
	            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
	                using (var subKey = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl))
	                {
		                if (subKey != null)
		                {
			                //var value = subKey.GetValue("Somekey");
			                subKey.SetValue(Application.ProductName, Application.ExecutablePath);
			                subKey.Close();

                        }
                    }
                }
                // 2번째 방법 - 시작 프로그램에 바로가기 생성
	            // createShortcut();
            }
            else
            {
	            Setting.AutoStart = EAutoStart.UNSET_AUTO_START;

	            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
	            {
		            using (var subKey = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl))
		            {
			            if (subKey != null)
			            {
				            subKey.DeleteValue(Application.ProductName, false);
				            subKey.Close();
                        }
		            }
	            }
                
	            // removeShortcut();
            }

            // 5. 설정 값 저장
            Setting.SaveSettingData();

            MessageBoxForm.Text = "설정이 저장되었습니다.";
            MessageBoxForm.ForeColor = Color.Green;
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

        /*
		*  시작폴더에 바로가기 파일을 만듭니다.
		*/
        private static void createShortcut()
        {
	        WshShell wshShell = new WshShell();
	        IWshRuntimeLibrary.IWshShortcut shortcut;
	        string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

	        // Create the shortcut
            shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut($"{startUpFolderPath}\\WordMemorization.lnk");
	        shortcut.TargetPath = Application.ExecutablePath;
	        shortcut.WorkingDirectory = Application.StartupPath;
	        shortcut.Description = "auto startup word-memorizaion";

	        shortcut.Save();
        }

        /*
		*  시작폴더의 바로가기 파일을 제거합니다.
		*/
        private static void removeShortcut()
        {
	        WshShell wshShell = new WshShell();
	        IWshRuntimeLibrary.IWshShortcut shortcut;
	        string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

	        File.Delete($"{startUpFolderPath}\\WordMemorization.lnk");
        }
    }
}
