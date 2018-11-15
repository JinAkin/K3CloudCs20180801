using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmCheckListCust : Form
    {
        string constr = "";
        public FrmCheckListCust()
        {
            InitializeComponent();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            Shop so = new Shop();
            FrmShop fss = new FrmShop(so, constr);
            fss.ShowDialog();
            fss.Dispose();
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            Shop_DAL ss = new Shop_DAL(constr);
            int shop_id = Convert.ToInt16(dgList.CurrentRow.Cells[0].Value.ToString());
            if (ss.Del(shop_id) == true)
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
            Shop_DAL ss = new Shop_DAL(constr);
            List<Shop> lss = ss.GetShopSetList();
            if (lss.Count > 0)
            {
                this.dgList.Rows.Clear();
                foreach (Shop so in lss)
                {
                    int index = this.dgList.Rows.Add();
                    this.dgList.Rows[index].Cells[0].Value = so.shop_id;
                    this.dgList.Rows[index].Cells[1].Value = so.shop_name;
                    this.dgList.Rows[index].Cells[2].Value = so.Cust_id;
                    this.dgList.Rows[index].Cells[3].Value = so.Cust_Number;
                    this.dgList.Rows[index].Cells[4].Value = so.Cust_Name;
                    this.dgList.Rows[index].Cells[5].Value = so.SaleOrg_id;
                    this.dgList.Rows[index].Cells[6].Value = so.SaleOrg_Number;
                    this.dgList.Rows[index].Cells[7].Value = so.SaleOrg_Name;
                }
            }
        }

        private void toolShopSetExport_Click(object sender, EventArgs e)
        {
            ExcelHelper ex = new ExcelHelper();
            ex.DataToExcel(dgList);
        }

        private void FrmCheckListCust_Load(object sender, EventArgs e)
        {
            ConfigHelper config = new ConfigHelper();
            constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentRow.Index > 0)
            {
                Shop so = new Shop();
                so.shop_id = int.Parse(dgList.CurrentRow.Cells[0].Value.ToString());
                so.shop_name = dgList.CurrentRow.Cells[1].Value.ToString();
                so.Cust_id = int.Parse(dgList.CurrentRow.Cells[2].Value.ToString());
                so.Cust_Number = dgList.CurrentRow.Cells[3].Value.ToString();
                so.Cust_Name = dgList.CurrentRow.Cells[4].Value.ToString();
                so.SaleOrg_id = int.Parse(dgList.CurrentRow.Cells[5].Value.ToString());
                so.SaleOrg_Number = dgList.CurrentRow.Cells[6].Value.ToString();
                so.SaleOrg_Name = dgList.CurrentRow.Cells[7].Value.ToString();
                FrmShop fss = new FrmShop(so, constr);
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
