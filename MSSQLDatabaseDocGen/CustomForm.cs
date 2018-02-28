using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MSSQLDatabaseDocGen
{
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }

        #region [FormAction]
        private void CustomForm_Load(object sender, EventArgs e)
        {
            if (clsGlobalVariable.STRObjectRead.Contains("Tables"))
            {
                GetTableList();
            }
            else
                TablePannel.Enabled = false;
            if (clsGlobalVariable.STRObjectRead.Contains("Stored Procedures"))
            {
                GetStoreList();
            }
            else
                StorePannel.Enabled = false;
            if (clsGlobalVariable.STRObjectRead.Contains("Functions"))
            {
                GetFunctionList();
            }
            else
                FunctionPannel.Enabled = false;
        }

        private void chklstTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                chkReadAllTable.Checked = false;
            }
            else if (e.CurrentValue == CheckState.Unchecked)
            {
                if (chklstTable.CheckedItems.Count + 1 == chklstTable.Items.Count)
                    chkReadAllTable.Checked = true;
            }
        }

        private void chklstStored_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                chkReadAllStore.Checked = false;
            }
            else if (e.CurrentValue == CheckState.Unchecked)
            {
                if (chklstStored.CheckedItems.Count + 1 == chklstStored.Items.Count)
                    chkReadAllStore.Checked = true;
            }
        }

        private void chklstFunctions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                chkReadAllFunction.Checked = false;
            }
            else if (e.CurrentValue == CheckState.Unchecked)
            {
                if (chklstFunctions.CheckedItems.Count + 1 == chklstFunctions.Items.Count)
                    chkReadAllFunction.Checked = true;
            }
        }

        private void chkReadAllTable_Click(object sender, EventArgs e)
        {
            if (chkReadAllTable.Checked)
            {
                for (int i = 0; i < chklstTable.Items.Count; i++)
                    chklstTable.SetItemChecked(i, true);
            }
            else
            {
                for (int i = 0; i < chklstTable.Items.Count; i++)
                    chklstTable.SetItemChecked(i, false);
            }
        }

        private void chkReadAllStore_Click(object sender, EventArgs e)
        {
            if (chkReadAllStore.Checked)
            {
                for (int i = 0; i < chklstStored.Items.Count; i++)
                    chklstStored.SetItemChecked(i, true);
            }
            else
            {
                for (int i = 0; i < chklstStored.Items.Count; i++)
                    chklstStored.SetItemChecked(i, false);
            }
        }

        private void chkReadAllFunction_Click(object sender, EventArgs e)
        {
            if (chkReadAllFunction.Checked)
            {
                for (int i = 0; i < chklstFunctions.Items.Count; i++)
                    chklstFunctions.SetItemChecked(i, true);
            }
            else
            {
                for (int i = 0; i < chklstFunctions.Items.Count; i++)
                    chklstFunctions.SetItemChecked(i, false);
            }
        }
       
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (chklstTable.Items.Count > 0 && clsGlobalVariable.STRObjectRead.Contains("Tables"))
            {
                clsGlobalVariable.ARRTablesNameCustom = GetCustomInform(ref chkReadAllTable, ref chklstTable, tabTables, "Table");
                if (clsGlobalVariable.ARRTablesNameCustom != null && clsGlobalVariable.ARRTablesNameCustom.Count == 0)
                    return;
            }
            if (chklstStored.Items.Count > 0 && clsGlobalVariable.STRObjectRead.Contains("Stored Procedures"))
            {
                clsGlobalVariable.ARRStoredPreceduresNameCustom = GetCustomInform(ref chkReadAllStore, ref chklstStored, tabStore, "Stored Procedure");
                if (clsGlobalVariable.ARRStoredPreceduresNameCustom != null && clsGlobalVariable.ARRStoredPreceduresNameCustom.Count == 0)
                    return;
            }
            if (chklstFunctions.Items.Count > 0 && clsGlobalVariable.STRObjectRead.Contains("Functions"))
            {
                clsGlobalVariable.ARRFucntionsNameCustom = GetCustomInform(ref chkReadAllFunction, ref chklstFunctions, tabFunction, "Function");
                if (clsGlobalVariable.ARRFucntionsNameCustom != null && clsGlobalVariable.ARRFucntionsNameCustom.Count == 0)
                    return;
            }


            this.Close();

        }

        #endregion

        #region [HamTuTao]
      
        public void GetTableList()
        {
            if (clsGlobalVariable.ARRTablesName != null && clsGlobalVariable.ARRTablesName.Count > 0)
            {
                for (int i = 0; i < clsGlobalVariable.ARRTablesName.Count; i++)
                {
                    chklstTable.Items.Add(clsGlobalVariable.ARRTablesName[i].ToString());
                }
                if (clsGlobalVariable.ARRTablesNameCustom != null && clsGlobalVariable.ARRTablesNameCustom.Count > 0)
                {
                    for (int i = 0; i < chklstTable.Items.Count; i++)
                    {
                        if (clsGlobalVariable.ARRTablesNameCustom.Contains(chklstTable.Items[i].ToString()))
                            chklstTable.SetItemChecked(i, true);
                    }
                    chkReadAllTable.Checked = false;
                    grbTables.Enabled = true;
                }
                if (chkReadAllTable.Checked)
                {
                    for (int i = 0; i < chklstTable.Items.Count; i++)
                        chklstTable.SetItemChecked(i, true);
                }
            }
            else
                TablePannel.Enabled = false;
        }

        public void GetStoreList()
        {
            if (clsGlobalVariable.ARRStoredPreceduresName != null && clsGlobalVariable.ARRStoredPreceduresName.Count > 0)
            {
                for (int i = 0; i < clsGlobalVariable.ARRStoredPreceduresName.Count; i++)
                {
                    chklstStored.Items.Add(clsGlobalVariable.ARRStoredPreceduresName[i].ToString());
                }
                if (clsGlobalVariable.ARRStoredPreceduresNameCustom != null && clsGlobalVariable.ARRStoredPreceduresNameCustom.Count > 0)
                {
                    for (int i = 0; i < chklstStored.Items.Count; i++)
                    {
                        if (clsGlobalVariable.ARRStoredPreceduresNameCustom.Contains(chklstStored.Items[i].ToString()))
                            chklstStored.SetItemChecked(i, true);
                    }
                    chkReadAllStore.Checked = false;
                    grbStores.Enabled = true;
                }
                if (chkReadAllStore.Checked)
                {
                    for (int i = 0; i < chklstStored.Items.Count; i++)
                        chklstStored.SetItemChecked(i, true);
                }
            }
            else
                StorePannel.Enabled = false;

        }

        public void GetFunctionList()
        {
            if (clsGlobalVariable.ARRFucntionsName != null && clsGlobalVariable.ARRFucntionsName.Count > 0)
            {
                for (int i = 0; i < clsGlobalVariable.ARRFucntionsName.Count; i++)
                {
                    chklstFunctions.Items.Add(clsGlobalVariable.ARRFucntionsName[i].ToString());
                }
                if (clsGlobalVariable.ARRFucntionsNameCustom != null && clsGlobalVariable.ARRFucntionsNameCustom.Count > 0)
                {
                    for (int i = 0; i < chklstFunctions.Items.Count; i++)
                    {
                        if (clsGlobalVariable.ARRFucntionsNameCustom.Contains(chklstFunctions.Items[i].ToString()))
                            chklstFunctions.SetItemChecked(i, true);
                    }
                    chkReadAllFunction.Checked = false;
                    grbFunctions.Enabled = true;
                }
                if (chkReadAllFunction.Checked)
                {
                    for (int i = 0; i < chklstFunctions.Items.Count; i++)
                        chklstFunctions.SetItemChecked(i, true);
                }
            }
            else
                FunctionPannel.Enabled = false;

            
        }
       
        public ArrayList GetCustomInform(ref CheckBox chk, ref CheckedListBox chklst, TabPage tabpage, String Object)
        {
            ArrayList arr = new ArrayList();
            if (!chk.Checked)
            {

                if (chklst.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < chklst.CheckedItems.Count; i++)
                    {
                        arr.Add(chklst.CheckedItems[i].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải lựa chọn đối tượng" + Object + " cần đọc trong danh sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tab.SelectedTab = tabpage;
                    return arr;
                }


            }
            else
            {
                arr = null;
            }

            return arr;
        }

        #endregion
                           
    }
}
