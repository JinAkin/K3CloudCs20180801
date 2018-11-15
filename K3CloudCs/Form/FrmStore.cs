using System;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmStore : Form
    {
        Store sso;
        string constr="";
        public FrmStore(Store ss,string constring)
        {
            sso = ss;
            constr = constring;
            InitializeComponent();
        }

        private void FrmShopSet_Load(object sender, EventArgs e)
        {
            txtCustName.Text = sso.Stock_Name;
            txtCustNumber.Text = sso.Stock_Number;
            txtOrgName.Text = sso.StoreOrg_Name;
            txtOrgNumber.Text = sso.StoreOrg_Number;
            txtShopNumber.Text = sso.Store_id.ToString();
            txtShopName.Text = sso.Store_name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Shop so=new Shop();
            Shop_DAL ss = new Shop_DAL(constr);
            if(txtOrgNumber.Text.Trim()=="" || txtShopNumber.Text.Trim()=="" || txtCustNumber.Text.Trim() == "")
            {
                MessageBox.Show("组织代码、店铺代码、客户代码不能为空!");
                return;
            }
            int FOrgID = ss.GetOrgID(txtOrgNumber.Text.Trim());            
            if (FOrgID == 0)
            {
                MessageBox.Show("组织代码不存在!");
                return;
            }
            int FCustID = ss.GetCustID(txtCustNumber.Text.Trim());
            if (FCustID == 0)
            {
                MessageBox.Show("客户代码不存在!");
                return;
            }
            so.Cust_id = FCustID;
            so.SaleOrg_id = FOrgID;
            so.shop_id = int.Parse(txtShopNumber.Text.Trim());
            so.shop_name = txtShopName.Text.Trim();
            if (ss.isExistsShop(int.Parse(txtShopNumber.Text.Trim())) == false)
            {
                if (ss.Add(so) == true)
                {
                    MessageBox.Show("新增成功！");
                }
                else
                {
                    MessageBox.Show("新增失败！");
                }
            }
            else
            {
                if (ss.Alter(so) == true)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            this.Close();
            this.Dispose();
        }
    }
}
