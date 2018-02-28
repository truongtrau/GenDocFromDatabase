using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace MSSQLDatabaseDocGen
{
    public partial class PrintDialog : Form
    {
        public PrintDialog()
        {
            InitializeComponent();
        }
        public String filepath;
        public String FilePath { set { filepath = value; } get { return filepath; } }
        public SqlConnection sqlConn;
        public SqlConnection SQLConn { set { sqlConn = value; } get { return sqlConn; } }
        public OracleConnection oracleConn;
        public OracleConnection ORACLEConn { set { oracleConn = value; } get { return oracleConn; } }
        public String strOption = string.Empty;
        private void rdoCoustom_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;                                                        
           
        }

        private void rdoAll_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;        
               
           
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public String GetOptionString()
        {
            String strtemp = string.Empty;
            if (rdoCoustom.Checked)
            {
                if (chkTable.Checked)
                    strtemp += "1";
                if (chkTableDetail.Checked)
                    strtemp += "2";
                if (chkIndexes.Checked)
                    strtemp += "3";
                if (chkTriggers.Checked)
                    strtemp += "4";
                if (chkStored.Checked)
                    strtemp += "5";
                if (chkFunctions.Checked)
                    strtemp += "6";

            }
            else
                strtemp = "0";
            return strtemp;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClsSQLDatabaseToDoc SQLdbtoword = new ClsSQLDatabaseToDoc();
            ClsOracleDatabaseToDoc ORACLEdbtoword = new ClsOracleDatabaseToDoc();
            ClsFileFunction ffunc = new ClsFileFunction();
            String strOption = GetOptionString();
            if (strOption.Contains("0"))
            {
                if (ffunc.CopyFile(clsGlobalVariable.STRServerMapPath + "\\temp.doc", filepath))
                {

                    if (MessageBox.Show("In File Thành Công!\nBạn có muốn mở File để xem? ", "Kết quả", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;                       
                        proc.StartInfo.FileName = filepath;
                        proc.Start();
                        //proc.WaitForExit();
                    }
                }
                else
                {
                  
                    MessageBox.Show("In File Thất Bại!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (sqlConn != null)
                {
                    if (SQLdbtoword.WriteDatabaseStructureToWordFile(sqlConn, filepath, strOption))
                    {

                        if (MessageBox.Show("In File Thành Công!\nBạn có muốn mở File để xem? ", "Kết quả",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            try
                            {

                                proc.EnableRaisingEvents = false;

                                proc.StartInfo.FileName = filepath;

                                proc.Start();
                            }
                            catch (Exception ex)
                            {
                            }
                            finally { proc.Dispose(); }

                        }
                    }
                    else
                    {

                        MessageBox.Show("In File Thất Bại!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (oracleConn != null)
                {
                    if (ORACLEdbtoword.WriteDatabaseStructureToWordFile(oracleConn, filepath, strOption))
                    {

                        if (MessageBox.Show("In File Thành Công!\nBạn có muốn mở File để xem? ", "Kết quả",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            try
                            {

                                proc.EnableRaisingEvents = false;

                                proc.StartInfo.FileName = filepath;

                                proc.Start();
                            }
                            catch (Exception ex)
                            {
                            }
                            finally { proc.Dispose(); }

                        }
                    }
                    else
                    {

                        MessageBox.Show("In File Thất Bại!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.Dispose();
        }

        private void PrintDialog_Load(object sender, EventArgs e)
        {
            if (clsGlobalVariable.STRObjectRead.Contains("Tables"))
                chkTable.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Tables Detail"))
               chkTableDetail.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Indexs"))
               chkIndexes.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Triggers"))
                chkTriggers.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Functions"))
                chkFunctions.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Views"))
               chkView.Enabled = true;
            if (clsGlobalVariable.STRObjectRead.Contains("Stored Procedures"))
                chkStored.Enabled = true;

        }
    }
}