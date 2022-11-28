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
			// 관리자 모드로 재실행합니다. (사용자의 확인 후.)
            if (!IsAdministrator())
            {
	            ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;
                // Application.ExecutablePath
                // 
                info.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
                //  Environment.CurrentDirectory 는 관리자 권한에서 현재 프로그램 위치가 아닌 시스템 디렉토리로 출력함.
                // 
                info.WorkingDirectory = Application.StartupPath;

                // 관리자 모드로 실행
                info.Verb = "runas";
                info.Arguments = ""; // ? - 인자 전달 가능.

                Process.Start(info);

            }
            else // 관리자 모드로 실행.
            {
	            Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // initialize data
                FileManager.Initialize();
                Setting.Initialize();
                WordClassData.Initialize();
                WordTable.Initialize();
                WordManager.Initialize();

                MainForm mainForm = new MainForm();
                Application.Run(mainForm);

                // save files and release
                WordManager.Release();
                WordTable.Release();
                WordClassData.Release();
                FileManager.Release();

            }
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


