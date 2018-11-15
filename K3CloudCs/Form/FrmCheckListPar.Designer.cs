namespace K3CloudCs
{
    partial class FrmCheckListPar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckListPar));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgHead = new System.Windows.Forms.DataGridView();
            this.ColFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolHeadAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHeadDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgEntry = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolEntryAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolEntryDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHead)).BeginInit();
            this.HeadCMS.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntry)).BeginInit();
            this.EntryCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 304);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgHead);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "E电宝订单表字段对照表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgHead
            // 
            this.dgHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFieldName,
            this.ColDefaultValue,
            this.ColDisplay});
            this.dgHead.ContextMenuStrip = this.HeadCMS;
            this.dgHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHead.Location = new System.Drawing.Point(3, 3);
            this.dgHead.Name = "dgHead";
            this.dgHead.RowTemplate.Height = 23;
            this.dgHead.Size = new System.Drawing.Size(594, 272);
            this.dgHead.TabIndex = 0;
            this.dgHead.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgHead_RowStateChanged);
            // 
            // ColFieldName
            // 
            this.ColFieldName.HeaderText = "字段名";
            this.ColFieldName.Name = "ColFieldName";
            // 
            // ColDefaultValue
            // 
            this.ColDefaultValue.HeaderText = "默认值";
            this.ColDefaultValue.Name = "ColDefaultValue";
            // 
            // ColDisplay
            // 
            this.ColDisplay.HeaderText = "显示名";
            this.ColDisplay.Name = "ColDisplay";
            // 
            // HeadCMS
            // 
            this.HeadCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolHeadAdd,
            this.toolHeadDel});
            this.HeadCMS.Name = "CMS";
            this.HeadCMS.Size = new System.Drawing.Size(95, 48);
            // 
            // toolHeadAdd
            // 
            this.toolHeadAdd.Name = "toolHeadAdd";
            this.toolHeadAdd.Size = new System.Drawing.Size(94, 22);
            this.toolHeadAdd.Text = "添加";
            this.toolHeadAdd.Click += new System.EventHandler(this.toolHeadAdd_Click);
            // 
            // toolHeadDel
            // 
            this.toolHeadDel.Name = "toolHeadDel";
            this.toolHeadDel.Size = new System.Drawing.Size(94, 22);
            this.toolHeadDel.Text = "删除";
            this.toolHeadDel.Click += new System.EventHandler(this.toolHeadDel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgEntry);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "E电宝订单表体字段对照表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgEntry
            // 
            this.dgEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgEntry.ContextMenuStrip = this.EntryCMS;
            this.dgEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEntry.Location = new System.Drawing.Point(3, 3);
            this.dgEntry.Name = "dgEntry";
            this.dgEntry.RowTemplate.Height = 23;
            this.dgEntry.Size = new System.Drawing.Size(594, 272);
            this.dgEntry.TabIndex = 1;
            this.dgEntry.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgEntry_RowStateChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "字段名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "默认值";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "显示名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // EntryCMS
            // 
            this.EntryCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolEntryAdd,
            this.toolEntryDel});
            this.EntryCMS.Name = "CMS";
            this.EntryCMS.Size = new System.Drawing.Size(95, 48);
            // 
            // toolEntryAdd
            // 
            this.toolEntryAdd.Name = "toolEntryAdd";
            this.toolEntryAdd.Size = new System.Drawing.Size(94, 22);
            this.toolEntryAdd.Text = "添加";
            this.toolEntryAdd.Click += new System.EventHandler(this.toolEntryAdd_Click);
            // 
            // toolEntryDel
            // 
            this.toolEntryDel.Name = "toolEntryDel";
            this.toolEntryDel.Size = new System.Drawing.Size(94, 22);
            this.toolEntryDel.Text = "删除";
            this.toolEntryDel.Click += new System.EventHandler(this.toolEntryDel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(161, 309);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(387, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCheckListPar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 333);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheckListPar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数对照表";
            this.Load += new System.EventHandler(this.FrmCheckListPar_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHead)).EndInit();
            this.HeadCMS.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEntry)).EndInit();
            this.EntryCMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgHead;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDisplay;
        private System.Windows.Forms.DataGridView dgEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ContextMenuStrip HeadCMS;
        private System.Windows.Forms.ToolStripMenuItem toolHeadAdd;
        private System.Windows.Forms.ToolStripMenuItem toolHeadDel;
        private System.Windows.Forms.ContextMenuStrip EntryCMS;
        private System.Windows.Forms.ToolStripMenuItem toolEntryAdd;
        private System.Windows.Forms.ToolStripMenuItem toolEntryDel;
    }
}