using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MSSQLDatabaseDocGen
{
    public partial class ListObject : Form
    {
        public ListObject()
        {
            InitializeComponent();
        }

        public void GetObjectNumber()
        {            
            AddItem("Tables",clsGlobalVariable.ARRTablesName.Count.ToString());
            AddItem("Views", clsGlobalVariable.ARRViewsName.Count.ToString());
            AddItem("Indexs", clsGlobalVariable.DTIndexs.Rows.Count.ToString());
            AddItem("Triggers", clsGlobalVariable.DTTriggers.Rows.Count.ToString());
            AddItem("Stored Procedures", clsGlobalVariable.ARRStoredPreceduresName.Count.ToString());
            AddItem("Functions", clsGlobalVariable.ARRFucntionsName.Count.ToString());                
        }
        public void AddItem(String objectname, String number)
        {

            GlacialComponents.Controls.GLItem Item = new GlacialComponents.Controls.GLItem();           
            GlacialComponents.Controls.GLSubItem subItem1 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem subItem2 = new GlacialComponents.Controls.GLSubItem();
            subItem1.Text = objectname;
            subItem1.Checked = true;
            subItem2.Text = number;
            Item.SubItems.AddRange(new GlacialComponents.Controls.GLSubItem[] {subItem1,subItem2});            
            objectList.Items.Add(Item);
        }
        private void ListObject_Load(object sender, EventArgs e)
        {
            GetObjectNumber();
        }

        private void btnCustomObject_Click(object sender, EventArgs e)
        {
            GetSelectObject();
            CustomForm cusfrm = new CustomForm();
            cusfrm.ShowDialog();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (GetSelectObject() == 0)
            {
                MessageBox.Show("Bạn phải chọn ít nhất một đối tượng trong danh sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsGlobalVariable.ARRTablesNameCustom != null && clsGlobalVariable.ARRTablesNameCustom.Count > 0)
            {
                clsGlobalVariable.ARRTablesName.Clear();
                clsGlobalVariable.ARRTablesName = clsGlobalVariable.ARRTablesNameCustom;
            }
            if (clsGlobalVariable.ARRStoredPreceduresNameCustom != null && clsGlobalVariable.ARRStoredPreceduresNameCustom.Count > 0)
            {
                clsGlobalVariable.ARRStoredPreceduresName.Clear();
                clsGlobalVariable.ARRStoredPreceduresName = clsGlobalVariable.ARRStoredPreceduresNameCustom;
            }
            if (clsGlobalVariable.ARRFucntionsNameCustom != null && clsGlobalVariable.ARRFucntionsNameCustom.Count > 0)
            {
                clsGlobalVariable.ARRFucntionsName.Clear();
                clsGlobalVariable.ARRFucntionsName = clsGlobalVariable.ARRFucntionsNameCustom;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public int GetSelectObject()
        {
            clsGlobalVariable.STRObjectRead = string.Empty;
            int checknumber = 0;
            foreach (GlacialComponents.Controls.GLItem Item in objectList.Items)
            {
                if (Item.SubItems[0].Checked)
                {
                    clsGlobalVariable.STRObjectRead += Item.SubItems[0].Text + ",";
                    checknumber += 1;
                }
            }
            return checknumber;
        }
    }
}
