namespace MSSQLDatabaseDocGen
{
    partial class PrintDialog
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
            this.rdoCoustom = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.chkFunctions = new System.Windows.Forms.CheckBox();
            this.chkStored = new System.Windows.Forms.CheckBox();
            this.chkTriggers = new System.Windows.Forms.CheckBox();
            this.chkIndexes = new System.Windows.Forms.CheckBox();
            this.chkTableDetail = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoCoustom
            // 
            this.rdoCoustom.AutoSize = true;
            this.rdoCoustom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoCoustom.Location = new System.Drawing.Point(19, 19);
            this.rdoCoustom.Name = "rdoCoustom";
            this.rdoCoustom.Size = new System.Drawing.Size(74, 19);
            this.rdoCoustom.TabIndex = 0;
            this.rdoCoustom.Text = "Chỉ in ra:";
            this.rdoCoustom.UseVisualStyleBackColor = true;
            this.rdoCoustom.Click += new System.EventHandler(this.rdoCoustom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Controls.Add(this.rdoCoustom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 166);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn in";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoAll.Location = new System.Drawing.Point(19, 141);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(67, 19);
            this.rdoAll.TabIndex = 7;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "In tất cả";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.rdoAll_Click);
            // 
            // chkFunctions
            // 
            this.chkFunctions.AutoSize = true;
            this.chkFunctions.Enabled = false;
            this.chkFunctions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkFunctions.Location = new System.Drawing.Point(153, 52);
            this.chkFunctions.Name = "chkFunctions";
            this.chkFunctions.Size = new System.Drawing.Size(80, 19);
            this.chkFunctions.TabIndex = 6;
            this.chkFunctions.Text = "Functions";
            this.chkFunctions.UseVisualStyleBackColor = true;
            // 
            // chkStored
            // 
            this.chkStored.AutoSize = true;
            this.chkStored.Enabled = false;
            this.chkStored.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkStored.Location = new System.Drawing.Point(153, 29);
            this.chkStored.Name = "chkStored";
            this.chkStored.Size = new System.Drawing.Size(122, 19);
            this.chkStored.TabIndex = 5;
            this.chkStored.Text = "Stored Procedure";
            this.chkStored.UseVisualStyleBackColor = true;
            // 
            // chkTriggers
            // 
            this.chkTriggers.AutoSize = true;
            this.chkTriggers.Enabled = false;
            this.chkTriggers.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkTriggers.Location = new System.Drawing.Point(153, 5);
            this.chkTriggers.Name = "chkTriggers";
            this.chkTriggers.Size = new System.Drawing.Size(124, 19);
            this.chkTriggers.TabIndex = 4;
            this.chkTriggers.Text = "Danh sách trigger";
            this.chkTriggers.UseVisualStyleBackColor = true;
            // 
            // chkIndexes
            // 
            this.chkIndexes.AutoSize = true;
            this.chkIndexes.Enabled = false;
            this.chkIndexes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkIndexes.Location = new System.Drawing.Point(9, 53);
            this.chkIndexes.Name = "chkIndexes";
            this.chkIndexes.Size = new System.Drawing.Size(118, 19);
            this.chkIndexes.TabIndex = 3;
            this.chkIndexes.Text = "Danh sách Index";
            this.chkIndexes.UseVisualStyleBackColor = true;
            // 
            // chkTableDetail
            // 
            this.chkTableDetail.AutoSize = true;
            this.chkTableDetail.Enabled = false;
            this.chkTableDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkTableDetail.Location = new System.Drawing.Point(9, 29);
            this.chkTableDetail.Name = "chkTableDetail";
            this.chkTableDetail.Size = new System.Drawing.Size(117, 19);
            this.chkTableDetail.TabIndex = 2;
            this.chkTableDetail.Text = "Chi tiết các bảng";
            this.chkTableDetail.UseVisualStyleBackColor = true;
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Enabled = false;
            this.chkTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkTable.Location = new System.Drawing.Point(9, 5);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(139, 19);
            this.chkTable.TabIndex = 1;
            this.chkTable.Text = "Danh sách các bảng";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPrint.Location = new System.Drawing.Point(166, 181);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Location = new System.Drawing.Point(247, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkView);
            this.panel1.Controls.Add(this.chkTable);
            this.panel1.Controls.Add(this.chkFunctions);
            this.panel1.Controls.Add(this.chkTableDetail);
            this.panel1.Controls.Add(this.chkStored);
            this.panel1.Controls.Add(this.chkIndexes);
            this.panel1.Controls.Add(this.chkTriggers);
            this.panel1.Location = new System.Drawing.Point(29, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 100);
            this.panel1.TabIndex = 8;
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Enabled = false;
            this.chkView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkView.Location = new System.Drawing.Point(9, 79);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(118, 19);
            this.chkView.TabIndex = 7;
            this.chkView.Text = "Danh sách  View";
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // PrintDialog
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 224);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintDialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PrintDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoCoustom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.CheckBox chkFunctions;
        private System.Windows.Forms.CheckBox chkStored;
        private System.Windows.Forms.CheckBox chkTriggers;
        private System.Windows.Forms.CheckBox chkIndexes;
        private System.Windows.Forms.CheckBox chkTableDetail;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkView;
    }
}