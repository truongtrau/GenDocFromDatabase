using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MSSQLDatabaseDocGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            
        }
        String strServerMapPath = Application.StartupPath;

        SqlConnection sqlcon = null;
        OracleConnection orclcon = null;
        ClsSQLDataBaseFunction SQLdbfunc = new ClsSQLDataBaseFunction();
        ClsOracleDatabaseFunction ORACLEdbfunc = new ClsOracleDatabaseFunction();
        ClsFileFunction ffunc = new ClsFileFunction();
        String StrServer = string.Empty;
        String StrDataBasename = string.Empty;
        String StrUserName = string.Empty;
        String StrPassWord = string.Empty;
        String strdatabasetype = string.Empty;
        Boolean blerror = true;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!CheckInputData())
            {
                MessageBox.Show("Bạn nhập thiếu thông tin cần thiết", "Lỗi dữ liệu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            txtDataBaseName.Enabled = false;
            txtPassWord.Enabled = false;
            txtServer.Enabled = false;
            txtUserName.Enabled = false;
            cbDatabaseType.Enabled = false;
            btnCheck.Enabled = false;
            btnExit.Enabled = false;
            btnReset.Enabled = false;
            btnpreview.Enabled = false;
           
            tStrlblstatus.Text = "Đang kết nối...";
            btnPrint.Enabled = false;
            StrServer = txtServer.Text;
            StrDataBasename = txtDataBaseName.Text;
            StrUserName = txtUserName.Text;
            StrPassWord = txtPassWord.Text;
            strdatabasetype = cbDatabaseType.Text.Trim();
            if (clsGlobalVariable.ARRFucntionsNameCustom != null)
                clsGlobalVariable.ARRFucntionsNameCustom.Clear();
            if (clsGlobalVariable.ARRStoredPreceduresNameCustom != null)
                clsGlobalVariable.ARRStoredPreceduresNameCustom.Clear();
            if (clsGlobalVariable.ARRTablesNameCustom != null)
                clsGlobalVariable.ARRTablesNameCustom.Clear();
            
       
            bgdWorker.RunWorkerAsync();
            while (bgdWorker.IsBusy)
                Application.DoEvents();
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbDatabaseType.SelectedIndex == 1 && cbDatabaseType.Text.Trim() == "SQL SERVER")
            {
                sqlcon.Open();
                SaveFileDialog sfdFileSave = new SaveFileDialog();
                sfdFileSave.Filter = "(.doc)|*.doc";
                sfdFileSave.Title = "Lưu File vào";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    PrintDialog frPrint = new PrintDialog();
                    frPrint.FilePath = sfdFileSave.FileName;
                    frPrint.sqlConn = sqlcon;
                    frPrint.ShowDialog();

                }
                sqlcon.Close();
            }
            else if (cbDatabaseType.SelectedIndex == 2 && cbDatabaseType.Text.Trim() == "ORACLE")
            {
                orclcon.Open();
                SaveFileDialog sfdFileSave = new SaveFileDialog();
                sfdFileSave.Filter = "(.doc)|*.doc";
                sfdFileSave.Title = "Lưu File vào";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    PrintDialog frPrint = new PrintDialog();
                    frPrint.FilePath = sfdFileSave.FileName;
                    frPrint.oracleConn = orclcon;
                    frPrint.ShowDialog();

                }
                orclcon.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDataBaseName.Text = "";
            txtPassWord.Text = "";
            txtServer.Text = "";
            txtUserName.Text = "";
            btnPrint.Enabled = false;
            btnpreview.Enabled = false;
            ffunc.DeleteFile(strServerMapPath + "\\temp.doc");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ffunc.DeleteFile(strServerMapPath + "\\temp.doc");
            Application.ExitThread();
        }

        protected bool CheckInputData()
        {
            if (cbDatabaseType.SelectedIndex == 0 || cbDatabaseType.Text.Trim() == "")
            {
                cbDatabaseType.Focus();
                return false;
            }
            if (txtServer.Text.Trim() == "")
            {
                txtServer.Focus();
                return false;
            }
            if (txtDataBaseName.Text.Trim() == "" && cbDatabaseType.Text.Trim()=="SQL SERVER")
            {
                txtDataBaseName.Focus();
                return false;
            }
            return true;
        }

        private void tacgiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nguyễn Trung Tuyến\nTrung Tâm Giải Pháp Chính Phủ(TV1)", "Tác giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            Form2 frpreview = new Form2();
            frpreview.SetFilePath(strServerMapPath + "\\temp.doc");
            frpreview.ShowDialog();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ReadOptionObject();
            if (File.Exists(strServerMapPath + "\\temp.doc"))
                File.Delete(strServerMapPath + "\\temp.doc");
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("MSSQLDatabaseDocGen");
            if (proc.Length > 1)
            {
                MessageBox.Show("Chương trình đã được khởi động", "MSSQL Database DocGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Application.ExitThread();
            }
            cbDatabaseType.SelectedIndex =0;
        }

        private void cbDatabaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void bgdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            clsGlobalVariable.STRServerMapPath = strServerMapPath;
            clsGlobalVariable.STRUserName = StrUserName;

           
            if (strdatabasetype == "SQL SERVER")
            {
                if (SQLdbfunc.KetNoiCSDL(StrServer, StrDataBasename, StrUserName, StrPassWord, ref sqlcon))
                {
                    tStrlblstatus.Text = "Đang đọc CSDL...";
                    MessageBox.Show("Kết nối thành công tới CSDL\nBắt đầu tiến hành đọc cấu trúc của CSDL", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClsSQLDatabaseToDoc SQLdbtoword = new ClsSQLDatabaseToDoc();
                    SQLdbtoword.ReadAllDataBaseObjectNumber(sqlcon);
                    ListObject frmoblist = new ListObject();
                    frmoblist.ShowDialog();
                    if (frmoblist.DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (clsGlobalVariable.STRObjectRead.Contains("Tables"))
                        {
                            if (MessageBox.Show("Bạn có muốn đọc cấu trúc của từng bảng không?", "Cấu trúc bảng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                clsGlobalVariable.STRObjectRead += "Tables Detail";
                        }
                        SQLdbtoword.ReadAllObjectStructure(sqlcon, clsGlobalVariable.STRObjectRead);
                        if (File.Exists(strServerMapPath + "\\temp.doc"))
                            File.Delete(strServerMapPath + "\\temp.doc");
                        SQLdbtoword.WriteDatabaseStructureToWordFile(sqlcon, strServerMapPath + "\\temp.doc", "0");
                        MessageBox.Show("Đọc cấu trúc CSDL thành công", "Đã đọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    sqlcon.Close();

                    blerror = false;
                }
                else
                {
                    MessageBox.Show("Không kết nối được tới CSDL đã chọn", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else if (strdatabasetype == "ORACLE")
            {
                if (ORACLEdbfunc.KetNoiCSDL(StrServer, StrDataBasename, StrUserName, StrPassWord, ref orclcon))
                {
                    tStrlblstatus.Text = "Đang đọc CSDL...";

                    MessageBox.Show("Kết nối thành công tới CSDL\nBắt đầu tiến hành đọc cấu trúc của CSDL", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ptboxprocess.Visible = true;
                    ClsOracleDatabaseToDoc ORACLEdbtoword = new ClsOracleDatabaseToDoc();
                    ORACLEdbtoword.ReadAllDataBaseObjectNumber(orclcon);
                    ListObject frmoblist = new ListObject();
                    frmoblist.ShowDialog();
                    if (frmoblist.DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (clsGlobalVariable.STRObjectRead.Contains("Tables"))
                        {
                            if (MessageBox.Show("Bạn có muốn đọc cấu trúc của từng bảng không?", "Cấu trúc bảng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                clsGlobalVariable.STRObjectRead += "Tables Detail";
                        }
                        ORACLEdbtoword.ReadAllObjectStructure(orclcon, clsGlobalVariable.STRObjectRead);
                        if (File.Exists(strServerMapPath + "\\temp.doc"))
                            File.Delete(strServerMapPath + "\\temp.doc");
                        ORACLEdbtoword.WriteDatabaseStructureToWordFile(orclcon, strServerMapPath + "\\temp.doc", "0");
                        MessageBox.Show("Đọc cấu trúc CSDL thành công", "Đã đọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    orclcon.Close();

                    blerror = false;
                }
                else
                {
                    MessageBox.Show("Không kết nối được tới CSDL đã chọn", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
        }

        private void bgdWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ptboxprocess.Visible = true;
            bgdWorker.ReportProgress(100);            
        }

        private void bgdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCheck.Enabled = true;
            btnExit.Enabled = true;
            btnReset.Enabled = true;
            ptboxprocess.Visible = false;
            txtDataBaseName.Enabled = true;
            txtPassWord.Enabled = true;
            txtServer.Enabled = true;
            txtUserName.Enabled = true;
            cbDatabaseType.Enabled = true;
            if (blerror)
            {
                //MessageBox.Show("Không kết nối được tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tStrlblstatus.Text = "Ready";
                btnPrint.Enabled = false;
                btnpreview.Enabled = false;
            }
            else
            {
                btnPrint.Enabled = true;
                btnpreview.Enabled = true;
                tStrlblstatus.Text = "Đã kết nối";
            }
        }

       
        //private void ReadOptionObject()
        //{
        //    Stream stream = null;
        //    String OpFilename = Application.StartupPath;
        //    OpFilename += "\\option.dat";
        //    if (File.Exists(OpFilename))
        //    {
        //        try
        //        {
        //            IFormatter formatte = new BinaryFormatter();
        //            stream = new FileStream(OpFilename, FileMode.Open, FileAccess.Read, FileShare.None);
        //            clsGlobalVariable.ObjectOption = (OptionObject)formatte.Deserialize(stream);
        //            stream.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //    }
        //    else
        //    {
        //        try
        //        {
        //            IFormatter formatte = new BinaryFormatter();
        //            stream = new FileStream(OpFilename, FileMode.Create, FileAccess.Write, FileShare.None);
        //            OptionObject optob = new OptionObject();
        //            formatte.Serialize(stream, optob);
        //            clsGlobalVariable.ObjectOption = optob;
        //            stream.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
        //}

    }
}