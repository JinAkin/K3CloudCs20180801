using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmCheckListStock : Form
    {
        string constr = "";
        public FrmCheckListStock()
        {
            InitializeComponent();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            Store so = new Store();
            FrmStore fss = new FrmStore(so, constr);
            fss.ShowDialog();
            fss.Dispose();
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            Store_DAL ss = new Store_DAL(constr);
            int store_id = Convert.ToInt16(dgList.CurrentRow.Cells[0].Value.ToString());
            if (ss.Del(store_id) == true)
            {
                int iRow = dgList.CurrentRow.Index;
                dgList.Rows.RemoveAt(iRow);
                MessageBox.Show("删除成功!");
            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }

        private void toolRefresh_Click(object sender, EventArgs e)
        {
            Store_DAL ss = new Store_DAL(constr);
            List<Store> lss = ss.GetStoreSetList();
            if (lss.Count > 0)
            {
                this.dgList.Rows.Clear();
                foreach (Store so in lss)
                {
                    int index = this.dgList.Rows.Add();
                    this.dgList.Rows[index].Cells[0].Value = so.Store_id;
                    this.dgList.Rows[index].Cells[1].Value = so.Store_name;
                    this.dgList.Rows[index].Cells[2].Value = so.Stock_id;
                    this.dgList.Rows[index].Cells[3].Value = so.Stock_Number;
                    this.dgList.Rows[index].Cells[4].Value = so.Stock_Name;
                    this.dgList.Rows[index].Cells[5].Value = so.StoreOrg_id;
                    this.dgList.Rows[index].Cells[6].Value = so.StoreOrg_Number;
                    this.dgList.Rows[index].Cells[7].Value = so.StoreOrg_Name;
                }
            }
        }

        private void toolShopSetExport_Click(object sender, EventArgs e)
        {
            ExcelHelper ex = new ExcelHelper();
            ex.DataToExcel(dgList);
        }

        private void FrmCheckListStock_Load(object sender, EventArgs e)
        {
            ConfigHelper config = new ConfigHelper();
            constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentRow.Index > 0)
            {
                Store so = new Store();
                so.Store_id = int.Parse(dgList.CurrentRow.Cells[0].Value.ToString());
                so.Store_name = dgList.CurrentRow.Cells[1].Value.ToString();
                so.Stock_id = int.Parse(dgList.CurrentRow.Cells[2].Value.ToString());
                so.Stock_Number = dgList.CurrentRow.Cells[3].Value.ToString();
                so.Stock_Name = dgList.CurrentRow.Cells[4].Value.ToString();
                so.StoreOrg_id = int.Parse(dgList.CurrentRow.Cells[5].Value.ToString());
                so.StoreOrg_Number = dgList.CurrentRow.Cells[6].Value.ToString();
                so.StoreOrg_Name = dgList.CurrentRow.Cells[7].Value.ToString();
                FrmStore fss = new FrmStore(so, constr);
                fss.ShowDialog();
                fss.Dispose();
            }
        }

        private void dgList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }
    }
}
