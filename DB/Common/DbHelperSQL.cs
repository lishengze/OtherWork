using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
namespace Maticsoft.DBUtility
{
    /// <summary>
    /// ���ݷ�����
    /// </summary>
    public class DbHelperSQL
    {

        public static string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        #region ���÷���
        /// <summary>
        /// �ж��Ƿ����ĳ���ĳ���ֶ�
        /// </summary>
        /// <param name="tableName">������</param>
        /// <param name="columnName">������</param>
        /// <returns>�Ƿ����</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }

        public static long GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// ���Ƿ����
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            object obj = DbHelperSQL.GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql,  params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ///// <summary>
        ///// ��ҳ����
        ///// </summary>
        ///// <param name="tblName">����</param>
        ///// <param name="fldName">�����ֶ���</param>
        ///// <param name="strGetFields">��ȡ���ֶ�</param>
        ///// <param name="PageSize">ҳ��С</param>
        ///// <param name="PageIndex">ҳ����</param>
        ///// <param name="orderType">����ʽ,true=����</param>
        ///// <param name="strWhere">where�Ӿ䣬���ؼ�'where'</param>
        ///// <param name="ReCount">��¼����</param>
        ///// <returns></returns>
        //public static DataSet GetPageList(string tblName, string fldName, string strGetFields, int PageSize, int PageIndex, bool orderType, string strWhere, ref int ReCount)
        //{
        //    SqlParameter[] pars = new SqlParameter[] {
        //        new SqlParameter("@tblName", tblName),
        //        new SqlParameter("@fldName", fldName),
        //        new SqlParameter("@strGetFields", strGetFields),
        //        new SqlParameter("@PageSize", PageSize),
        //        new SqlParameter("@PageIndex", PageIndex),
        //        new SqlParameter("@OrderType", orderType ? 0 : 1),
        //        new SqlParameter("@strWhere", strWhere),
        //        new SqlParameter("@Count", ReCount)
        //    };
        //    pars[7].Direction = ParameterDirection.Output;
        //    DataSet ds = RunProcedure("up_DataPager", pars, "ds");
        //    ReCount = (int)pars[7].Value;
        //    return ds;
        //}

        ///// <summary>
        ///// ʹ��Id�����ҳ
        ///// </summary>
        ///// <param name="tblName">����</param>
        ///// <param name="strGetFields">��ȡ���ֶ�</param>
        ///// <param name="PageSize">ҳ��С</param>
        ///// <param name="PageIndex">ҳ����</param>
        ///// <param name="strWhere">where�Ӿ�</param>
        ///// <param name="ReCount">��¼����</param>
        ///// <returns></returns>
        //public static DataSet GetPageList(string tblName, string strGetFields, int PageSize, int PageIndex, string strWhere, ref int ReCount)
        //{
        //    return GetPageList(tblName, "Id", strGetFields, PageSize, PageIndex, false, strWhere, ref ReCount, connectionString);
        //}
        #endregion

        #region  ִ�м�SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            try
            {
                connection.Open();
                cmd.CommandTimeout = Times;
                int rows = cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }
        }
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                int count = 0;
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n];
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        count += cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return count;
            }
            catch
            {
                tx.Rollback();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return 0;
            }
        }
        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
            myParameter.Value = content;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }
        }
        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
            myParameter.Value = content;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }

        }
        /// <summary>
        /// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
            myParameter.Value = fs;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }

        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns> 
        public static object GetSingle(string SQLString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }

        }
        public static object GetSingle(string SQLString, int Times)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            try
            {
                connection.Open();
                cmd.CommandTimeout = Times;
                object obj = cmd.ExecuteScalar();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Dispose(); 
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose(); 
                throw e;
            }
        }


        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                connection.Close();
                connection.Dispose();
                throw new Exception(ex.Message);
            }
            return ds;
        }
        public static DataSet Query(string SQLString, int Times)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.SelectCommand.CommandTimeout = Times;
                command.Fill(ds, "ds");
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                connection.Close();
                connection.Dispose();
                throw new Exception(ex.Message);
            }
            return ds;
        }



        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string SQLString,  params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }

        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction trans = null;
            try
            {
                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                //ѭ��
                foreach (DictionaryEntry myDE in SQLStringList)
                {
                    string cmdText = myDE.Key.ToString();
                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                    PrepareCommand(cmd, connection, trans, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch
            {
                connection.Close();
                connection.Dispose();
                trans.Rollback();
            }
        }
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                int count = 0;
                //ѭ��
                foreach (CommandInfo myDE in cmdList)
                {
                    string cmdText = myDE.CommandText;
                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
                    {
                        if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                        {
                            trans.Rollback();
                            return 0;
                        }
                        object obj = cmd.ExecuteScalar();
                        bool isHave = false;
                        if (obj == null && obj == DBNull.Value)
                        {
                            isHave = false;
                        }
                        isHave = Convert.ToInt32(obj) > 0;
                        if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
                        {
                            trans.Rollback();
                            return 0;
                        }
                        if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
                        {
                            trans.Rollback();
                            return 0;
                        }
                        continue;
                    }
                    int val = cmd.ExecuteNonQuery();
                    count += val;
                    if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                    {
                        trans.Rollback();
                        return 0;
                    }
                    cmd.Parameters.Clear();
                }
                trans.Commit();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return count;
            }
            catch
            {
                trans.Rollback();
                conn.Close();
                conn.Dispose();
                throw;
            }
        }
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                int indentity = 0;
                //ѭ��
                foreach (CommandInfo myDE in SQLStringList)
                {
                    string cmdText = myDE.CommandText;
                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                    foreach (SqlParameter q in cmdParms)
                    {
                        if (q.Direction == ParameterDirection.InputOutput)
                        {
                            q.Value = indentity;
                        }
                    }
                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    foreach (SqlParameter q in cmdParms)
                    {
                        if (q.Direction == ParameterDirection.Output)
                        {
                            indentity = Convert.ToInt32(q.Value);
                        }
                    }
                    cmd.Parameters.Clear();
                }
                trans.Commit();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch
            {
                trans.Rollback();
                conn.Close();
                conn.Dispose();
                throw;
            }
        }
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                int indentity = 0;
                //ѭ��
                foreach (DictionaryEntry myDE in SQLStringList)
                {
                    string cmdText = myDE.Key.ToString();
                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                    foreach (SqlParameter q in cmdParms)
                    {
                        if (q.Direction == ParameterDirection.InputOutput)
                        {
                            q.Value = indentity;
                        }
                    }
                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    foreach (SqlParameter q in cmdParms)
                    {
                        if (q.Direction == ParameterDirection.Output)
                        {
                            indentity = Convert.ToInt32(q.Value);
                        }
                    }
                    cmd.Parameters.Clear();
                }
                trans.Commit();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch
            {
                trans.Rollback();
                conn.Close();
                conn.Dispose();
                throw;
            }
        }
        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string SQLString,  params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }

        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString,  params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();

                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString,  params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "ds");
                cmd.Parameters.Clear();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            { 
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion
         
    }
}
