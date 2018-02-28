using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MSSQLDatabaseDocGen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public String strFilePath = string.Empty;
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        public void SetFilePath(String filepath)
        {
            strFilePath = filepath;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            winWordControl1.RestoreCommandBars();
            winWordControl1.CloseControl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                winWordControl1.CloseControl();

            }
            catch { }
            finally
            {
                winWordControl1.document = null;
                WinWordControl.WinWordControl.wd = null;
                WinWordControl.WinWordControl.wordWnd = 0;
                
            }
            try
            {

                //Load the template used for testing.               
                winWordControl1.LoadDocument(strFilePath);
                winWordControl1.document.CommandBars["Menu bar"].Enabled = false;
                winWordControl1.document.CommandBars["Requirements"].Enabled = false;
                //winWordControl1.document.ActiveWindow.Application.CommandBars["Menu Bar"].Enabled = false;
               
            }
            catch (Exception ex) { String err = ex.Message; }
            timer1.Stop();
        }

    }
}