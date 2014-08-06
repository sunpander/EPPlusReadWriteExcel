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

            DateTime dt = new DateTime(2014, 8, 1, 23, 59,1);
            DateTime dt2 = new DateTime(2014, 8, 1, 18, 17, 0);
            double tmp =  (dt - dt2).TotalHours;
            double tmp2 = 24 - tmp;
            double dd3 = Math.Round(tmp2, 2);
           // ExportUtil.ReadTitle("");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoadConfig());
        }
    }
}
