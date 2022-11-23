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


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            // 관리자 모드가 아니면 관리자 모드로 재실행합니다. (사용자의 확인 후.)
            if (identity != null)
            {
	            WindowsPrincipal principal = new WindowsPrincipal(identity);

	            bool isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);

	            if (!isAdministrator)
	            {
		            ProcessStartInfo info = new ProcessStartInfo();
		            info.UseShellExecute = true;
		            info.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
		            info.WorkingDirectory = Environment.CurrentDirectory;
		            info.Verb = "runas";

		            Process.Start(info);
	            }
	            else
	            {
		            // initialize data
		            WordClassData.Initialize();
		            FileManager.Initialize();
		            WordTable.Initialize();
		            Setting.Initialize();
		            WordManager.Initialize();

		            MainForm mainForm = new MainForm();
		            Application.Run(mainForm);

		            // save files and release
		            // stop refresh timer
		            WordManager.Release();
		            WordTable.Release();
		            WordClassData.Release();
		            FileManager.Release();
	            }
            }

        }

        static void SetAdministratorMode()
        {

        }
    }
}
