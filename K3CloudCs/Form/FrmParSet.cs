using Kingdee.BOS.WebApi.Client;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmParSet : Form
    {
        ConfigHelper config;
        public FrmParSet()
        {
            InitializeComponent();
        }

        private void btnK3Cloud_Click(object sender, EventArgs e)
        {
            ApiClient client = new ApiClient(txtUrl.Text.Trim());
            bool loginResult = client.Login(txtDbId.Text.Trim(), txtUser.Text.Trim(), txtPassword.Text.Trim(), 2052);
            if (loginResult == true)
            {
                MessageBox.Show("登陆成功!");
            }
            else
            {
                MessageBox.Show("登陆失败!");
            }
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            string constr = "server="+ txtServerID.Text.Trim() +";initial catalog="+ txtServerName.Text.Trim() +";user id="+ txtServerUser.Text.Trim() +";password="+txtServerPwd.Text;
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = constr;
                conn.Open();
                MessageBox.Show("连接成功!");
            }
            catch
            {
                MessageBox.Show("连接失败!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string constr = "server=" + txtServerID.Text.Trim() + ";initial catalog=" + txtServerName.Text.Trim() + ";user id=" + txtServerUser.Text.Trim() + ";password=" + txtServerPwd.Text;
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "ConnectionString", constr);
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "K_Url", txtUrl.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "K_DbId", txtDbId.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "K_User", txtUser.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "K_Password", txtPassword.Text);
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "E_Url", txtEUrl.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "E_Dbhost", txtEDbhost.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "E_Wfpuser", txtEWfpuser.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "E_Appkey", txtEAppkey.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "date_type", comdate_type.SelectedItem.ToString());
            switch (cominvoice_isopen.SelectedItem.ToString())
            {
                case "0:未开":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isopen", "0");
                    break;
                case "1:已开":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isopen", "1");
                    break;
                case "":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isopen", "");
                    break;
            }
            switch (cominvoice_isprint.SelectedItem.ToString())
            {
                case "0:未打印":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isprint", "0");
                    break;
                case "1:已打印":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isprint", "1");
                    break;
                case "":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "invoice_isprint", "");
                    break;
            }
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "order_status",comorder_status.SelectedItem.ToString());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "payment_status",compayment_status.SelectedItem.ToString());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "platform_status",complatform_status.SelectedItem.ToString());
            switch (comproductInfo_type.SelectedItem.ToString())
            {
                case "1单品与套装明细":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "productInfo_type", "1");
                    break;
                case "2单品与套装以及套装明细":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "productInfo_type", "2");
                    break;
                case "3单品与套装":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "productInfo_type", "3");
                    break;
                case "":
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "productInfo_type", "");
                    break;
            }
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "proce_Status",comproce_Status.SelectedItem.ToString());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "LogDays",txtLogDays.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "out_tid",txtout_tid.Text.Trim());
            config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "tid",txttid.Text.Trim());
            this.Close();
        }

        private void FrmSet_Load(object sender, EventArgs e)
        {
            config = new ConfigHelper();
            string constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
            string[] cons = constr.Split(';');
            if (cons.Length == 4)
            {
                txtServerID.Text = cons[0].Replace("server=", "");
                txtServerName.Text = cons[1].Replace("initial catalog=", "");
                txtServerUser.Text = cons[2].Replace("user id=", "");
                txtServerPwd.Text = cons[3].Replace("password=", "");
            }
            txtUrl.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_Url");
            txtDbId.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_DbId");
            txtUser.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_User");
            txtPassword.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_Password");
            txtEUrl.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Url");
            txtEDbhost.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Dbhost");
            txtEWfpuser.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Wfpuser");
            txtEAppkey.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Appkey");
            string strdate_type= config.ReadValueByKey(ConfigurationFile.AppConfig, "date_type");
            comdate_type.SelectedIndex = comdate_type.Items.IndexOf(strdate_type);
            string strinvoice_isopen = config.ReadValueByKey(ConfigurationFile.AppConfig, "invoice_isopen");
            switch (strinvoice_isopen)
            {
                case "0":
                    cominvoice_isopen.SelectedIndex = cominvoice_isopen.Items.IndexOf("0:未开");
                    break;
                case "1":
                    cominvoice_isopen.SelectedIndex = cominvoice_isopen.Items.IndexOf("1:已开");
                    break;
                case "":
                    cominvoice_isopen.SelectedIndex = 0;
                    break;
            }            
            string strinvoice_isprint = config.ReadValueByKey(ConfigurationFile.AppConfig, "invoice_isprint");
            switch (strinvoice_isprint)
            {
                case "0":
                    cominvoice_isprint.SelectedIndex = cominvoice_isprint.Items.IndexOf("0:未打印");
                    break;
                case "1":
                    cominvoice_isprint.SelectedIndex = cominvoice_isprint.Items.IndexOf("1:已打印");
                    break;
                case "":
                    cominvoice_isprint.SelectedIndex = 0;
                    break;
            }         
            string strorder_status = config.ReadValueByKey(ConfigurationFile.AppConfig, "order_status");
            comorder_status.SelectedIndex = comorder_status.Items.IndexOf(strorder_status);
            string strpayment_status = config.ReadValueByKey(ConfigurationFile.AppConfig, "payment_status");
            compayment_status.SelectedIndex = compayment_status.Items.IndexOf(strpayment_status);
            string strplatform_status = config.ReadValueByKey(ConfigurationFile.AppConfig, "platform_status");
            complatform_status.SelectedIndex = complatform_status.Items.IndexOf(strplatform_status);         
            string strproce_Status = config.ReadValueByKey(ConfigurationFile.AppConfig, "proce_Status");
            comproce_Status.SelectedIndex = comproce_Status.Items.IndexOf(strproce_Status);
            string strproductInfo_type = config.ReadValueByKey(ConfigurationFile.AppConfig, "productInfo_type");
            //是否产品套装:3单品与套装:显示单品信息+套装信息;1单品与套装明细:显示单品信息+套装明细信息;2单品与套装以及套装明细:显示单品信息+套装信息+套装明细信息(默认)
            switch (strproductInfo_type)
            {
                case "1":
                    comproductInfo_type.SelectedIndex = comproductInfo_type.Items.IndexOf("1单品与套装明细");
                    break;
                case "2":
                    comproductInfo_type.SelectedIndex = comproductInfo_type.Items.IndexOf("2单品与套装以及套装明细");
                    break;
                case "3":
                    comproductInfo_type.SelectedIndex = comproductInfo_type.Items.IndexOf("3单品与套装");
                    break;
                case "":
                    comproductInfo_type.SelectedIndex = 0;
                    break;
            }            
            txtLogDays.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "LogDays");
            txtout_tid.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "out_tid");
            txttid.Text = config.ReadValueByKey(ConfigurationFile.AppConfig, "tid");
        }
    }
}
