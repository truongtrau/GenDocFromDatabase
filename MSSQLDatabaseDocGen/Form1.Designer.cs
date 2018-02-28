namespace MSSQLDatabaseDocGen
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tStrlblstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tacgiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.thongTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDatabaseType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnpreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tepTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ptboxprocess = new System.Windows.Forms.PictureBox();
            this.bgdWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxprocess)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên CSDL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Máy chủ CSDL:";
            // 
            // tStrlblstatus
            // 
            this.tStrlblstatus.Name = "tStrlblstatus";
            this.tStrlblstatus.Size = new System.Drawing.Size(38, 17);
            this.tStrlblstatus.Text = "Ready";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStrlblstatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 269);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tacgiaToolStripMenuItem
            // 
            this.tacgiaToolStripMenuItem.Name = "tacgiaToolStripMenuItem";
            this.tacgiaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tacgiaToolStripMenuItem.Text = "Tác giả";
            this.tacgiaToolStripMenuItem.Click += new System.EventHandler(this.tacgiaToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(9, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // txtServer
            // 
            this.txtServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtServer.Location = new System.Drawing.Point(129, 53);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(173, 22);
            this.txtServer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtServer, "tên hoặc địa chỉ mấy chủ CSDL");
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(129, 133);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(173, 22);
            this.txtPassWord.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtPassWord, "mã người dùng");
            this.txtPassWord.WordWrap = false;
            // 
            // thongTinToolStripMenuItem
            // 
            this.thongTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tacgiaToolStripMenuItem});
            this.thongTinToolStripMenuItem.Name = "thongTinToolStripMenuItem";
            this.thongTinToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.thongTinToolStripMenuItem.Text = "Thông tin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDatabaseType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtPassWord);
            this.groupBox1.Controls.Add(this.txtDataBaseName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(10, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về CSDL";
            // 
            // cbDatabaseType
            // 
            this.cbDatabaseType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbDatabaseType.FormattingEnabled = true;
            this.cbDatabaseType.Items.AddRange(new object[] {
            "Lựa chọn...",
            "SQL SERVER",
            "ORACLE"});
            this.cbDatabaseType.Location = new System.Drawing.Point(129, 24);
            this.cbDatabaseType.Name = "cbDatabaseType";
            this.cbDatabaseType.Size = new System.Drawing.Size(121, 23);
            this.cbDatabaseType.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cbDatabaseType, "Chọn Hệ Quản trị CSDL");
            this.cbDatabaseType.SelectedIndexChanged += new System.EventHandler(this.cbDatabaseType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(11, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hệ CSDL:";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(129, 79);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(173, 22);
            this.txtDataBaseName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtDataBaseName, "Tên CSDL");
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(129, 106);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(173, 22);
            this.txtUserName.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtUserName, "tên người dùng");
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Image = global::MSSQLDatabaseDocGen.Properties.Resources.checkconnect1;
            this.btnCheck.Location = new System.Drawing.Point(11, 201);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(59, 54);
            this.btnCheck.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnCheck, "Kiểm tra kết nối tới CSDL");
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnpreview
            // 
            this.btnpreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpreview.Enabled = false;
            this.btnpreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnpreview.Image = global::MSSQLDatabaseDocGen.Properties.Resources.preview;
            this.btnpreview.Location = new System.Drawing.Point(140, 201);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(58, 54);
            this.btnpreview.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnpreview, "Xem trước nội dung trước khi in ra");
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = global::MSSQLDatabaseDocGen.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(272, 201);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 54);
            this.btnExit.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnExit, "Thoát chương trình");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::MSSQLDatabaseDocGen.Properties.Resources.reset;
            this.btnReset.Location = new System.Drawing.Point(206, 201);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(58, 54);
            this.btnReset.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnReset, "Thiết lập lại ");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::MSSQLDatabaseDocGen.Properties.Resources.print1;
            this.btnPrint.Location = new System.Drawing.Point(75, 201);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 54);
            this.btnPrint.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnPrint, "In cấu trúc CSDL ra File Word");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // tepTinToolStripMenuItem
            // 
            this.tepTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoatToolStripMenuItem});
            this.tepTinToolStripMenuItem.Name = "tepTinToolStripMenuItem";
            this.tepTinToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tepTinToolStripMenuItem.Text = "Tệp tin";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tepTinToolStripMenuItem,
            this.thongTinToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.tepTinToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(344, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ptboxprocess
            // 
            this.ptboxprocess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptboxprocess.Image = global::MSSQLDatabaseDocGen.Properties.Resources.Running;
            this.ptboxprocess.Location = new System.Drawing.Point(94, 275);
            this.ptboxprocess.Name = "ptboxprocess";
            this.ptboxprocess.Size = new System.Drawing.Size(115, 12);
            this.ptboxprocess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptboxprocess.TabIndex = 9;
            this.ptboxprocess.TabStop = false;
            this.ptboxprocess.Visible = false;
            // 
            // bgdWorker
            // 
            this.bgdWorker.WorkerReportsProgress = true;
            this.bgdWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgdWorker_DoWork);
            this.bgdWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgdWorker_RunWorkerCompleted);
            this.bgdWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgdWorker_ProgressChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 291);
            this.Controls.Add(this.ptboxprocess);
            this.Controls.Add(this.btnpreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database DocGen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxprocess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tStrlblstatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tacgiaToolStripMenuItem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.ToolStripMenuItem thongTinToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tepTinToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDatabaseType;
        private System.Windows.Forms.PictureBox ptboxprocess;
        private System.ComponentModel.BackgroundWorker bgdWorker;
    }
}

