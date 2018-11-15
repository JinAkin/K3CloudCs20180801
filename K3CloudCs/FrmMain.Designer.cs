namespace K3CloudCs
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.bwMaterialErrorList = new System.ComponentModel.BackgroundWorker();
            this.bwK3CloudSalOut = new System.ComponentModel.BackgroundWorker();
            this.bwK3CloudSalReturn = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.toolEnd = new System.Windows.Forms.ToolStripButton();
            this.toolOrder = new System.Windows.Forms.ToolStripButton();
            this.toolParSet = new System.Windows.Forms.ToolStripButton();
            this.toolCheckList = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolCheckList_Cust = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCheckList_Stock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCheckList_Supper = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCheckList_Par = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMaterialErrorList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMaterialErrorInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStockErrorInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMaterialErrorListExport = new System.Windows.Forms.ToolStripMenuItem();
            this.timerEdbSTKTRANSFER = new System.Windows.Forms.Timer(this.components);
            this.bwEDBOUTSTOCK = new System.ComponentModel.BackgroundWorker();
            this.bwEDBRETURNSTOCK = new System.ComponentModel.BackgroundWorker();
            this.bwEDBSTKTRANSFER = new System.ComponentModel.BackgroundWorker();
            this.timerDelDbLog = new System.Windows.Forms.Timer(this.components);
            this.timerEdbOUTSTOCK = new System.Windows.Forms.Timer(this.components);
            this.timerEdbRETURNSTOCK = new System.Windows.Forms.Timer(this.components);
            this.timerK3CloudSalOut = new System.Windows.Forms.Timer(this.components);
            this.timerK3CloudSalReturn = new System.Windows.Forms.Timer(this.components);
            this.bwEDBErrorOUTSTOCK = new System.ComponentModel.BackgroundWorker();
            this.timerErrorOUTSTOCK = new System.Windows.Forms.Timer(this.components);
            this.dgMaterialErrorList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.cmsMaterialErrorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaterialErrorList)).BeginInit();
            this.SuspendLayout();
            // 
            // bwMaterialErrorList
            // 
            this.bwMaterialErrorList.WorkerSupportsCancellation = true;
            this.bwMaterialErrorList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMaterialErrorList_DoWork);
            this.bwMaterialErrorList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMaterialErrorList_RunWorkerCompleted);
            // 
            // bwK3CloudSalOut
            // 
            this.bwK3CloudSalOut.WorkerSupportsCancellation = true;
            this.bwK3CloudSalOut.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSalOutK3Cloud_DoWork);
            // 
            // bwK3CloudSalReturn
            // 
            this.bwK3CloudSalReturn.WorkerSupportsCancellation = true;
            this.bwK3CloudSalReturn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSalReturnK3CloudAsy_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStart,
            this.toolEnd,
            this.toolOrder,
            this.toolParSet,
            this.toolCheckList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 25);
            this.toolStrip1.TabIndex = 51;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStart
            // 
            this.toolStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStart.Image")));
            this.toolStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStart.Name = "toolStart";
            this.toolStart.Size = new System.Drawing.Size(36, 22);
            this.toolStart.Text = "开始";
            this.toolStart.Click += new System.EventHandler(this.toolStart_Click);
            // 
            // toolEnd
            // 
            this.toolEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEnd.Enabled = false;
            this.toolEnd.Image = ((System.Drawing.Image)(resources.GetObject("toolEnd.Image")));
            this.toolEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEnd.Name = "toolEnd";
            this.toolEnd.Size = new System.Drawing.Size(36, 22);
            this.toolEnd.Text = "结束";
            this.toolEnd.Click += new System.EventHandler(this.toolEnd_Click);
            // 
            // toolOrder
            // 
            this.toolOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolOrder.Image")));
            this.toolOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOrder.Name = "toolOrder";
            this.toolOrder.Size = new System.Drawing.Size(60, 22);
            this.toolOrder.Text = "订单查询";
            this.toolOrder.Click += new System.EventHandler(this.toolOrder_Click);
            // 
            // toolParSet
            // 
            this.toolParSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolParSet.Image = ((System.Drawing.Image)(resources.GetObject("toolParSet.Image")));
            this.toolParSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolParSet.Name = "toolParSet";
            this.toolParSet.Size = new System.Drawing.Size(60, 22);
            this.toolParSet.Text = "参数设置";
            this.toolParSet.Click += new System.EventHandler(this.toolParSet_Click);
            // 
            // toolCheckList
            // 
            this.toolCheckList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCheckList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckList_Cust,
            this.toolCheckList_Stock,
            this.toolCheckList_Supper,
            this.toolCheckList_Par});
            this.toolCheckList.Image = ((System.Drawing.Image)(resources.GetObject("toolCheckList.Image")));
            this.toolCheckList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckList.Name = "toolCheckList";
            this.toolCheckList.Size = new System.Drawing.Size(81, 22);
            this.toolCheckList.Text = "对照表设置";
            // 
            // toolCheckList_Cust
            // 
            this.toolCheckList_Cust.Name = "toolCheckList_Cust";
            this.toolCheckList_Cust.Size = new System.Drawing.Size(136, 22);
            this.toolCheckList_Cust.Text = "客户与店面";
            this.toolCheckList_Cust.Click += new System.EventHandler(this.toolCheckList_Cust_Click);
            // 
            // toolCheckList_Stock
            // 
            this.toolCheckList_Stock.Name = "toolCheckList_Stock";
            this.toolCheckList_Stock.Size = new System.Drawing.Size(136, 22);
            this.toolCheckList_Stock.Text = "仓库";
            this.toolCheckList_Stock.Click += new System.EventHandler(this.toolCheckList_Stock_Click);
            // 
            // toolCheckList_Supper
            // 
            this.toolCheckList_Supper.Name = "toolCheckList_Supper";
            this.toolCheckList_Supper.Size = new System.Drawing.Size(136, 22);
            this.toolCheckList_Supper.Text = "供应商";
            this.toolCheckList_Supper.Click += new System.EventHandler(this.toolCheckList_Supper_Click);
            // 
            // toolCheckList_Par
            // 
            this.toolCheckList_Par.Name = "toolCheckList_Par";
            this.toolCheckList_Par.Size = new System.Drawing.Size(136, 22);
            this.toolCheckList_Par.Text = "参数";
            this.toolCheckList_Par.Click += new System.EventHandler(this.toolCheckList_Par_Click);
            // 
            // cmsMaterialErrorList
            // 
            this.cmsMaterialErrorList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMaterialErrorList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMaterialErrorInfo,
            this.toolStockErrorInfo,
            this.toolMaterialErrorListExport});
            this.cmsMaterialErrorList.Name = "cmsItemMid";
            this.cmsMaterialErrorList.Size = new System.Drawing.Size(149, 70);
            // 
            // toolMaterialErrorInfo
            // 
            this.toolMaterialErrorInfo.Name = "toolMaterialErrorInfo";
            this.toolMaterialErrorInfo.Size = new System.Drawing.Size(148, 22);
            this.toolMaterialErrorInfo.Text = "物料异常信息";
            this.toolMaterialErrorInfo.Click += new System.EventHandler(this.toolMaterialErrorInfo_Click);
            // 
            // toolStockErrorInfo
            // 
            this.toolStockErrorInfo.Name = "toolStockErrorInfo";
            this.toolStockErrorInfo.Size = new System.Drawing.Size(148, 22);
            this.toolStockErrorInfo.Text = "库存异常信息";
            this.toolStockErrorInfo.Click += new System.EventHandler(this.toolStockErrorInfo_Click);
            // 
            // toolMaterialErrorListExport
            // 
            this.toolMaterialErrorListExport.Name = "toolMaterialErrorListExport";
            this.toolMaterialErrorListExport.Size = new System.Drawing.Size(148, 22);
            this.toolMaterialErrorListExport.Text = "导出";
            this.toolMaterialErrorListExport.Click += new System.EventHandler(this.toolMaterialErrorList_Click);
            // 
            // timerEdbSTKTRANSFER
            // 
            this.timerEdbSTKTRANSFER.Interval = 600000;
            this.timerEdbSTKTRANSFER.Tick += new System.EventHandler(this.timerEDBSTKTRANSFER_Tick);
            // 
            // bwEDBOUTSTOCK
            // 
            this.bwEDBOUTSTOCK.WorkerSupportsCancellation = true;
            this.bwEDBOUTSTOCK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEdbOUTSTOCK_DoWork);
            // 
            // bwEDBRETURNSTOCK
            // 
            this.bwEDBRETURNSTOCK.WorkerSupportsCancellation = true;
            this.bwEDBRETURNSTOCK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEDBRETURNSTOCK_DoWork);
            // 
            // bwEDBSTKTRANSFER
            // 
            this.bwEDBSTKTRANSFER.WorkerSupportsCancellation = true;
            this.bwEDBSTKTRANSFER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEDBSTKTRANSFER_DoWork);
            // 
            // timerDelDbLog
            // 
            this.timerDelDbLog.Enabled = true;
            this.timerDelDbLog.Interval = 86400000;
            this.timerDelDbLog.Tick += new System.EventHandler(this.timerDelDbLog_Tick);
            // 
            // timerEdbOUTSTOCK
            // 
            this.timerEdbOUTSTOCK.Tick += new System.EventHandler(this.timerEdbOUTSTOCK_Tick);
            // 
            // timerEdbRETURNSTOCK
            // 
            this.timerEdbRETURNSTOCK.Tick += new System.EventHandler(this.timerEdbRETURNSTOCK_Tick);
            // 
            // timerK3CloudSalOut
            // 
            this.timerK3CloudSalOut.Tick += new System.EventHandler(this.timerK3CloudSalOut_Tick);
            // 
            // timerK3CloudSalReturn
            // 
            this.timerK3CloudSalReturn.Tick += new System.EventHandler(this.timerK3CloudSalReturn_Tick);
            // 
            // bwEDBErrorOUTSTOCK
            // 
            this.bwEDBErrorOUTSTOCK.WorkerSupportsCancellation = true;
            this.bwEDBErrorOUTSTOCK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEDBErrorOUTSTOCK_DoWork);
            // 
            // timerErrorOUTSTOCK
            // 
            this.timerErrorOUTSTOCK.Tick += new System.EventHandler(this.timerErrorOUTSTOCK_Tick);
            // 
            // dgMaterialErrorList
            // 
            this.dgMaterialErrorList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMaterialErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaterialErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgMaterialErrorList.ContextMenuStrip = this.cmsMaterialErrorList;
            this.dgMaterialErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMaterialErrorList.Location = new System.Drawing.Point(0, 25);
            this.dgMaterialErrorList.Name = "dgMaterialErrorList";
            this.dgMaterialErrorList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgMaterialErrorList.RowTemplate.Height = 23;
            this.dgMaterialErrorList.Size = new System.Drawing.Size(906, 248);
            this.dgMaterialErrorList.TabIndex = 52;
            this.dgMaterialErrorList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgMaterialErrorList_RowStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "物料代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "物料名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "描述";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 273);
            this.Controls.Add(this.dgMaterialErrorList);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "K3Cloud同步系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsMaterialErrorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMaterialErrorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwMaterialErrorList;
        private System.ComponentModel.BackgroundWorker bwK3CloudSalOut;
        private System.ComponentModel.BackgroundWorker bwK3CloudSalReturn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolParSet;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripButton toolEnd;
        private System.Windows.Forms.ContextMenuStrip cmsMaterialErrorList;
        private System.Windows.Forms.ToolStripMenuItem toolMaterialErrorListExport;
        private System.Windows.Forms.ToolStripMenuItem toolMaterialErrorInfo;
        private System.Windows.Forms.Timer timerEdbSTKTRANSFER;
        private System.ComponentModel.BackgroundWorker bwEDBOUTSTOCK;
        private System.ComponentModel.BackgroundWorker bwEDBRETURNSTOCK;
        private System.ComponentModel.BackgroundWorker bwEDBSTKTRANSFER;
        private System.Windows.Forms.Timer timerDelDbLog;
        private System.Windows.Forms.Timer timerEdbOUTSTOCK;
        private System.Windows.Forms.Timer timerEdbRETURNSTOCK;
        private System.Windows.Forms.Timer timerK3CloudSalOut;
        private System.Windows.Forms.Timer timerK3CloudSalReturn;
        private System.Windows.Forms.ToolStripDropDownButton toolCheckList;
        private System.Windows.Forms.ToolStripMenuItem toolCheckList_Cust;
        private System.Windows.Forms.ToolStripMenuItem toolCheckList_Stock;
        private System.Windows.Forms.ToolStripMenuItem toolCheckList_Supper;
        private System.Windows.Forms.ToolStripMenuItem toolCheckList_Par;
        private System.Windows.Forms.ToolStripButton toolOrder;
        private System.ComponentModel.BackgroundWorker bwEDBErrorOUTSTOCK;
        private System.Windows.Forms.Timer timerErrorOUTSTOCK;
        private System.Windows.Forms.ToolStripMenuItem toolStockErrorInfo;
        private System.Windows.Forms.DataGridView dgMaterialErrorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}