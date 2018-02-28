namespace MSSQLDatabaseDocGen
{
    partial class ListObject
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
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnCustomObject = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.objectList = new GlacialComponents.Controls.GlacialList();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(24, 178);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 35);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Bỏ qua";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnCustomObject
            // 
            this.btnCustomObject.Location = new System.Drawing.Point(105, 178);
            this.btnCustomObject.Name = "btnCustomObject";
            this.btnCustomObject.Size = new System.Drawing.Size(75, 35);
            this.btnCustomObject.TabIndex = 2;
            this.btnCustomObject.Text = "Tùy chọn đối tượng";
            this.btnCustomObject.UseVisualStyleBackColor = true;
            this.btnCustomObject.Click += new System.EventHandler(this.btnCustomObject_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(186, 178);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 35);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Đọc cấu trúc";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // objectList
            // 
            this.objectList.AllowColumnResize = true;
            this.objectList.AllowMultiselect = true;
            this.objectList.AlternateBackground = System.Drawing.Color.White;
            this.objectList.AlternatingColors = false;
            this.objectList.AutoHeight = true;
            this.objectList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.objectList.BackgroundStretchToFit = true;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = true;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Objects";
            glColumn3.NumericSort = false;
            glColumn3.Text = "Đối tượng";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 150;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Number";
            glColumn4.NumericSort = false;
            glColumn4.Text = "Số lượng";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.objectList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn3,
            glColumn4});
            this.objectList.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.objectList.FullRowSelect = true;
            this.objectList.GridColor = System.Drawing.Color.LightGray;
            this.objectList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.objectList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.objectList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.objectList.HeaderHeight = 22;
            this.objectList.HeaderVisible = true;
            this.objectList.HeaderWordWrap = false;
            this.objectList.HotColumnTracking = false;
            this.objectList.HotItemTracking = false;
            this.objectList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.objectList.HoverEvents = false;
            this.objectList.HoverTime = 1;
            this.objectList.ImageList = null;
            this.objectList.ItemHeight = 17;
            this.objectList.ItemWordWrap = false;
            this.objectList.Location = new System.Drawing.Point(12, 23);
            this.objectList.Name = "objectList";
            this.objectList.Selectable = true;
            this.objectList.SelectedTextColor = System.Drawing.Color.White;
            this.objectList.SelectionColor = System.Drawing.Color.CornflowerBlue;
            this.objectList.ShowBorder = true;
            this.objectList.ShowFocusRect = false;
            this.objectList.Size = new System.Drawing.Size(261, 139);
            this.objectList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.objectList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.objectList.TabIndex = 5;
            // 
            // ListObject
            // 
            this.AcceptButton = this.btnRead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(285, 225);
            this.Controls.Add(this.objectList);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnCustomObject);
            this.Controls.Add(this.btnCancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ListObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin tổng quát";
            this.Load += new System.EventHandler(this.ListObject_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnCustomObject;
        private System.Windows.Forms.Button btnRead;
        private GlacialComponents.Controls.GlacialList objectList;
    }
}