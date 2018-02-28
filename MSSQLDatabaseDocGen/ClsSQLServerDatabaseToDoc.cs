using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MSSQLDatabaseDocGen
{
    /// <summary>
    /// Lớp xử lý các thao tác liên quan đến việc xuất ra file word
    /// </summary>
    /// <Modifield>
    /// Người tạo                   ngày tạo            chú thích
    /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
    /// </Modifield>
    class ClsSQLDatabaseToDoc
    {
        public ClsSQLDatabaseToDoc() { }
        ~ClsSQLDatabaseToDoc() { }

        ArrayList ARRTablesName = new ArrayList();
        ArrayList ARRTablesStructure = new ArrayList();

        ArrayList arrStoredPreceduresName = new ArrayList();
        ArrayList ARRStoredPreceduresStructure = new ArrayList();

        ArrayList arrFucntionsName = new ArrayList();
        ArrayList arrFunctionsStructure = new ArrayList();


        DataTable dtTableInform = new DataTable();


        DataTable dtIndexs = new DataTable();
        DataTable dtTriggers = new DataTable();


        String strBanMau1 = string.Empty;
        String strBanMau2 = string.Empty;
        String strBanMauDanhSachBang = string.Empty;
        String strBanMauHangTrongDanhSachBang = string.Empty;
        String strBanMauChiTietBang = string.Empty;
        String strBanMauHangTrongChiTietBang = string.Empty;
        String strBanMauDanhSachIndex = string.Empty;
        String strBanMauHangTrongDanhSachIndex = string.Empty;

        String strBanMauDanhSachStoreProcedure1 = string.Empty;
        String strBanMauHangTrongDanhSachStoreProcedure1 = string.Empty;
        String strBanMauDanhSachFunctions1 = string.Empty;
        String strBanMauHangTrongDanhSachFunctions1 = string.Empty;

        String strBanMauDanhSachStoreFunction2 = string.Empty;
        String strBanMauHangDauVaoStoreFunction2 = string.Empty;


        String strBanMauDanhSachTrigger = string.Empty;
        String strBanMauHangTrongDanhSachTrigger = string.Empty;

        String strBanMauDanhSachView = string.Empty;
        String strBanMauHangTrongDanhSachView = string.Empty;

        String strServerMapPath = Application.StartupPath;

        ClsSQLDataBaseFunction dbfunc = new ClsSQLDataBaseFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public void ReadAllDataBaseObjectNumber(SqlConnection sqlconn)
        {
            //clsGlobalVariable.DTTableInform = dbfunc.GetTablesInform(sqlconn);
            clsGlobalVariable.ARRTablesName = dbfunc.GetArrayTablesName(sqlconn);
            clsGlobalVariable.DTTriggers = dbfunc.GetTriggerList(sqlconn);
            clsGlobalVariable.DTIndexs = dbfunc.GetIndexList(sqlconn);
            clsGlobalVariable.ARRViewsName = dbfunc.GetArrayViewsName(sqlconn);
            clsGlobalVariable.ARRStoredPreceduresName = dbfunc.GetArrayStoredProceduresName(sqlconn);
            clsGlobalVariable.ARRFucntionsName = dbfunc.GetArrayFunctionsName(sqlconn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public void ReadAllObjectStructure(SqlConnection sqlconn,String StrObjectRead)
        {
            if (StrObjectRead.Contains("Tables"))
            {
                clsGlobalVariable.DTTableInform = dbfunc.GetTablesInform(sqlconn, clsGlobalVariable.ARRTablesName);
            }
            if (StrObjectRead.Contains("Tables Detail"))
            {
                clsGlobalVariable.ARRTablesStructure = dbfunc.GetArrayTablesStructure(clsGlobalVariable.ARRTablesName, sqlconn);
            }
            if (StrObjectRead.Contains("Triggers"))
            {
                clsGlobalVariable.DTTriggers = dbfunc.GetTriggerList(sqlconn);
            }
            if (StrObjectRead.Contains("Indexs"))
            {
                clsGlobalVariable.DTIndexs = dbfunc.GetIndexList(sqlconn);
            }
            if (StrObjectRead.Contains("Views"))
            {
                clsGlobalVariable.DTViewInform = dbfunc.GetViewsInform(sqlconn, clsGlobalVariable.ARRViewsName);
            }
            if (StrObjectRead.Contains("Stored Procedures"))
            {
                clsGlobalVariable.ARRStoredPreceduresStructure = dbfunc.GetArrayStoredProceduresStructure(clsGlobalVariable.ARRStoredPreceduresName, sqlconn);
            }
            if (StrObjectRead.Contains("Functions"))
            {
                clsGlobalVariable.ARRFunctionsStructure = dbfunc.GetArrayFunctionsStructure(clsGlobalVariable.ARRFucntionsName, sqlconn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public Boolean ReadAllDataBaseInform(SqlConnection sqlconn)
        {
            try
            {
                
                clsGlobalVariable.ARRTablesName = dbfunc.GetArrayTablesName(sqlconn);
                clsGlobalVariable.DTTableInform = dbfunc.GetTablesInform(sqlconn, clsGlobalVariable.ARRTablesName);
                clsGlobalVariable.ARRTablesStructure = dbfunc.GetArrayTablesStructure(clsGlobalVariable.ARRTablesName, sqlconn);

                clsGlobalVariable.DTTriggers = dbfunc.GetTriggerList(sqlconn);
                clsGlobalVariable.DTIndexs = dbfunc.GetIndexList(sqlconn);

                clsGlobalVariable.ARRStoredPreceduresName = dbfunc.GetArrayStoredProceduresName(sqlconn);
                clsGlobalVariable.ARRStoredPreceduresStructure = dbfunc.GetArrayStoredProceduresStructure(clsGlobalVariable.ARRStoredPreceduresName, sqlconn);

                clsGlobalVariable.ARRFucntionsName = dbfunc.GetArrayFunctionsName(sqlconn);
                clsGlobalVariable.ARRFunctionsStructure = dbfunc.GetArrayFunctionsStructure(clsGlobalVariable.ARRFucntionsName, sqlconn);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
           
            
        }

        /// <summary>
        /// Do cac danh sach cac bang vao trong Form XML
        /// </summary>
        /// <returns>Form XML dang chuoi</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected String FillListTablesInformIntoXMLForm(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return string.Empty;
            }
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach (DataRow dtwrow in dt.Rows)
            {
                    index += 1;
                    strtemp1 = strBanMauHangTrongDanhSachBang;
                    strtemp1 = strtemp1.Replace("[stt_bang]", index.ToString());
                    strtemp1 = strtemp1.Replace("[ten_bang]", dtwrow["name"].ToString());
                    strtemp1 = strtemp1.Replace("[mo_ta]", dtwrow["description"].ToString());
                    strtemp2 += strtemp1;
             

            }
            strtemp3 = strBanMauDanhSachBang.Replace("[hang]", strtemp2);
            return strtemp3;
        }

        /// <summary>
        /// Do cac danh sach cac Views vao trong Form XML
        /// </summary>
        /// <returns>Form XML dang chuoi</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected String FillListViewsInformIntoXMLForm(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return string.Empty;
            }
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach (DataRow dtwrow in dt.Rows)
            {
                index += 1;
                strtemp1 = strBanMauHangTrongDanhSachView;
                strtemp1 = strtemp1.Replace("[stt_view]", index.ToString());
                strtemp1 = strtemp1.Replace("[ten_view]", dtwrow["name"].ToString());
                strtemp1 = strtemp1.Replace("[mo_ta]", dtwrow["description"].ToString());
                strtemp2 += strtemp1;


            }
            strtemp3 = strBanMauDanhSachView.Replace("[hang]", strtemp2);
            return strtemp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsGlobalVariable.ARRTablesStructure"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected String FillTableInformIntoXMLForm(ArrayList ARRTablesStructure, ArrayList ARRTablesName)
        {
            if (ARRTablesStructure == null || ARRTablesStructure.Count == 0 || ARRTablesName == null || ARRTablesName.Count == 0)
            {
                return string.Empty;
            }
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            int intindex;
            for (int index = 0; index < ARRTablesStructure.Count; index++)
            {
                DataTable dt = (DataTable)ARRTablesStructure[index];
                strtemp2 = string.Empty;
                strtemp3 = strBanMauChiTietBang;
                strtemp3 = strtemp3.Replace("[i]", Convert.ToString(index + 1));
                strtemp3 = strtemp3.Replace("[ten_bang]", "Bảng:" + ARRTablesName[index].ToString());
                intindex = 0;
                foreach (DataRow drw in dt.Rows)
                {
                    intindex += 1;
                    strtemp1 = strBanMauHangTrongChiTietBang;
                    strtemp1 = strtemp1.Replace("[stt_cot]", intindex.ToString());
                    strtemp1 = strtemp1.Replace("[ma_cot]", drw["Column Name"].ToString());
                    strtemp1 = strtemp1.Replace("[kieu_cot]", drw["Data Type"].ToString());
                    strtemp1 = strtemp1.Replace("[do_dai]", drw["Length"].ToString());
                    strtemp1 = strtemp1.Replace("[null]", drw["Null"].ToString());
                    strtemp1 = strtemp1.Replace("[unique]", drw["Unique"].ToString());
                    strtemp1 = strtemp1.Replace("[key]", drw["PK/FK"].ToString());
                    strtemp1 = strtemp1.Replace("[mac_dinh]", drw["Default value"].ToString());
                    strtemp1 = strtemp1.Replace("[mo_ta]", drw["Description"].ToString());
                    strtemp2 += strtemp1;


                }

                strtemp3 = strtemp3.Replace("[hang]", strtemp2);
                strtemp4 += strtemp3;
            }
            return strtemp4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected String FillIndexInformIntoXMLForm(DataTable dt,SqlConnection sqlconn)
        {

            if (dt == null || dt.Rows.Count == 0)
                return string.Empty;
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int intindex = 0;
            foreach(DataRow drwrow in dt.Rows)
            {

                intindex += 1;
                string strColName = string.Empty;
               // string strIndexType = string.Empty;
                DataTable dtIndexColumn = dbfunc.GetIndexIncludeColumn(sqlconn,drwrow["Index name"].ToString());

                foreach(DataRow drwrow1 in dtIndexColumn.Rows)
                {
                        if (strColName.Length == 0)
                            strColName = drwrow1["Index Column Name"].ToString();
                        else
                            strColName += ", " + drwrow1["Index Column Name"].ToString();
                        //strIndexType = drdReaderIndex["Type"].ToString();                  
                }
                strtemp1 = strBanMauHangTrongDanhSachIndex;
                strtemp1 = strtemp1.Replace("[stt_index]", intindex.ToString());
                strtemp1 = strtemp1.Replace("[ten_index]", drwrow["Index name"].ToString());
                strtemp1 = strtemp1.Replace("[loai_index]", drwrow["type"].ToString());
                strtemp1 = strtemp1.Replace("[ten_bang_co_index]", drwrow["Table name"].ToString());
                strtemp1 = strtemp1.Replace("[ten_cot_lam_index]", strColName);
                strtemp2 += strtemp1;
            }
            strtemp3 = strBanMauDanhSachIndex.Replace("[hang]", strtemp2);
            return strtemp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public String FillTriggerInformIntoXMLForm(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return string.Empty;
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach(DataRow drwrow in dt.Rows)
            {
                    index += 1;
                    strtemp1 = strBanMauHangTrongDanhSachTrigger;
                    strtemp1 = strtemp1.Replace("[stt_trigger]", index.ToString());
                    strtemp1 = strtemp1.Replace("[ten_trigger]", drwrow["trigger name"].ToString());
                    strtemp1 = strtemp1.Replace("[loai_trigger]", drwrow["Type"].ToString());
                    strtemp1 = strtemp1.Replace("[ten_bang_co_trigger]", drwrow["Table name"].ToString());
                    strtemp1 = strtemp1.Replace("[su_kien]", drwrow["Event"].ToString());
                    strtemp2 += strtemp1;             
            }
            strtemp3 = strBanMauDanhSachTrigger.Replace("[hang]", strtemp2);
            return strtemp3;
        }


        /// <summary>
        /// Do toan bo thong tin vao form XML
        /// </summary>
        /// <returns>Form XML dang chuoi</returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>

        public String FillStoreProcedureIntoXMLForm(ArrayList arrStoresProcedureStructure, ArrayList arrStoredPreceduresName)
        {
            if (arrStoresProcedureStructure == null || arrStoresProcedureStructure.Count == 0 || arrStoredPreceduresName == null || arrStoredPreceduresName.Count == 0)
            {
                return string.Empty;
            }
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            for(int intindex=0; intindex < arrStoresProcedureStructure.Count;intindex++)
            {
                DataTable dt = (DataTable) arrStoresProcedureStructure[intindex];
                String strdaura = string.Empty;
                String strmota = string.Empty;
                foreach(DataRow drwrow in dt.Rows)
                {
                        strtemp1 = strBanMauHangDauVaoStoreFunction2;
                        strtemp1 = strtemp1.Replace("[ten_bien]", drwrow["Parameter name"].ToString());
                        strtemp1 = strtemp1.Replace("[kieu_bien]", drwrow["Parameter Type"].ToString());
                        strdaura = drwrow["Output"].ToString();
                        strmota = drwrow["Description"].ToString();
                        strtemp2 += strtemp1;
                 
                }              

                strtemp3 = string.Empty;
                strtemp3 = strBanMauDanhSachStoreFunction2.Replace("[ten_sp]",arrStoredPreceduresName[intindex].ToString());
                strtemp3 = strtemp3.Replace("[hang]", strtemp2);
                strtemp3 = strtemp3.Replace("[dau_ra]", strdaura);
                strtemp3 = strtemp3.Replace("[mo_ta]", strmota);
                strtemp3 = strtemp3.Replace("[index]", Convert.ToString(intindex + 1));
                strtemp4 += strtemp3;
                strtemp2 = string.Empty;
            }
            return strtemp4;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public String FillUserFunctionsIntoXMLForm(ArrayList arrFunctions, ArrayList arrFucntionsName)
        {
            if (arrFunctions == null || arrFunctions.Count == 0 || arrFucntionsName == null || arrFucntionsName.Count == 0)
            {
                return string.Empty;
            }
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            for (int intindex = 0; intindex < arrFunctions.Count; intindex++)
            {
                DataTable dt = (DataTable)arrFunctions[intindex];
                String strdaura = string.Empty;
                String strmota = string.Empty;
                foreach(DataRow drwrow in dt.Rows)
                {

                        strtemp1 = strBanMauHangDauVaoStoreFunction2;
                        strtemp1 = strtemp1.Replace("[ten_bien]", drwrow["Parameter name"].ToString());
                        strtemp1 = strtemp1.Replace("[kieu_bien]", drwrow["Parameter Type"].ToString());
                        strdaura = drwrow["Output"].ToString();
                        strmota = drwrow["Description"].ToString();
                        strtemp2 += strtemp1;
                  
                }
            

                strtemp3 = string.Empty;
                strtemp3 = strBanMauDanhSachStoreFunction2.Replace("[ten_sp]",arrFucntionsName[intindex].ToString());
                strtemp3 = strtemp3.Replace("[hang]", strtemp2);
                strtemp3 = strtemp3.Replace("[dau_ra]", strdaura);
                strtemp3 = strtemp3.Replace("[mo_ta]", strmota);
                strtemp3 = strtemp3.Replace("[index]", Convert.ToString(intindex + 1));
                strtemp4 += strtemp3;
                strtemp2 = string.Empty;
            }
            return strtemp4;
        }


        /// <summary>
        /// Thủ tục đọc các cấu trúc mẫu từ file mau vào các biến kiểu chuỗi
        /// </summary>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected void ReadCacBanMau()
        {
            ClsFileFunction f = new ClsFileFunction();
            strBanMau1 = f.ReadFileToString(strServerMapPath + "\\Ban mau\\Ban mau thiet ke chi tiet CSDL 1.xml");
            strBanMau2 =f.ReadFileToString(strServerMapPath + "\\Ban mau\\Ban mau thiet ke chi tiet CSDL 2.xml");

            strBanMauDanhSachBang = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucdanhsachbang.txt");
            strBanMauHangTrongDanhSachBang = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachbang.txt");

            strBanMauChiTietBang = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucchitietbang.txt");
            strBanMauHangTrongChiTietBang = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongchititetbang.txt");

            strBanMauDanhSachIndex = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucdanhsachindex.txt");
            strBanMauHangTrongDanhSachIndex = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachindex.txt");

            strBanMauDanhSachTrigger = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucdanhsachtrigger.txt");
            strBanMauHangTrongDanhSachTrigger = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachtrigger.txt");

            strBanMauDanhSachStoreProcedure1 = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucdanhsachstoreprocedure.txt");
            strBanMauHangTrongDanhSachStoreProcedure1 = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachstoreprocedure.txt");

            strBanMauDanhSachFunctions1 = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucdanhsachstoreprocedure.txt");
            strBanMauHangTrongDanhSachFunctions1 =f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachstoreprocedure.txt");


            strBanMauDanhSachStoreFunction2 = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautrucstoreprocedure.txt");
            strBanMauHangDauVaoStoreFunction2 = f.ReadFileToString(strServerMapPath + "\\Cau truc\\cautruchangdauvaostoreprocedure.txt");

            strBanMauDanhSachView = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachview.txt");
            strBanMauHangTrongDanhSachView = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachview.txt");


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
        protected String FillAllInformToXML(SqlConnection sqlconn)
        {
            
            String strtemp0 = strBanMau2;
            if (clsGlobalVariable.STRObjectRead.Contains("Tables"))
            {
                String strtemp1 = FillListTablesInformIntoXMLForm(clsGlobalVariable.DTTableInform);
                strtemp0 = strtemp0.Replace("[danh_sach_bang]", strtemp1);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Tables Detail"))
            {
                String strtemp2 = FillTableInformIntoXMLForm(clsGlobalVariable.ARRTablesStructure, clsGlobalVariable.ARRTablesName);
                strtemp0 = strtemp0.Replace("[chi_tiet_bang]", strtemp2);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Indexs"))
            {
                String strtemp3 = FillIndexInformIntoXMLForm(clsGlobalVariable.DTIndexs, sqlconn);
                strtemp0 = strtemp0.Replace("[danh_sach_index]", strtemp3);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Trigger"))
            {
                String strtemp4 = FillTriggerInformIntoXMLForm(clsGlobalVariable.DTTriggers);
                strtemp0 = strtemp0.Replace("[danh_sach_trigger]", strtemp4);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Stored Procedures"))
            {
                String strtemp8 = FillStoreProcedureIntoXMLForm(clsGlobalVariable.ARRStoredPreceduresStructure, clsGlobalVariable.ARRStoredPreceduresName);
                strtemp0 = strtemp0.Replace("[danh_sach_sp]", strtemp8);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Functions"))
            {
                String strtemp9 = FillUserFunctionsIntoXMLForm(clsGlobalVariable.ARRFunctionsStructure, clsGlobalVariable.ARRFucntionsName);
                strtemp0 = strtemp0.Replace("[danh_sach_function]", strtemp9);
            }
            if (clsGlobalVariable.STRObjectRead.Contains("Views"))
            {
                String strtemp10 = FillListViewsInformIntoXMLForm(clsGlobalVariable.DTViewInform);
                strtemp0 = strtemp0.Replace("[danh_sach_view]", strtemp10);
            }                                                                 

            return strtemp0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <param name="strOptionPrint"></param>
        /// <returns></returns>
        protected String FillCoustomInformToXML(SqlConnection sqlconn, String strOptionPrint)
        {
            String strtemp = string.Empty;
            String strtemp7 = strBanMau2;
            if (strOptionPrint.Contains("0"))
                strtemp = FillAllInformToXML(sqlconn);
            else
            {
                if (strOptionPrint.Contains("1") && clsGlobalVariable.STRObjectRead.Contains("Tables"))
                {
                    String strtemp1 = FillListTablesInformIntoXMLForm(clsGlobalVariable.DTTableInform);
                    strtemp7 = strtemp7.Replace("[danh_sach_bang]", strtemp1);
                }
                if (strOptionPrint.Contains("2") && clsGlobalVariable.STRObjectRead.Contains("Tables Detail"))
                {
                    String strtemp2 = FillTableInformIntoXMLForm(clsGlobalVariable.ARRTablesStructure, clsGlobalVariable.ARRTablesName);
                    strtemp7 = strtemp7.Replace("[chi_tiet_bang]", strtemp2);
                }
                if (strOptionPrint.Contains("3") && clsGlobalVariable.STRObjectRead.Contains("Indexs"))
                {
                    String strtemp3 = FillIndexInformIntoXMLForm(clsGlobalVariable.DTIndexs, sqlconn);
                    strtemp7 = strtemp7.Replace("[danh_sach_index]", strtemp3);
                }
                if (strOptionPrint.Contains("4") && clsGlobalVariable.STRObjectRead.Contains("Trigger"))
                {
                    String strtemp4 = FillTriggerInformIntoXMLForm(clsGlobalVariable.DTTriggers);
                    strtemp7 = strtemp7.Replace("[danh_sach_trigger]", strtemp4);
                }
                if (strOptionPrint.Contains("5") && clsGlobalVariable.STRObjectRead.Contains("Stored Procedures"))
                {
                    String strtemp5 = FillStoreProcedureIntoXMLForm(clsGlobalVariable.ARRStoredPreceduresStructure, clsGlobalVariable.ARRStoredPreceduresName);
                    strtemp7 = strtemp7.Replace("[danh_sach_sp]", strtemp5);
                }
                if (strOptionPrint.Contains("6") && clsGlobalVariable.STRObjectRead.Contains("Functions"))
                {
                    String strtemp6 = FillUserFunctionsIntoXMLForm(clsGlobalVariable.ARRFunctionsStructure, clsGlobalVariable.ARRFucntionsName);
                    strtemp7 = strtemp7.Replace("[danh_sach_function]", strtemp6);
                }
                if (strOptionPrint.Contains("7") && clsGlobalVariable.STRObjectRead.Contains("Views"))
                {
                    String strtemp6 = FillListViewsInformIntoXMLForm(clsGlobalVariable.DTViewInform);
                    strtemp7 = strtemp7.Replace("[danh_sach_view]", strtemp6);
                }
                strtemp = strtemp7;
            }
            return strtemp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        
        public bool WriteDatabaseStructureToWordFile(SqlConnection sqlconn, String strFilePath,String strOptionPrint)
        {
            ClsFileFunction f = new ClsFileFunction();
            String strContent = string.Empty;            
            ReadCacBanMau();
            strContent = FillCoustomInformToXML(sqlconn, strOptionPrint);                                         
            if (f.WriteContentToFile(strFilePath, strContent))
            {                               
                return true;
            }
            return false;
        }

    }
}
