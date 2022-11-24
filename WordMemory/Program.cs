using System;
using System.Diagnostics;
using System.Windows.Forms;
using WordMemory.BindingData;
using System.Security.Principal;

namespace WordMemory
{
	internal static class Program
	{
		/// <summary>
		/// 해당 애플리케이션의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// 자동 실행 여부에 따른 실행 방법을 결정하기 위해 필요한 클래스들을 초기화 합니다.
			FileManager.Initialize();
			Setting.Initialize();

			// 프로그램이 자동실행 모드인데, 관리자 모드가 아니면
			// 관리자 모드로 재실행합니다. (사용자의 확인 후.)
            if (Setting.AutoStart == EAutoStart.SET_AUTO_START && !IsAdministrator())
			{
				ProcessStartInfo info = new ProcessStartInfo();
				info.UseShellExecute = true;
				info.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
				//  Environment.CurrentDirectory 는 관리자 권한에서 현재 프로그램 위치가 아닌 시스템 디렉토리로 출력함.
				info.WorkingDirectory = Application.StartupPath;

				// 관리자 모드로 실행
				info.Verb = "runas";

				Process.Start(info);
			}
			else // 관리자 모드로 실행.
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				// initialize data
				WordClassData.Initialize();
				WordTable.Initialize();
				WordManager.Initialize();

				MainForm mainForm = new MainForm();
				Application.Run(mainForm);

				// save files and release
				WordManager.Release();
				WordTable.Release();
				WordClassData.Release();
			}
            // 자동실행 모드의 경우에 Process.Start() 가 독립적인 프로세스를 실행하므로,
            // 새 프로세스를 실행 후, 앞서 초기화한 파일 매니저의 데이터를 해제.
			// 혹은 자동 실행 모드가 아니어도 수행.
			FileManager.Release();

        }

        /*
		 *  관리자 권한을 가지고 있는지 검사합니다.
		 *  가지고 있으면 true, 그렇지 않으면 false.
		 */
        private static bool IsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();

			if (identity != null)
			{
				WindowsPrincipal principal = new WindowsPrincipal(identity);

				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}

			return false;
		}

	}

}


