namespace K3CloudCs
{
    partial class FrmCheckListCust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckListCust));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.toolRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolShopSetExport = new System.Windows.Forms.ToolStripButton();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.colStoreCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolDel,
            this.toolRefresh,
            this.toolShopSetExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(743, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNew
            // 
            this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(33, 22);
            this.toolNew.Text = "新增";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // toolDel
            // 
            this.toolDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDel.Image = ((System.Drawing.Image)(resources.GetObject("toolDel.Image")));
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(33, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // toolRefresh
            // 
            this.toolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolRefresh.Image")));
            this.toolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRefresh.Name = "toolRefresh";
            this.toolRefresh.Size = new System.Drawing.Size(33, 22);
            this.toolRefresh.Text = "刷新";
            this.toolRefresh.Click += new System.EventHandler(this.toolRefresh_Click);
            // 
            // toolShopSetExport
            // 
            this.toolShopSetExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolShopSetExport.Image = ((System.Drawing.Image)(resources.GetObject("toolShopSetExport.Image")));
            this.toolShopSetExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShopSetExport.Name = "toolShopSetExport";
            this.toolShopSetExport.Size = new System.Drawing.Size(33, 22);
            this.toolShopSetExport.Text = "导出";
            this.toolShopSetExport.Click += new System.EventHandler(this.toolShopSetExport_Click);
            // 
            // dgList
            // 
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStoreCode,
            this.colStoreName,
            this.ColCustID,
            this.ColCusterCode,
            this.ColCusterName,
            this.ColOrgID,
            this.colOrgCode,
            this.colOrgName});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(0, 25);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.Size = new System.Drawing.Size(743, 286);
            this.dgList.TabIndex = 1;
            this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
            this.dgList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgList_RowStateChanged);
            // 
            // colStoreCode
            // 
            this.colStoreCode.HeaderText = "店面编码";
            this.colStoreCode.Name = "colStoreCode";
            this.colStoreCode.ReadOnly = true;
            // 
            // colStoreName
            // 
            this.colStoreName.HeaderText = "店面名称";
            this.colStoreName.Name = "colStoreName";
            this.colStoreName.ReadOnly = true;
            // 
            // ColCustID
            // 
            this.ColCustID.HeaderText = "客户ID";
            this.ColCustID.Name = "ColCustID";
            this.ColCustID.ReadOnly = true;
            this.ColCustID.Visible = false;
            // 
            // ColCusterCode
            // 
            this.ColCusterCode.HeaderText = "客户代码";
            this.ColCusterCode.Name = "ColCusterCode";
            this.ColCusterCode.ReadOnly = true;
            // 
            // ColCusterName
            // 
            this.ColCusterName.HeaderText = "客户名称";
            this.ColCusterName.Name = "ColCusterName";
            this.ColCusterName.ReadOnly = true;
            // 
            // ColOrgID
            // 
            this.ColOrgID.HeaderText = "销售组织ID";
            this.ColOrgID.Name = "ColOrgID";
            this.ColOrgID.ReadOnly = true;
            this.ColOrgID.Visible = false;
            // 
            // colOrgCode
            // 
            this.colOrgCode.HeaderText = "销售组织代码";
            this.colOrgCode.Name = "colOrgCode";
            this.colOrgCode.ReadOnly = true;
            // 
            // colOrgName
            // 
            this.colOrgName.HeaderText = "销售组织名称";
            this.colOrgName.Name = "colOrgName";
            this.colOrgName.ReadOnly = true;
            // 
            // FrmCheckListCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 311);
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheckListCust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客户与店面对照表";
            this.Load += new System.EventHandler(this.FrmCheckListCust_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.ToolStripButton toolRefresh;
        private System.Windows.Forms.ToolStripButton toolShopSetExport;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStoreCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgName;
    }
}