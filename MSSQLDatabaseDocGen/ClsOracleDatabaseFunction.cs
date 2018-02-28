using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace MSSQLDatabaseDocGen
{
    class ClsOracleDatabaseFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servername"></param>
        /// <param name="databasename"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public bool KetNoiCSDL(String servername,String servicename ,String username, String password, ref OracleConnection Orclconn)
        {
            String strSqlcon = string.Empty;            
            //strSqlcon = "Data source='" + servername + "';uid='" + username.Trim() + "';pwd='" + password.Trim() + "'";            
            strSqlcon = @"SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + servername + @")
                         (PORT=1521))(CONNECT_DATA=(SERVICE_NAME=" + servicename + @")));
                         User Id='" + username + "';Password='" + password + "'";
            try
            {
                Orclconn = new OracleConnection(strSqlcon);
                Orclconn.Open();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ham doc CSDL vao doi tuong SQLDataReader
        /// </summary>
        /// <param name="sqlstr">Chuỗi truy vấn SQL</param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public OracleDataReader LoadDataToDataReader(String sqlstr, OracleConnection conn)
        {
            OracleDataReader drdReader = null;
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlstr;
            try
            {
                drdReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return drdReader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable LoadDataToDataTable(String sqlstr, OracleConnection conn)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlstr;
                da.SelectCommand = cmd;
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex) { }
            return dt;
        }

        /// <summary>
        /// Lấy ra danh sách các bảng cùng mô tả về bảng có trong CSDL
        /// </summary>
        /// <returns>DataTable</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetTablesInform (OracleConnection orclconn, ArrayList arrTableName)
        {
            DataTable dt = new DataTable();
            if (arrTableName == null || arrTableName.Count < 0)
            {
                return dt;
            }
            String temp = string.Empty;

            for (int i = 0; i < arrTableName.Count; i++)
            {
                temp += "'" + arrTableName[i].ToString() + "',";
            }
            if (temp.Length > 0)
                temp = temp.Remove(temp.Length - 1, 1);
            string strSql = "SELECT * FROM USER_TAB_COMMENTS WHERE TABLE_TYPE='TABLE' AND TABLE_NAME IN(" + temp + ")";
            dt = LoadDataToDataTable(strSql, orclconn);
            return dt;
        }

        /// <summary>
        /// Lấy ra danh sách tên các bảng có trong CSDL
        /// </summary>
        /// <param name="dt">DataTable lưu thông tin của các bảng</param>
        /// <returns>Mảng</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayTablesName(OracleConnection orclconn)
        {
            string strSql = "SELECT table_name FROM USER_TABLES ORDER BY table_name ASC";
            DataTable dt = LoadDataToDataTable(strSql,orclconn);
            ArrayList arrtemp = new ArrayList();
            foreach (DataRow dtwrow in dt.Rows)
            {
                arrtemp.Add(dtwrow["table_name"].ToString().ToUpper());
            }
            return arrtemp;
        }
        
        /// <summary>
        /// Lấy cấu trúc của bảng 
        /// </summary>
        /// <param name="tablename">Tên bảng cần lấy cấu trúc</param>
        /// <returns>Trả về DataTable</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetTableStructure(OracleConnection orclconn, String tablename)
        {
            String strsql = @"SELECT CL.TABLE_NAME, CL.COLUMN_NAME,CL.DATA_TYPE , CL.DATA_LENGTH 
                              ,CL.DATA_DEFAULT,
                              CASE CL.NULLABLE
                              WHEN 'N' THEN  ''
                              ELSE 'x'
                              END NULLABLE, 
                              (SELECT   decode(cont.constraint_type,'U','x')
                                 FROM user_constraints cont,  user_cons_columns cons 
                                 where cons.constraint_name= cont.constraint_name and cons.position<>0 
                                 and  cons.column_name=cl.column_name 
                                 and cons.table_name = cl.Table_name and cont.constraint_type='U'
                              ) ""Unique"" ,                                    
                              (SELECT  decode(cont.constraint_type,'P','PK','R','FK')
                                  FROM user_constraints cont,  user_cons_columns cons 
                                  where cons.constraint_name= cont.constraint_name and cons.position<>0 
                                  and  cons.column_name=cl.column_name and cons.table_name = cl.Table_name
                                  and cont.constraint_type<>'U'
                               ) 
                               ""PK/FK""
                              , CM.COMMENTS Description                       
                          FROM  USER_TAB_COLUMNS CL, USER_COL_COMMENTS CM
                          WHERE CM.COLUMN_NAME= CL.COLUMN_NAME    AND CL.TABLE_NAME=CM.TABLE_NAME AND CL.Table_name='" + tablename + "'";
            DataTable dt = LoadDataToDataTable(strsql, orclconn);
            return dt;
        }

        /// <summary>
        /// Lấy ra Mảng các cấu trúc của từng bảng trong CSDL
        /// </summary>
        /// <param name="arrTableName"></param>
        /// <param name="orclconn"></param>
        /// <returns>Mảng</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayTablesStructure(ArrayList arrTablesName,OracleConnection orclconn)
        {
            ArrayList arrtemp = new ArrayList();
            for (int intindex = 0; intindex < arrTablesName.Count; intindex++)
            {
                DataTable dttemp = GetTableStructure(orclconn,arrTablesName[intindex].ToString());
                arrtemp.Add(dttemp);
            }
            return arrtemp;
        }

        /// <summary>
        /// Lấy ra danh sách tên các view có trong CSDL
        /// </summary>
        /// <param name="dt">DataTable lưu thông tin của các bảng</param>
        /// <returns>Mảng</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayViewName(OracleConnection orclconn)
        {
            string strSql = "SELECT view_name FROM USER_VIEWS ";
            DataTable dt = LoadDataToDataTable(strSql, orclconn);
            ArrayList arrtemp = new ArrayList();
            foreach (DataRow dtwrow in dt.Rows)
            {
                arrtemp.Add(dtwrow["view_name"].ToString().ToUpper());
            }
            return arrtemp;
        }
        /// <summary>
        /// Lấy ra danh sách các view cùng mô tả về bảng có trong CSDL
        /// </summary>
        /// <returns>DataTable</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetViewsInform(OracleConnection orclconn, ArrayList arrTableName)
        {
            DataTable dt = new DataTable();
            if (arrTableName == null || arrTableName.Count < 0)
            {
                return dt;
            }
            String temp = string.Empty;

            for (int i = 0; i < arrTableName.Count; i++)
            {
                temp += "'" + arrTableName[i].ToString() + "',";
            }
            if (temp.Length > 0)
                temp = temp.Remove(temp.Length - 1, 1);
            string strSql = "SELECT * FROM USER_TAB_COMMENTS WHERE TABLE_TYPE='VIEW' AND TABLE_NAME IN(" + temp + ")";
            dt = LoadDataToDataTable(strSql, orclconn);
            return dt;
        }

        /// <summary>
        /// Lấy danh sách Index trong CSDL
        /// </summary>
        /// <returns>DataTable</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>        
        public DataTable GetIndexList(OracleConnection orclconn)
        {
            String strSql = "SELECT index_name, table_name,column_name FROM USER_IND_COLUMNS"; 
            DataTable dt = LoadDataToDataTable(strSql, orclconn);
            return dt;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="orclconn"></param>
        ///// <param name="strIndexName"></param>
        ///// <returns></returns>
        ///// <Modifield>
        ///// Người tạo                   ngày tạo            chú thích
        ///// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        ///// </Modifield>
        //public DataTable GetIndexIncludeColumn(OracleConnection orclconn, String strIndexName)
        //{
        //    String strSql = "";
        //    DataTable dt = LoadDataToDataTable(strSql, orclconn);
        //    return dt;
        //}

        /// <summary>
        /// Lấy ra thông tin về các trigger có trong CSDL
        /// </summary>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetTriggerList(OracleConnection orclconn)
        {
            String strSql = @"SELECT TRIGGER_NAME, TRIGGER_TYPE ""Type"", TABLE_NAME, 
                              TRIGGERING_EVENT EVENT,DESCRIPTION FROM USER_TRIGGERS";
            DataTable dt = LoadDataToDataTable(strSql, orclconn);
            return dt;
        }

        /// <summary>
        /// Lấy ra mảng tên các Stored Procedure có trong CSDL
        /// </summary>
        /// <param name="orclconn"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayStoredProceduresName(OracleConnection orclconn)
        {
            ArrayList arrtemp = new ArrayList();
            String strSql = "SELECT NAME FROM USER_SOURCE WHERE  TYPE='PROCEDURE' GROUP BY NAME";
            OracleDataReader drdReader = LoadDataToDataReader(strSql, orclconn);
            if (drdReader.HasRows)
            {
                while (drdReader.Read())
                {
                    arrtemp.Add(drdReader["name"].ToString());
                }
            }
            drdReader.Close();
            return arrtemp;
        }

        /// <summary>
        /// Lấy ra thông tin của từng Stored Procedure
        /// </summary>
        /// <param name="orclconn"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetStoredProcedureStructure(OracleConnection orclconn,String strStoreProcedureName)
        {
            String strSql = "SELECT Text FROM USER_SOURCE WHERE TYPE='PROCEDURE' AND NAME='" + strStoreProcedureName + "'";

            OracleDataReader reader = LoadDataToDataReader(strSql, orclconn);
            String strtemp1 = string.Empty;
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    strtemp1 += reader["text"].ToString();
                }
                reader.Close();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Parameter name");
            dt.Columns.Add("Parameter Type");            
            
            String strparametername = string.Empty;
            String strparameterType = string.Empty;
            String strtemp2 = string.Empty;
            if ( strtemp1.Contains("BEGIN"))
            {
                strtemp1 = strtemp1.Substring(0, strtemp1.IndexOf("BEGIN"));
                if (strtemp1.Contains("(") && strtemp1.Contains(")"))
                {
                    strtemp1 = strtemp1.Substring(strtemp1.IndexOf("("), strtemp1.IndexOf(")") - strtemp1.IndexOf("("));
                    strtemp1 = strtemp1.Replace("(", "");
                    strtemp1 = strtemp1.Replace(")", "");
                    while (strtemp1.Contains("  "))
                        strtemp1 = strtemp1.Replace("  ", " ");
                    while (strtemp1.Contains("\n"))
                        strtemp1 = strtemp1.Replace("\n", "");
                    strtemp1 = strtemp1.Trim();
                    DataRow row;
                    while (strtemp1.IndexOf(",") > 0)
                    {
                        strtemp2 = strtemp1.Substring(0, strtemp1.IndexOf(",")).ToUpper() + " ";
                        strparametername = strtemp2.Substring(0, strtemp2.IndexOf(" ")).Trim();
                        row = dt.NewRow();
                        row["Parameter name"] = strparametername;
                        for (int index = 0; index < clsGlobalVariable.strVariableType.Length; index++)
                        {
                            strparameterType = clsGlobalVariable.strVariableType[index].ToString();
                            if (strtemp2.Contains(strparameterType))
                            {
                                row["Parameter Type"] = strparameterType;
                                break;
                            }
                        }


                        dt.Rows.Add(row);
                        strtemp1 = strtemp1.Substring(strtemp1.IndexOf(",") + 1, strtemp1.Length - strtemp1.IndexOf(",") - 1);
                        strtemp1 = strtemp1.Trim();
                    }
                    strtemp1 = strtemp1.ToUpper() + " ";
                    strparametername = strtemp1.Substring(0, strtemp1.IndexOf(" ")).Trim();
                    row = dt.NewRow();
                    row["Parameter name"] = strparametername;
                    for (int index = 0; index < clsGlobalVariable.strVariableType.Length; index++)
                    {
                        strparameterType = clsGlobalVariable.strVariableType[index].ToString();
                        if (strtemp1.Contains(strparameterType))
                        {
                            row["Parameter Type"] = strparameterType;
                            break;
                        }
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        /// <summary>
        /// Lấy ra mảng các cấu trúc của các Stored Procedure
        /// </summary>
        /// <param name="arrStoreProcedureName"></param>
        /// <param name="orclconn"></param>
        /// <returns>Mảng các DataTable chứa cấu trúc của Stored Procedure</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayStoredProceduresStructure(ArrayList arrStoreProcedureName ,OracleConnection orclconn)
        {
            ArrayList arrtemp = new ArrayList();
            for (int intindex = 0; intindex < arrStoreProcedureName.Count; intindex++)
            {
                DataTable dt = GetStoredProcedureStructure(orclconn, arrStoreProcedureName[intindex].ToString());
                arrtemp.Add(dt);
            }
            return arrtemp;
        }

        /// <summary>
        /// Lấy ra mảng các tên của Function có trong CSDL
        /// </summary>
        /// <returns>Mảng chứ tên Function</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayFunctionsName(OracleConnection orclconn,String username)
        {
            ArrayList arrtemp = new ArrayList();
            String strSql = @"SELECT NAME FROM USER_SOURCE WHERE  TYPE='FUNCTION' GROUP BY NAME"; 
           OracleDataReader drdReader = LoadDataToDataReader(strSql, orclconn);
            if (drdReader.HasRows)
            {
                while (drdReader.Read())
                {
                    arrtemp.Add(drdReader["name"].ToString());
                }
            }
            drdReader.Close();
            return arrtemp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orclconn"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetFunctionInform(OracleConnection orclconn ,String strFunctionName)
        {
            String strSql = @"SELECT Text FROM USER_SOURCE WHERE TYPE='FUNCTION' AND NAME='" + strFunctionName + "'";

            OracleDataReader reader = LoadDataToDataReader(strSql, orclconn);
            String strtemp1 = string.Empty;
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    strtemp1 += reader["text"].ToString().ToUpper();
                }
                reader.Close();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Parameter name");
            dt.Columns.Add("Parameter Type");

            String strparametername = string.Empty;
            String strparameterType = string.Empty;
            String strtemp2 = string.Empty;
           
            strtemp1 = strtemp1.Substring(0, strtemp1.IndexOf("RETURN") );
            if (strtemp1.Contains("(") && strtemp1.Contains(")"))
            {
                strtemp1 = strtemp1.Substring(strtemp1.IndexOf("("), strtemp1.IndexOf(")") - strtemp1.IndexOf("("));
                strtemp1 = strtemp1.Replace("(", "");
                strtemp1 = strtemp1.Replace(")", "");
                while (strtemp1.Contains("  "))
                    strtemp1 = strtemp1.Replace("  ", " ");
                while (strtemp1.Contains("\n"))
                    strtemp1 = strtemp1.Replace("\n", "");
                strtemp1 = strtemp1.Trim();
                DataRow row;
                while (strtemp1.IndexOf(",") > 0)
                {
                    strtemp2 = strtemp1.Substring(0, strtemp1.IndexOf(",")).ToUpper() + " ";
                    strparametername = strtemp2.Substring(0, strtemp2.IndexOf(" ")).Trim();
                    row = dt.NewRow();
                    row["Parameter name"] = strparametername;
                    for (int index = 0; index < clsGlobalVariable.strVariableType.Length; index++)
                    {
                        strparameterType = clsGlobalVariable.strVariableType[index].ToString();
                        if (strtemp2.Contains(strparameterType))
                        {
                            row["Parameter Type"] = strparameterType;
                            break;
                        }
                    }
                    //strparameterType = strtemp2.Substring(strtemp2.LastIndexOf(" "), strtemp2.Length - strtemp2.LastIndexOf(" ")).Trim();
                    dt.Rows.Add(row);
                    strtemp1 = strtemp1.Substring(strtemp1.IndexOf(",") + 1, strtemp1.Length - strtemp1.IndexOf(",") - 1);
                    strtemp1 = strtemp1.Trim();
                }
                strtemp1 = strtemp1.ToUpper() + " ";
                strparametername = strtemp1.Substring(0, strtemp1.IndexOf(" ")).Trim();
                row = dt.NewRow();
                row["Parameter name"] = strparametername;
                for (int index = 0; index < clsGlobalVariable.strVariableType.Length; index++)
                {
                    strparameterType = clsGlobalVariable.strVariableType[index].ToString();
                    if (strtemp1.Contains(strparameterType))
                    {
                        row["Parameter Type"] = strparameterType;
                        break;
                    }
                }
                dt.Rows.Add(row);
            }
           
            return dt;
        }

        /// <summary>
        /// Lấy ra mảng các cấu trúc của các Function
        /// </summary>
        /// <param name="arrFunctionName"></param>
        /// <param name="orclconn"></param>
        /// <returns>Mảng các DataTable chứ cấu trúc của Function</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayFunctionsStructure(ArrayList arrFunctionName ,OracleConnection orclconn)
        {
            ArrayList arrtemp = new ArrayList();
            for (int intindex = 0; intindex < arrFunctionName.Count; intindex++)
            {
                DataTable dt = GetFunctionInform(orclconn ,arrFunctionName[intindex].ToString());
                arrtemp.Add(dt);
            }
            return arrtemp;
        }
    }
}
