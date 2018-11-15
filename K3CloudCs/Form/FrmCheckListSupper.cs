using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmCheckListSupper : Form
    {
        string constr = "";
        public FrmCheckListSupper()
        {
            InitializeComponent();
        }

        private void FrmCheckListSupper_Load(object sender, EventArgs e)
        {
            ConfigHelper config = new ConfigHelper();
            constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            Supper so = new Supper();
            FrmSupper fss = new FrmSupper(so, constr);
            fss.ShowDialog();
            fss.Dispose();
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            SupperSet ss = new SupperSet(constr);
            int Supper_id = Convert.ToInt16(dgList.CurrentRow.Cells[0].Value.ToString());
            if (ss.Del(Supper_id) == true)
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
            SupperSet ss = new SupperSet(constr);
            List<Supper> lss = ss.GetSupperSetList();
            if (lss.Count > 0)
            {
                this.dgList.Rows.Clear();
                foreach (Supper so in lss)
                {
                    int index = this.dgList.Rows.Add();
                    this.dgList.Rows[index].Cells[0].Value = so.Supper_id;
                    this.dgList.Rows[index].Cells[1].Value = so.Supper_name;
                    this.dgList.Rows[index].Cells[2].Value = so.SUPPLIER_id;
                    this.dgList.Rows[index].Cells[3].Value = so.SUPPLIER_Number;
                    this.dgList.Rows[index].Cells[4].Value = so.SUPPLIER_Name;
                    this.dgList.Rows[index].Cells[5].Value = so.UserOrg_id;
                    this.dgList.Rows[index].Cells[6].Value = so.UserOrg_Number;
                    this.dgList.Rows[index].Cells[7].Value = so.UserOrg_Name;
                }
            }
        }

        private void toolShopSetExport_Click(object sender, EventArgs e)
        {
            ExcelHelper ex = new ExcelHelper();
            ex.DataToExcel(dgList);
        }

        private void dgSupperSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentRow.Index > 0)
            {
                Supper so = new Supper();
                so.Supper_id = int.Parse(dgList.CurrentRow.Cells[0].Value.ToString());
                so.Supper_name = dgList.CurrentRow.Cells[1].Value.ToString();
                so.SUPPLIER_id = int.Parse(dgList.CurrentRow.Cells[2].Value.ToString());
                so.SUPPLIER_Number = dgList.CurrentRow.Cells[3].Value.ToString();
                so.SUPPLIER_Name = dgList.CurrentRow.Cells[4].Value.ToString();
                so.UserOrg_id = int.Parse(dgList.CurrentRow.Cells[5].Value.ToString());
                so.UserOrg_Number = dgList.CurrentRow.Cells[6].Value.ToString();
                so.UserOrg_Name = dgList.CurrentRow.Cells[7].Value.ToString();
                FrmSupper fss = new FrmSupper(so, constr);
                fss.ShowDialog();
                fss.Dispose();
            }
        }

        private void dgSupperSet_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }
    }
}
