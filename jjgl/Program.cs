using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace 基金管理
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindMain.Instance.Run();
            LOG.Instance.Run();
            LOG.Instance.Info("Hello!");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MainFrm frm = new MainFrm(null);
           Login frm = new Login();
            Application.Run(frm);
        }
    }
}
