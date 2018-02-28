namespace MSSQLDatabaseDocGen
{
    partial class CustomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomForm));
            this.btnFinish = new System.Windows.Forms.Button();
            this.tabFunction = new System.Windows.Forms.TabPage();
            this.FunctionPannel = new System.Windows.Forms.Panel();
            this.chkReadAllFunction = new System.Windows.Forms.CheckBox();
            this.grbFunctions = new System.Windows.Forms.GroupBox();
            this.chklstFunctions = new System.Windows.Forms.CheckedListBox();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.StorePannel = new System.Windows.Forms.Panel();
            this.chkReadAllStore = new System.Windows.Forms.CheckBox();
            this.grbStores = new System.Windows.Forms.GroupBox();
            this.chklstStored = new System.Windows.Forms.CheckedListBox();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.TablePannel = new System.Windows.Forms.Panel();
            this.chkReadAllTable = new System.Windows.Forms.CheckBox();
            this.grbTables = new System.Windows.Forms.GroupBox();
            this.chklstTable = new System.Windows.Forms.CheckedListBox();
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabFunction.SuspendLayout();
            this.FunctionPannel.SuspendLayout();
            this.grbFunctions.SuspendLayout();
            this.tabStore.SuspendLayout();
            this.StorePannel.SuspendLayout();
            this.grbStores.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.TablePannel.SuspendLayout();
            this.grbTables.SuspendLayout();
            this.Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(295, 345);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 30);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Hoàn tất";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.FunctionPannel);
            this.tabFunction.Location = new System.Drawing.Point(4, 22);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.Size = new System.Drawing.Size(364, 312);
            this.tabFunction.TabIndex = 5;
            this.tabFunction.Text = "Functions";
            this.tabFunction.UseVisualStyleBackColor = true;
            // 
            // FunctionPannel
            // 
            this.FunctionPannel.Controls.Add(this.chkReadAllFunction);
            this.FunctionPannel.Controls.Add(this.grbFunctions);
            this.FunctionPannel.Location = new System.Drawing.Point(3, 3);
            this.FunctionPannel.Name = "FunctionPannel";
            this.FunctionPannel.Size = new System.Drawing.Size(356, 303);
            this.FunctionPannel.TabIndex = 8;
            // 
            // chkReadAllFunction
            // 
            this.chkReadAllFunction.AutoSize = true;
            this.chkReadAllFunction.Checked = true;
            this.chkReadAllFunction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadAllFunction.Location = new System.Drawing.Point(20, 13);
            this.chkReadAllFunction.Name = "chkReadAllFunction";
            this.chkReadAllFunction.Size = new System.Drawing.Size(195, 17);
            this.chkReadAllFunction.TabIndex = 6;
            this.chkReadAllFunction.Text = "Đọc toàn bộ cấu trúc các  Function";
            this.chkReadAllFunction.UseVisualStyleBackColor = true;
            this.chkReadAllFunction.Click += new System.EventHandler(this.chkReadAllFunction_Click);
            // 
            // grbFunctions
            // 
            this.grbFunctions.Controls.Add(this.chklstFunctions);
            this.grbFunctions.Location = new System.Drawing.Point(10, 36);
            this.grbFunctions.Name = "grbFunctions";
            this.grbFunctions.Size = new System.Drawing.Size(336, 256);
            this.grbFunctions.TabIndex = 7;
            this.grbFunctions.TabStop = false;
            this.grbFunctions.Text = "Chọn Function muốn đọc cấu trúc";
            // 
            // chklstFunctions
            // 
            this.chklstFunctions.CheckOnClick = true;
            this.chklstFunctions.FormattingEnabled = true;
            this.chklstFunctions.Location = new System.Drawing.Point(6, 19);
            this.chklstFunctions.Name = "chklstFunctions";
            this.chklstFunctions.Size = new System.Drawing.Size(324, 229);
            this.chklstFunctions.TabIndex = 0;
            this.chklstFunctions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstFunctions_ItemCheck);
            // 
            // tabStore
            // 
            this.tabStore.Controls.Add(this.StorePannel);
            this.tabStore.Location = new System.Drawing.Point(4, 22);
            this.tabStore.Name = "tabStore";
            this.tabStore.Size = new System.Drawing.Size(364, 312);
            this.tabStore.TabIndex = 4;
            this.tabStore.Text = "Stored Procedures";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // StorePannel
            // 
            this.StorePannel.Controls.Add(this.chkReadAllStore);
            this.StorePannel.Controls.Add(this.grbStores);
            this.StorePannel.Location = new System.Drawing.Point(3, 3);
            this.StorePannel.Name = "StorePannel";
            this.StorePannel.Size = new System.Drawing.Size(354, 301);
            this.StorePannel.TabIndex = 6;
            // 
            // chkReadAllStore
            // 
            this.chkReadAllStore.AutoSize = true;
            this.chkReadAllStore.Checked = true;
            this.chkReadAllStore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadAllStore.Location = new System.Drawing.Point(18, 14);
            this.chkReadAllStore.Name = "chkReadAllStore";
            this.chkReadAllStore.Size = new System.Drawing.Size(242, 17);
            this.chkReadAllStore.TabIndex = 4;
            this.chkReadAllStore.Text = "Đọc toàn bộ cấu trúc các  Stored Procedures";
            this.chkReadAllStore.UseVisualStyleBackColor = true;
            this.chkReadAllStore.Click += new System.EventHandler(this.chkReadAllStore_Click);
            // 
            // grbStores
            // 
            this.grbStores.Controls.Add(this.chklstStored);
            this.grbStores.Location = new System.Drawing.Point(8, 37);
            this.grbStores.Name = "grbStores";
            this.grbStores.Size = new System.Drawing.Size(336, 255);
            this.grbStores.TabIndex = 5;
            this.grbStores.TabStop = false;
            this.grbStores.Text = "Chọn Store Procedures muốn đọc cấu trúc";
            // 
            // chklstStored
            // 
            this.chklstStored.CheckOnClick = true;
            this.chklstStored.FormattingEnabled = true;
            this.chklstStored.Location = new System.Drawing.Point(6, 19);
            this.chklstStored.Name = "chklstStored";
            this.chklstStored.Size = new System.Drawing.Size(324, 229);
            this.chklstStored.TabIndex = 0;
            this.chklstStored.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstStored_ItemCheck);
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.TablePannel);
            this.tabTables.Location = new System.Drawing.Point(4, 22);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabTables.Size = new System.Drawing.Size(364, 312);
            this.tabTables.TabIndex = 1;
            this.tabTables.Text = "Tables";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // TablePannel
            // 
            this.TablePannel.Controls.Add(this.chkReadAllTable);
            this.TablePannel.Controls.Add(this.grbTables);
            this.TablePannel.Location = new System.Drawing.Point(3, 3);
            this.TablePannel.Name = "TablePannel";
            this.TablePannel.Size = new System.Drawing.Size(353, 300);
            this.TablePannel.TabIndex = 4;
            // 
            // chkReadAllTable
            // 
            this.chkReadAllTable.AutoSize = true;
            this.chkReadAllTable.Checked = true;
            this.chkReadAllTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadAllTable.Location = new System.Drawing.Point(18, 12);
            this.chkReadAllTable.Name = "chkReadAllTable";
            this.chkReadAllTable.Size = new System.Drawing.Size(175, 17);
            this.chkReadAllTable.TabIndex = 2;
            this.chkReadAllTable.Text = "Đọc toàn bộ cấu trúc các bảng";
            this.chkReadAllTable.UseVisualStyleBackColor = true;
            this.chkReadAllTable.Click += new System.EventHandler(this.chkReadAllTable_Click);
            // 
            // grbTables
            // 
            this.grbTables.Controls.Add(this.chklstTable);
            this.grbTables.Location = new System.Drawing.Point(7, 35);
            this.grbTables.Name = "grbTables";
            this.grbTables.Size = new System.Drawing.Size(336, 255);
            this.grbTables.TabIndex = 3;
            this.grbTables.TabStop = false;
            this.grbTables.Text = "Chọn bảng muốn đọc cấu trúc";
            // 
            // chklstTable
            // 
            this.chklstTable.CheckOnClick = true;
            this.chklstTable.FormattingEnabled = true;
            this.chklstTable.Location = new System.Drawing.Point(6, 19);
            this.chklstTable.Name = "chklstTable";
            this.chklstTable.Size = new System.Drawing.Size(324, 229);
            this.chklstTable.TabIndex = 0;
            this.chklstTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstTable_ItemCheck);
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.tabTables);
            this.Tab.Controls.Add(this.tabStore);
            this.Tab.Controls.Add(this.tabFunction);
            this.Tab.Location = new System.Drawing.Point(5, 3);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(372, 338);
            this.Tab.TabIndex = 0;
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(379, 382);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.Tab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tùy chọn đối tượng";
            this.Load += new System.EventHandler(this.CustomForm_Load);
            this.tabFunction.ResumeLayout(false);
            this.FunctionPannel.ResumeLayout(false);
            this.FunctionPannel.PerformLayout();
            this.grbFunctions.ResumeLayout(false);
            this.tabStore.ResumeLayout(false);
            this.StorePannel.ResumeLayout(false);
            this.StorePannel.PerformLayout();
            this.grbStores.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            this.TablePannel.ResumeLayout(false);
            this.TablePannel.PerformLayout();
            this.grbTables.ResumeLayout(false);
            this.Tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TabPage tabFunction;
        private System.Windows.Forms.TabPage tabStore;
        private System.Windows.Forms.GroupBox grbStores;
        private System.Windows.Forms.CheckedListBox chklstStored;
        private System.Windows.Forms.CheckBox chkReadAllStore;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.GroupBox grbTables;
        private System.Windows.Forms.CheckedListBox chklstTable;
        private System.Windows.Forms.CheckBox chkReadAllTable;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.GroupBox grbFunctions;
        private System.Windows.Forms.CheckedListBox chklstFunctions;
        private System.Windows.Forms.CheckBox chkReadAllFunction;
        private System.Windows.Forms.Panel FunctionPannel;
        private System.Windows.Forms.Panel StorePannel;
        private System.Windows.Forms.Panel TablePannel;
    }
}