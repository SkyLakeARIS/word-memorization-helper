using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemory.BindingData;

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

            // initialize data
            WordClassData.Initialize();
            MyConverter.Initialize();
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);

            // save files and release

            WordClassData.Release();
            MyConverter.Release();

        }
    }
}
