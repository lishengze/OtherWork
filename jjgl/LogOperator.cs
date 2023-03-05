using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 基金管理
{
    public  class LogOperator
    {
        public static void WriteLogFile(string content)
        {
            string filePath = Application.StartupPath + @"\log\" + System.DateTime.Now.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //if (!File.Exists(filePath))
            //{
            //    filePath = 
            //}
            //if(File.Exists(
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(content);
            }
            //StreamReader
        }
    }
}
