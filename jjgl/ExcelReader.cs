using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace 基金管理
{
    public class ExcelReader
    { 
      
        /// <summary>
        /// 读取Excel数据
        ///IMEX=0,数据类型纯正，并且自动除去空行；文字无法读取，可以把真实的小数位数读取出来；
        ///IMEX=1, 数据类型为混合类型，文字可以读取，但只能读取小数的显示位数；并且不会除去空行；
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="IMEX"></param>
        /// <returns></returns>
        public static DataSet GetDataSetFromExcel(string filePath, int IMEX)
        {
            DataSet oleDsExcel = new DataSet();
            string strConn = string.Empty;
            OleDbConnection oleConn = null;
            try
            {
                try
                {
                    strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source={0};Extended Properties='Excel 12.0;HDR=NO;IMEX={1}'", filePath, IMEX.ToString());
                    oleConn = new OleDbConnection(strConn);
                    oleConn.Open();
                }
                catch (Exception ex)
                {
                    strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=NO;IMEX={1}\"", filePath, IMEX.ToString());
                  
                    try
                    {
                        oleConn = new OleDbConnection(strConn);
                        oleConn.Open();
                    }
                    catch (Exception subEx)
                    {
                        MessageBox.Show("未在本地计算机上注册“Microsoft.Jet.OLEDB.4.0”提供程序。", "系统提示");
                        return oleDsExcel;
                    }
                }
                try
                {
                    System.Data.DataTable dts = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    foreach (DataRow dr in dts.Rows)
                    {
                        string table = dr["TABLE_NAME"].ToString();
                        string strExcel = "SELECT * FROM [" + table + "]";
                        oleDsExcel.Tables.Add(table);
                        OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, oleConn);
                        myCommand.Fill(oleDsExcel, table);
                    }
                }
                catch { }
            }
            catch { }
            finally
            {
                oleConn.Close();
            }
            return oleDsExcel;
        }


        public static bool ExportToExcel(System.Data.DataTable datatable, string fileName)
        {
            bool flag = false;
            StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //写标题   
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += datatable.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容   
                for (int j = 0; j < datatable.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < datatable.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += datatable.Rows[j][k].ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                flag = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
            }
            return flag;
        }

        public static bool SaveDataTableToExcel(System.Data.DataTable excelTable, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;

                #region 写入Excel的数据部分
                if (excelTable.Rows.Count > 0)
                {
                    for (int i = 0; i < excelTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < excelTable.Columns.Count; j++)
                        {
                            //  wSheet.Cells[i + 1, j + 1] = "'" + excelTable.Rows[i][j].ToString();

                            wSheet.Cells[i + 1, j + 1] = excelTable.Rows[i][j].ToString();

                        }
                    }
                }
                #endregion

                //设置禁止弹出保存和覆盖的提示框
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                // 保存工作薄 
                //  wBook.Save(); 
                wBook.SaveAs(filePath, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //从内存中退出   
                wBook.Close(Type.Missing, Type.Missing, Type.Missing);
                app.Quit();

                wSheet = null;
                wBook = null;
                app = null;
                //强制关掉进程
                //Process[] procs = Process.GetProcessesByName("excel");
                //foreach (Process pro in procs)
                //{
                //    pro.Kill();//没有更好的方法,只有杀掉进程
                //}
                GC.Collect();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Excel数据写入失败，原因：" + err.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


    }
}
