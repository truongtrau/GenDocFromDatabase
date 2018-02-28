using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLDatabaseDocGen
{
    /// <summary>
    /// Lớp xử lý các thao tác liên quan đến CSDL
    /// </summary>
    /// <Modifield>
    /// Người tạo                   ngày tạo            chú thích
    /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
    /// </Modifield>
    class ClsSQLDataBaseFunction
    {
        public ClsSQLDataBaseFunction() { }
        ~ClsSQLDataBaseFunction() { }

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
        public  bool KetNoiCSDL(String servername, String databasename, String username, String password,ref SqlConnection sqlconn )
        {
            String strSqlcon = string.Empty;
            if (username.Trim() == "" && password.Trim() == "")
                strSqlcon = "server='" + servername + "';Integrated security=true;uid='" + username.Trim() + "';pwd='" + password.Trim() + "';database=" + databasename;
            else
                strSqlcon = "server='" + servername + "';Integrated security=false;uid='" + username.Trim() + "';pwd='" + password.Trim() + "';database=" + databasename;
            try
            {
                sqlconn = new SqlConnection(strSqlcon);
                sqlconn.Open();
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
        public SqlDataReader LoadDataToDataReader(String sqlstr, SqlConnection conn)
        {
            SqlDataReader drdReade = null;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlstr;
            try
            {
                drdReade = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return drdReade;
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
        public DataTable LoadDataToDataTable(String sqlstr, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
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

       
        public DataTable GetTablesInform(SqlConnection sqlconn,ArrayList arrTablename)
        {
            DataTable dt = new DataTable();
            if (arrTablename == null || arrTablename.Count < 0)
            {
                return dt;
            }
            String temp = string.Empty;
            
            for (int i = 0; i < arrTablename.Count; i++)
            {
                temp += "'" + arrTablename[i].ToString() + "',";                
            }
            if (temp.Length > 0)
               temp= temp.Remove(temp.Length - 1, 1);
            string strSql = "SELECT t.name,";
            strSql += "(SELECT value FROM sys.extended_properties ";
            strSql += "WHERE  minor_id='0' AND name='Description' AND major_id=t.object_id) as Description ";
            strSql += "FROM sys.tables t WHERE t.name<>'sysdiagrams' AND t.name  IN(" + temp + ") order by t.name";
             dt = LoadDataToDataTable(strSql, sqlconn);
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
        public ArrayList GetArrayTablesName(SqlConnection sqlconn)
        {
            string strSql = "SELECT name FROM sys.tables WHERE type_desc='user_table' ORDER BY name ASC";            
            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            ArrayList arrtemp = new ArrayList();
            foreach (DataRow dtwrow in dt.Rows)
            {
                arrtemp.Add(dtwrow["name"].ToString());
            }
            return arrtemp;
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
        public ArrayList GetArrayViewsName(SqlConnection sqlconn)
        {
            string strSql = "SELECT * FROM sys.objects WHERE type_desc='view'  ORDER BY name ASC";
            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            ArrayList arrtemp = new ArrayList();
            foreach (DataRow dtwrow in dt.Rows)
            {
                arrtemp.Add(dtwrow["name"].ToString());
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
        public DataTable GetTableStructure(SqlConnection sqlconn,String tablename)
        {
            String strTsql = "declare @tablename as sysname ";
            strTsql += "set @tablename ='" + tablename + "'";
            strTsql += "declare @tableid as int ";
            strTsql += "select @tableid = id from sysobjects where name = @tablename ";
            strTsql += "declare @coldfvl  as nchar(100) ";
            strTsql += "declare @colid  as int ";
            strTsql += "SELECT @coldfvl=REPLACE(REPLACE(cm.text,'((',''),'))',''), @colid=cm.id ";
            strTsql += "FROM syscomments cm WHERE cm.id IN (SELECT col.cdefault FROM syscolumns col ";
            strTsql += "WHERE col.id = object_id(@tablename) AND col.cdefault > 0) ";
            strTsql += "SELECT col.name as 'Column Name', type.name as 'Data Type', ";
            strTsql += "CASE col.cdefault ";
            strTsql += "WHEN @colid  THEN @coldfvl ";
            strTsql += "ELSE '' ";
            strTsql += "END as 'Default Value',";
            strTsql += "CASE type.name ";
            strTsql += "WHEN 'nvarchar' THEN ";
            strTsql += "CASE col.length ";
            strTsql += "WHEN -1 THEN '' ";
            strTsql += "ELSE CONVERT(nchar,col.length/2) ";
            strTsql += "END ";
            strTsql += "WHEN 'nchar' THEN ";
            strTsql += "CASE col.length ";
            strTsql += "WHEN -1 THEN '' ";
            strTsql += "ELSE CONVERT(nchar,col.length /2) ";
            strTsql += "END ";
            strTsql += "WHEN 'varbinary' THEN ";
            strTsql += "CASE col.length ";
            strTsql += "WHEN -1 THEN '' ";
            strTsql += "ELSE CONVERT(nchar,col.length) ";
            strTsql += "END ";
            strTsql += "WHEN 'binary' THEN CONVERT(nchar,col.length) ";
            strTsql += "WHEN 'char' THEN CONVERT(nchar,col.length)	";
            strTsql += "ELSE  '' ";
            strTsql += "END AS Length, ";
            strTsql += "CASE col.isnullable ";
            strTsql += "WHEN 1 THEN 'x' ";
            strTsql += "ELSE '' ";
            strTsql += "END as 'NULL', ";
            strTsql += "CASE col.name ";
            strTsql += "WHEN (SELECT TOP 1 colpfk.column_name ";
            strTsql += "FROM information_schema.constraint_column_usage colpfk ";
            strTsql += "WHERE colpfk.table_name=@tablename and colpfk.column_name=col.name ";
            strTsql += "AND SUBSTRING(colpfk.constraint_name,1,2)='UK') ";
            strTsql += "THEN 'x' ELSE '' END AS 'Unique',";
            strTsql += "CASE col.name ";
            strTsql += "WHEN (SELECT TOP 1 colpfk.column_name ";
            strTsql += "FROM information_schema.constraint_column_usage colpfk ";
            strTsql += "WHERE colpfk.table_name=@tablename and colpfk.column_name=col.name ";
            strTsql += "and (SUBSTRING(colpfk.constraint_name,1,2)='PK' OR SUBSTRING(colpfk.constraint_name,1,2)='FK')) ";
            strTsql += "THEN (SELECT TOP 1 SUBSTRING(colpfk.constraint_name,1,2) ";
            strTsql += "FROM information_schema.constraint_column_usage colpfk ";
            strTsql += "WHERE colpfk.table_name=@tablename AND colpfk.column_name=col.name) ";
            strTsql += "ELSE '' END AS 'PK/FK', ";
            strTsql += "[Description] = ex.value ";
            strTsql += "FROM sysobjects obj,syscolumns col, systypes type,sys.columns c ";
            strTsql += "LEFT OUTER JOIN sys.extended_properties ex ON ";
            strTsql += "ex.major_id = c.object_id ";
            strTsql += "AND ex.minor_id = c.column_id ";
            strTsql += "AND ex.name = 'MS_Description' ";
            strTsql += "WHERE col.id=obj.id AND col.xtype = type.xtype AND obj.xtype='U' ";
            strTsql += "AND type.name!='sysname' AND obj.name=@tablename ";
            strTsql += "AND OBJECTPROPERTY(c.object_id, 'IsMsShipped')=0 ";
            strTsql += "AND OBJECT_NAME(c.object_id) = @tablename ";
            strTsql += "AND c.name = col.name ";
            strTsql += "ORDER BY OBJECT_NAME(c.object_id), c.column_id";         
            DataTable dt = LoadDataToDataTable(strTsql, sqlconn);
            return dt;

        }

        /// <summary>
        /// Lấy ra Mảng các cấu trúc của từng bảng trong CSDL
        /// </summary>
        /// <param name="arrTableName"></param>
        /// <param name="sqlconn"></param>
        /// <returns>Mảng</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayTablesStructure(ArrayList arrTablesName,SqlConnection sqlconn)
        {
            ArrayList arrtemp = new ArrayList();
            for(int intindex= 0;intindex<arrTablesName.Count; intindex ++)
            {
                DataTable dttemp = GetTableStructure(sqlconn, arrTablesName[intindex].ToString());
                arrtemp.Add(dttemp);
            }
            return arrtemp;
        }

        public DataTable GetViewsInform(SqlConnection sqlconn, ArrayList arrViewname)
        {
            DataTable dt = new DataTable();
            if (arrViewname == null || arrViewname.Count < 0)
            {
                return dt;
            }
            String temp = string.Empty;

            for (int i = 0; i < arrViewname.Count; i++)
            {
                temp += "'" + arrViewname[i].ToString() + "',";
            }
            if (temp.Length > 0)
                temp = temp.Remove(temp.Length - 1, 1);
           
            string strSql = "SELECT ob.name,";
            strSql += "(SELECT value FROM sys.extended_properties ";
            strSql += "WHERE  minor_id='0' AND name='Description' AND major_id=ob.object_id) as Description ";
            strSql += "FROM sys.objects ob WHERE  type_desc='view' AND ob.name IN(" + temp + ") order by ob.name";
            dt = LoadDataToDataTable(strSql, sqlconn);
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
        public DataTable GetIndexList(SqlConnection sqlconn)
        {
            String strSql = "SELECT tb.name as 'Table Name', id.name as 'Index Name', id.type_desc as 'Type' ";
            strSql += "FROM sys.indexes id ";
            strSql += "INNER JOIN sys.tables tb ON id.object_id =tb.object_id ";
            strSql += "WHERE id.index_id<>0 AND tb.name<> 'sysdiagrams' ";
            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <param name="strIndexName"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetIndexIncludeColumn(SqlConnection sqlconn, String strIndexName)
        {
            String strSql = "SELECT col.name as 'Index Column Name' ";
            strSql += "FROM sys.columns col INNER JOIN sys.index_columns ic ";
            strSql += "ON col.column_id = ic.column_id  and col.object_id = ic.object_id ";
            strSql += "INNER JOIN sys.tables tb ON tb.object_id = ic.object_id ";
            strSql += "INNER JOIN sys.indexes id ON id.object_id = tb.object_id ";
            strSql += "WHERE id.name='" + strIndexName + "'";
            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            return dt;
        }

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
        public DataTable GetTriggerList(SqlConnection sqlconn)
        {
            String strSql = "SELECT tg.name AS 'Trigger Name',tb.name  AS 'Table Name', tg.type_desc AS 'Type', tge.type_desc AS 'Event' ";
            strSql += "FROM sys.triggers tg INNER JOIN sys.tables tb ON tg.parent_id = tb.object_id ";
            strSql += "INNER JOIN sys.trigger_events tge on tg.object_id = tge.object_id ";
            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            return dt;
        }

       /// <summary>
       /// Lấy ra mảng tên các Stored Procedure có trong CSDL
       /// </summary>
       /// <param name="sqlconn"></param>
       /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayStoredProceduresName(SqlConnection sqlconn)
        {
            ArrayList arrtemp = new ArrayList();
            String strSql = "SELECT name FROM sysobjects ";
            strSql += "WHERE type='P' ";
            strSql += "AND name<>'SP_ALTERDIAGRAM' AND name<>'SP_CREATEDIAGRAM' ";
            strSql += "AND name<>'SP_DROPDIAGRAM' AND name<>'SP_HELPDIAGRAMDEFINITION' ";
            strSql += "AND name<>'SP_HELPDIAGRAMS' AND name<>'SP_RENAMEDIAGRAM' ";
            strSql += "AND name<>'SP_UPGRADDIAGRAMS' ";
            strSql += "ORDER BY name";
            SqlDataReader drdReader = LoadDataToDataReader(strSql, sqlconn);
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
        /// <param name="sqlconn"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetStoredProcedureStructure(SqlConnection sqlconn, String strStoreProcedureName)
        {
            String strSql = @"SELECT 
                                (SELECT ep.value FROM sys.extended_properties EP 
                                 WHERE  ep.major_id = o.object_id AND ep.name='Description') AS 'Description',
                                 Replace(p.name,'@','') as 'Parameter Name' ,tp.name +  '(' +
                                CASE tp.name
	                                WHEN 'nvarchar' THEN
		                                CASE p.max_length 
		                                WHEN -1 THEN 'max'
		                                ELSE CONVERT(nvarchar,p.max_length /2)
		                                END
	                                WHEN 'nchar' THEN
		                                 CASE p.max_length  
		                                 WHEN -1 THEN 'max'
		                                 ELSE CONVERT(nvarchar,p.max_length  /2)
		                                 END
	                                WHEN 'varbinary' THEN
		                                CASE p.max_length 
		                                WHEN -1 THEN 'max'
		                                ELSE CONVERT(nchar,p.max_length )
		                                END	  
                                    WHEN 'binary' THEN		
		                                CONVERT(nvarchar,p.max_length )		
	                                WHEN 'char' THEN		
		                                CONVERT(nvarchar,p.max_length )	
	                                ELSE  ''
	                                END 
                                 + ')' AS 'Parameter Type',
                                (SELECT ep.value from sys.extended_properties EP
                                WHERE  ep.major_id = o.object_id AND ep.name='Output') AS 'Output' 
                                FROM sys.objects AS o 
                                JOIN sys.parameters AS p ON o.object_id = p.object_ID
                                Join systypes tp ON tp.xtype = p.system_type_id
                                WHERE o.type='P' AND tp.name<>'sysname' AND o.name='" + strStoreProcedureName +
                               @"'AND o.name<>'SP_ALTERDIAGRAM' AND o.name<>'SP_CREATEDIAGRAM' 
                                AND o.name<>'SP_DROPDIAGRAM' AND o.name<>'SP_HELPDIAGRAMDEFINITION' 
                                AND o.name<>'SP_HELPDIAGRAMS' AND o.name<>'SP_RENAMEDIAGRAM'
                                AND o.name<>'SP_UPGRADDIAGRAMS' 
                                ORDER BY o.name ";

            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            return dt;
        }

        /// <summary>
        /// Lấy ra mảng các cấu trúc của các Stored Procedure
        /// </summary>
        /// <param name="arrStoreProcedureName"></param>
        /// <param name="sqlconn"></param>
        /// <returns>Mảng các DataTable chứa cấu trúc của Stored Procedure</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayStoredProceduresStructure(ArrayList arrStoreProcedureName, SqlConnection sqlconn)
        {
            ArrayList arrtemp = new ArrayList();
            for (int intindex = 0; intindex < arrStoreProcedureName.Count; intindex++)
            {
                DataTable dt = GetStoredProcedureStructure(sqlconn, arrStoreProcedureName[intindex].ToString());
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
        public ArrayList GetArrayFunctionsName(SqlConnection sqlconn)
        {
            ArrayList arrtemp = new ArrayList();
            String strSql = @"SELECT o.name AS 'Name'
                           FROM sys.objects AS o 
                           WHERE o.type IN ('IF','TF','FN','FS','FT') AND o.name<>'fn_diagramobjects'  ORDER BY o.name ASC";
            SqlDataReader drdReader = LoadDataToDataReader(strSql, sqlconn);
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
        /// <param name="sqlconn"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public DataTable GetFunctionInform(SqlConnection sqlconn, String strFunctionName)
        {
            String strSql = @"SELECT o.name AS FunctionName,
                                (SELECT ep.value FROM sys.extended_properties EP 
                                 WHERE  ep.major_id = o.object_id AND ep.name='Description') AS 'Description',
                                 Replace(p.name,'@','') as 'Parameter Name' ,tp.name +  '(' +
                                CASE tp.name
                                    WHEN 'nvarchar' THEN
                                        CASE p.max_length 
                                        WHEN -1 THEN 'max'
                                        ELSE CONVERT(nvarchar,p.max_length /2)
                                        END
                                    WHEN 'nchar' THEN
                                         CASE p.max_length  
                                         WHEN -1 THEN 'max'
                                         ELSE CONVERT(nvarchar,p.max_length  /2)
                                         END
                                    WHEN 'varbinary' THEN
                                        CASE p.max_length 
                                        WHEN -1 THEN 'max'
                                        ELSE CONVERT(nchar,p.max_length )
                                        END	  
                                    WHEN 'binary' THEN		
                                        CONVERT(nvarchar,p.max_length )		
                                    WHEN 'char' THEN		
                                        CONVERT(nvarchar,p.max_length )	
                                    ELSE  ''
                                    END 
                                 + ')' AS 'Parameter Type',
                                (SELECT ep.value from sys.extended_properties EP
                                WHERE  ep.major_id = o.object_id AND ep.name='Output') AS 'Output' 
                                FROM sys.objects AS o 
                                JOIN sys.parameters AS p ON o.object_id = p.object_ID
                                Join systypes tp ON tp.xtype = p.system_type_id 
                                WHERE o.type IN ('IF','TF','FN','FS','FT') AND o.name<>'fn_diagramobjects'
                                AND tp.name<>'sysname' AND p.name<>''
                                AND o.name='" + strFunctionName + "'";

            DataTable dt = LoadDataToDataTable(strSql, sqlconn);
            return dt;
        }

        /// <summary>
        /// Lấy ra mảng các cấu trúc của các Function
        /// </summary>
        /// <param name="arrFunctionName"></param>
        /// <param name="sqlconn"></param>
        /// <returns>Mảng các DataTable chứ cấu trúc của Function</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public ArrayList GetArrayFunctionsStructure(ArrayList arrFunctionName, SqlConnection sqlconn)
        {
            ArrayList arrtemp = new ArrayList();
            for (int intindex = 0; intindex < arrFunctionName.Count; intindex++)
            {
                DataTable dt = GetFunctionInform(sqlconn, arrFunctionName[intindex].ToString());
                arrtemp.Add(dt);
            }
            return arrtemp;
        }
    }
}
