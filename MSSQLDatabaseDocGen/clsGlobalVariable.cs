using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLDatabaseDocGen
{
    public  class clsGlobalVariable
    {
        private static ArrayList arrTablesName;
        public static ArrayList ARRTablesName
                                              {set { arrTablesName = value; } 
                                                get { return arrTablesName; } 
                                              }

        private static ArrayList arrTablesNameCustom;
        public static ArrayList ARRTablesNameCustom
        {
            set { arrTablesNameCustom = value; }
            get { return arrTablesNameCustom; }
        }

        private static ArrayList arrTablesStructure;
        public static ArrayList ARRTablesStructure {
                                                    set { arrTablesStructure = value;}
                                                    get { return arrTablesStructure; }
                                                    }
        private static ArrayList arrViewsName;
        public static ArrayList ARRViewsName {
                                                set { arrViewsName = value; }
                                                get { return arrViewsName; }
                                             }

        private static ArrayList arrStoredPreceduresName; 
        public static ArrayList ARRStoredPreceduresName { 
                                                        set{arrStoredPreceduresName = value;} 
                                                        get{return arrStoredPreceduresName;}
                                                        }
        private static ArrayList arrStoredPreceduresNameCustom; 
        public static ArrayList ARRStoredPreceduresNameCustom { 
                                                        set{arrStoredPreceduresNameCustom = value;} 
                                                        get{return arrStoredPreceduresNameCustom;}
                                                        }

        private static ArrayList arrStoredPreceduresStructure; 
        public static ArrayList ARRStoredPreceduresStructure{
                                                              set { arrStoredPreceduresStructure = value; } 
                                                              get { return arrStoredPreceduresStructure;}
                                                             }

        private static ArrayList arrFucntionsName; 
        public static ArrayList ARRFucntionsName{
                                                 set { arrFucntionsName = value; } 
                                                 get { return arrFucntionsName; } 
                                                 }
        private static ArrayList arrFucntionsNameCustom; 
        public static ArrayList ARRFucntionsNameCustom{
                                                 set { arrFucntionsNameCustom = value; } 
                                                 get { return arrFucntionsNameCustom; } 
                                                 }
        private static ArrayList arrFunctionsStructure;
        public static ArrayList ARRFunctionsStructure{ 
                                                        set { arrFunctionsStructure = value; } 
                                                        get { return arrFunctionsStructure; }
                                                        }

        private static DataTable dtTableInform;
        public static DataTable DTTableInform { 
                                                set { dtTableInform = value; } 
                                                get { return dtTableInform; } 
                                                }
        private static DataTable dtViewInform;
        public static DataTable DTViewInform
                                            {
                                                set { dtViewInform = value; }
                                                get { return dtViewInform; }
                                            }
        private static DataTable dtIndexs;
        public static DataTable DTIndexs { 
                                            set { dtIndexs = value; } 
                                            get { return dtIndexs; } 
                                            }
        private static DataTable dtTriggers;
        public static DataTable DTTriggers {
                                            set { dtTriggers = value; } 
                                            get { return dtTriggers; } 
                                            }


        private static String strServerMapPath;
        public static String STRServerMapPath { set { strServerMapPath = value; } get { return strServerMapPath; } }
        private static SqlConnection sqlconn;
        public static SqlConnection SQLconn{ set { sqlconn = value; } get { return sqlconn; } }
        private static String strusername;
        public static String STRUserName { set { strusername = value; } get { return strusername; } }
        public static String[] strVariableType ={ " CHAR ", " NCHAR ", " NVARCHAR2 ", " VARCHAR2 ", " LONG ", 
                                                 " ROW "," LONG ROW ", " NUMBER "," NUMERIC "," FLOAT "," DEC ", " DECIMAL ",
                                                 " INTEGER "," INT ", " SMALLINT ", " REAL "," DOUBLE PRECISION ", " DATE ",
                                                 " TIMESTAMP ", " INTERVAL YEAR ", " INTERVAL DAY "," BFILE "," BLOB ", " CLOB ",
                                                 " NCLOB "," ROWID ", " UROWID "};
        private static OptionObject objectOption;
        public static OptionObject ObjectOption
        {
            set { objectOption = value;}
            get { return  objectOption ;}
        }        

        private static String strObjectRead;
        public static String STRObjectRead
        {
            set { strObjectRead = value; }
            get { return strObjectRead; }
        }        
        public   clsGlobalVariable() { }
        

      
       
    }
}
