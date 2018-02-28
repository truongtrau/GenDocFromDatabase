using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace MSSQLDatabaseDocGen
{
    class ClsOracleDatabaseToDoc
    {
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
        String strBanMauHangTrongDanhSachView= string.Empty;

        //String strServerMapPath = Application.StartupPath;

        ClsOracleDatabaseFunction Orcldbfunc = new ClsOracleDatabaseFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public void ReadAllDataBaseObjectNumber(OracleConnection orclconn)
        {
            clsGlobalVariable.ARRTablesName = Orcldbfunc.GetArrayTablesName(orclconn);                     
            clsGlobalVariable.ARRStoredPreceduresName = Orcldbfunc.GetArrayStoredProceduresName(orclconn);            
            clsGlobalVariable.ARRFucntionsName = Orcldbfunc.GetArrayFunctionsName(orclconn, clsGlobalVariable.STRUserName);
            clsGlobalVariable.DTTriggers = Orcldbfunc.GetTriggerList(orclconn);
            clsGlobalVariable.DTIndexs = Orcldbfunc.GetIndexList(orclconn);
            clsGlobalVariable.ARRViewsName = Orcldbfunc.GetArrayViewName(orclconn);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public void ReadAllObjectStructure(OracleConnection orclconn, String StrObjectRead)
        {
            if (StrObjectRead.Contains("Tables"))
            {
                clsGlobalVariable.DTTableInform = Orcldbfunc.GetTablesInform(orclconn, clsGlobalVariable.ARRTablesName);
            }
            if (StrObjectRead.Contains("Tables Detail"))
            {
                clsGlobalVariable.ARRTablesStructure = Orcldbfunc.GetArrayTablesStructure(clsGlobalVariable.ARRTablesName, orclconn);
            }
            if (StrObjectRead.Contains("Triggers"))
            {
                clsGlobalVariable.DTTriggers = Orcldbfunc.GetTriggerList(orclconn);
            }
            if (StrObjectRead.Contains("Indexs"))
            {
                clsGlobalVariable.DTIndexs = Orcldbfunc.GetIndexList(orclconn);
            }
            if (StrObjectRead.Contains("Views"))
            {
                clsGlobalVariable.DTViewInform = Orcldbfunc.GetViewsInform(orclconn, clsGlobalVariable.ARRViewsName);
            }
            if (StrObjectRead.Contains("Stored Procedures"))
            {
                clsGlobalVariable.ARRStoredPreceduresStructure = Orcldbfunc.GetArrayStoredProceduresStructure(clsGlobalVariable.ARRStoredPreceduresName, orclconn);
            }
            if (StrObjectRead.Contains("Functions"))
            {
                clsGlobalVariable.ARRFunctionsStructure = Orcldbfunc.GetArrayFunctionsStructure(clsGlobalVariable.ARRFucntionsName, orclconn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orclconn"></param>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public Boolean ReadAllDataBaseInform(OracleConnection orclconn)
        {
            try
            {
                
                clsGlobalVariable.ARRTablesName = Orcldbfunc.GetArrayTablesName(orclconn);
                clsGlobalVariable.DTTableInform = Orcldbfunc.GetTablesInform(orclconn, clsGlobalVariable.ARRTablesName);
                clsGlobalVariable.ARRTablesStructure = Orcldbfunc.GetArrayTablesStructure(clsGlobalVariable.ARRTablesName, orclconn);

                clsGlobalVariable.DTTriggers = Orcldbfunc.GetTriggerList(orclconn);
                clsGlobalVariable.DTIndexs = Orcldbfunc.GetIndexList(orclconn);

                clsGlobalVariable.ARRStoredPreceduresName = Orcldbfunc.GetArrayStoredProceduresName(orclconn);
                clsGlobalVariable.ARRStoredPreceduresStructure = Orcldbfunc.GetArrayStoredProceduresStructure(clsGlobalVariable.ARRStoredPreceduresName, orclconn);

                clsGlobalVariable.ARRFucntionsName = Orcldbfunc.GetArrayFunctionsName(orclconn, clsGlobalVariable.STRUserName);
                clsGlobalVariable.ARRFunctionsStructure = Orcldbfunc.GetArrayFunctionsStructure(clsGlobalVariable.ARRFucntionsName, orclconn);
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
                return string.Empty;
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach (DataRow dtwrow in dt.Rows)
            {
                index += 1;
                strtemp1 = strBanMauHangTrongDanhSachBang;
                strtemp1 = strtemp1.Replace("[stt_bang]", index.ToString());
                strtemp1 = strtemp1.Replace("[ten_bang]", dtwrow["table_name"].ToString());
                strtemp1 = strtemp1.Replace("[mo_ta]", dtwrow["comments"].ToString());
                strtemp2 += strtemp1;


            }
            strtemp3 = strBanMauDanhSachBang.Replace("[hang]", strtemp2);
            return strtemp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsGlobalVariable.arrTablesStructure"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        protected String FillTableInformIntoXMLForm(ArrayList arrTablesStructure, ArrayList arrTablesName)
        {
            if(arrTablesStructure==null ||arrTablesStructure.Count ==0 ||arrTablesName ==null || arrTablesName.Count==0)
                return string.Empty;
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            int intindex;
            for (int index = 0; index < arrTablesStructure.Count; index++)
            {
                DataTable dt = (DataTable)arrTablesStructure[index];
                strtemp2 = string.Empty;
                strtemp3 = strBanMauChiTietBang;
                strtemp3 = strtemp3.Replace("[i]", Convert.ToString(index + 1));
                strtemp3 = strtemp3.Replace("[ten_bang]", "Bảng:" + arrTablesName[index].ToString());
                intindex = 0;
                foreach (DataRow drw in dt.Rows)
                {
                    intindex += 1;
                    strtemp1 = strBanMauHangTrongChiTietBang;
                    strtemp1 = strtemp1.Replace("[stt_cot]", intindex.ToString());
                    strtemp1 = strtemp1.Replace("[ma_cot]", drw["Column_Name"].ToString());
                    strtemp1 = strtemp1.Replace("[kieu_cot]", drw["Data_type"].ToString());
                    strtemp1 = strtemp1.Replace("[do_dai]", drw["Data_Length"].ToString());
                    strtemp1 = strtemp1.Replace("[null]", drw["Nullable"].ToString());
                    strtemp1 = strtemp1.Replace("[unique]", drw["unique"].ToString());
                    strtemp1 = strtemp1.Replace("[key]", drw["PK/FK"].ToString());
                    strtemp1 = strtemp1.Replace("[mac_dinh]", drw["Data_Default"].ToString());
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
        protected String FillIndexInformIntoXMLForm(DataTable dt)
        {
            if (dt == null || dt.Rows.Count==0) return string.Empty;

            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int intindex = 0;
            foreach (DataRow drwrow in dt.Rows)
            {

                intindex += 1;                
                strtemp1 = strBanMauHangTrongDanhSachIndex;
                strtemp1 = strtemp1.Replace("[stt_index]", intindex.ToString());
                strtemp1 = strtemp1.Replace("[ten_index]", drwrow["Index_name"].ToString());
                strtemp1 = strtemp1.Replace("[loai_index]", "");
                strtemp1 = strtemp1.Replace("[ten_bang_co_index]", drwrow["Table_name"].ToString());
                strtemp1 = strtemp1.Replace("[ten_cot_lam_index]", drwrow["column_name"].ToString());
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
            if (dt == null || dt.Rows.Count==0)
                return string.Empty;

            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach (DataRow drwrow in dt.Rows)
            {
               
                index += 1;
                strtemp1 = strBanMauHangTrongDanhSachTrigger;
                strtemp1 = strtemp1.Replace("[stt_trigger]", index.ToString());
                strtemp1 = strtemp1.Replace("[ten_trigger]", drwrow["trigger_name"].ToString());
                strtemp1 = strtemp1.Replace("[loai_trigger]", drwrow["Type"].ToString());
                strtemp1 = strtemp1.Replace("[ten_bang_co_trigger]", drwrow["Table_name"].ToString());
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
            if ((arrStoresProcedureStructure == null) || (arrStoresProcedureStructure.Count == 0)
                || (arrStoredPreceduresName == null) || (arrStoredPreceduresName.Count == 0))
                return string.Empty;

            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            for (int intindex = 0; intindex < arrStoresProcedureStructure.Count; intindex++)
            {
                DataTable dt = (DataTable)arrStoresProcedureStructure[intindex];
                String strdaura = string.Empty;
                String strmota = string.Empty;
                foreach (DataRow drwrow in dt.Rows)
                {
                    strtemp1 = strBanMauHangDauVaoStoreFunction2;
                    strtemp1 = strtemp1.Replace("[ten_bien]", drwrow["Parameter name"].ToString());
                    strtemp1 = strtemp1.Replace("[kieu_bien]", drwrow["Parameter Type"].ToString());                   
                    strtemp2 += strtemp1;

                }

                strtemp3 = string.Empty;
                strtemp3 = strBanMauDanhSachStoreFunction2.Replace("[ten_sp]", arrStoredPreceduresName[intindex].ToString());
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
            if ((arrFunctions == null) || (arrFunctions.Count == 0)
                || (arrFucntionsName == null) || (arrFucntionsName.Count == 0))
                return string.Empty;

            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            String strtemp4 = string.Empty;
            for (int intindex = 0; intindex < arrFunctions.Count; intindex++)
            {
                DataTable dt = (DataTable)arrFunctions[intindex];
                String strdaura = string.Empty;
                String strmota = string.Empty;
                foreach (DataRow drwrow in dt.Rows)
                {

                    strtemp1 = strBanMauHangDauVaoStoreFunction2;
                    strtemp1 = strtemp1.Replace("[ten_bien]", drwrow["Parameter name"].ToString());
                    strtemp1 = strtemp1.Replace("[kieu_bien]", drwrow["Parameter Type"].ToString());                   
                    strtemp2 += strtemp1;

                }


                strtemp3 = string.Empty;
                strtemp3 = strBanMauDanhSachStoreFunction2.Replace("[ten_sp]", arrFucntionsName[intindex].ToString());
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
        protected String FillListViewsInformIntoXMLForm(DataTable dt)
        {
            if (dt == null | dt.Rows.Count == 0)
                return string.Empty;
            String strtemp1 = string.Empty;
            String strtemp2 = string.Empty;
            String strtemp3 = string.Empty;
            int index = 0;
            foreach (DataRow dtwrow in dt.Rows)
            {
                index += 1;
                strtemp1 = strBanMauHangTrongDanhSachView;
                strtemp1 = strtemp1.Replace("[stt_view]", index.ToString());
                strtemp1 = strtemp1.Replace("[ten_view]", dtwrow["table_name"].ToString());
                strtemp1 = strtemp1.Replace("[mo_ta]", dtwrow["comments"].ToString());
                strtemp2 += strtemp1;


            }
            strtemp3 = strBanMauDanhSachView.Replace("[hang]", strtemp2);
            return strtemp3;
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
        protected String FillAllInformToXML(OracleConnection  orclconn)
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
                String strtemp3 = FillIndexInformIntoXMLForm(clsGlobalVariable.DTIndexs);
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
        /// <param name="orclconn"></param>
        /// <param name="strOptionPrint"></param>
        /// <returns></returns>
        protected String FillCoustomInformToXML(OracleConnection  orclconn, String strOptionPrint)
        {
            String strtemp = string.Empty;
            String strtemp7 = strBanMau2;
            if (strOptionPrint.Contains("0"))
                strtemp = FillAllInformToXML(orclconn);
            else
            {
                if (strOptionPrint.Contains("1"))
                {
                    String strtemp1 = FillListTablesInformIntoXMLForm(clsGlobalVariable.DTTableInform);
                    strtemp7 = strtemp7.Replace("[danh_sach_bang]", strtemp1);
                }
                if (strOptionPrint.Contains("2"))
                {
                    String strtemp2 = FillTableInformIntoXMLForm(clsGlobalVariable.ARRTablesStructure, clsGlobalVariable.ARRTablesName);
                    strtemp7 = strtemp7.Replace("[chi_tiet_bang]", strtemp2);
                }
                if (strOptionPrint.Contains("3"))
                {
                    String strtemp3 = FillIndexInformIntoXMLForm(clsGlobalVariable.DTIndexs);
                    strtemp7 = strtemp7.Replace("[danh_sach_index]", strtemp3);
                }
                if (strOptionPrint.Contains("4"))
                {
                    String strtemp4 = FillTriggerInformIntoXMLForm(clsGlobalVariable.DTTriggers);
                    strtemp7 = strtemp7.Replace("[danh_sach_trigger]", strtemp4);
                }
                if (strOptionPrint.Contains("5"))
                {
                    String strtemp5 = FillStoreProcedureIntoXMLForm(clsGlobalVariable.ARRStoredPreceduresStructure, clsGlobalVariable.ARRStoredPreceduresName);
                    strtemp7 = strtemp7.Replace("[danh_sach_sp]", strtemp5);
                }
                if (strOptionPrint.Contains("6"))
                {
                    String strtemp6 = FillUserFunctionsIntoXMLForm(clsGlobalVariable.ARRFunctionsStructure, clsGlobalVariable.ARRFucntionsName);
                    strtemp7 = strtemp7.Replace("[danh_sach_function]", strtemp6);
                }
                strtemp = strtemp7;
            }
            return strtemp;
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
            strBanMau1 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Ban mau\\Ban mau thiet ke chi tiet CSDL 1.xml");
            strBanMau2 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Ban mau\\Ban mau thiet ke chi tiet CSDL 2.xml");

            strBanMauDanhSachBang = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachbang.txt");
            strBanMauHangTrongDanhSachBang = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachbang.txt");

            strBanMauChiTietBang = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucchitietbang.txt");
            strBanMauHangTrongChiTietBang = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongchititetbang.txt");

            strBanMauDanhSachIndex = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachindex.txt");
            strBanMauHangTrongDanhSachIndex = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachindex.txt");

            strBanMauDanhSachTrigger = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachtrigger.txt");
            strBanMauHangTrongDanhSachTrigger = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachtrigger.txt");

            strBanMauDanhSachStoreProcedure1 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachstoreprocedure.txt");
            strBanMauHangTrongDanhSachStoreProcedure1 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachstoreprocedure.txt");

            strBanMauDanhSachFunctions1 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachstoreprocedure.txt");
            strBanMauHangTrongDanhSachFunctions1 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachstoreprocedure.txt");


            strBanMauDanhSachStoreFunction2 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucstoreprocedure.txt");
            strBanMauHangDauVaoStoreFunction2 = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangdauvaostoreprocedure.txt");

            strBanMauDanhSachView = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautrucdanhsachview.txt");
            strBanMauHangTrongDanhSachView = f.ReadFileToString(clsGlobalVariable.STRServerMapPath + "\\Cau truc\\cautruchangtrongdanhsachview.txt");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orclconn"></param>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>

        public bool WriteDatabaseStructureToWordFile(OracleConnection  orclconn, String strFilePath, String strOptionPrint)
        {
            ClsFileFunction f = new ClsFileFunction();
            String strContent = string.Empty;
            ReadCacBanMau();
            strContent = FillCoustomInformToXML(orclconn, strOptionPrint);
            if (f.WriteContentToFile(strFilePath, strContent))
            {
                return true;
            }
            return false;
        }

    }
}
