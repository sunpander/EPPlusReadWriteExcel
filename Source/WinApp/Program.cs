using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<String> list3 = new List<string> { "a", "b" };
           // ExportUtil.ReadTitle("");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoadConfig());
        }
    }
}
