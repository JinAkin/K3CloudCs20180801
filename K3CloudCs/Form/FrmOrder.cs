using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace K3CloudCs
{
    public partial class FrmOrder : Form
    {
        List<Item> LItem;
        Order_Dal od;
        string constr;
        string strEUrl = "";
        string strEDbhost = "";
        string strESecret = "";
        string strEAppkey = "";
        string strEToken = "";
        string date_type = "";
        string page_size = "";
        public FrmOrder()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dtEnd.Value >= dtStart.Value)
            {
                DateTime begin_time = dtStart.Value;
                DateTime end_time = dtEnd.Value;
                string tid = txttid.Text.Trim();
                string order_status = comorder_status.SelectedItem.ToString();
                List<tid_item> ltid = new List<tid_item>();
                dgList.DataSource = new BindingList<tid_item>(ltid);
                FormateEntry();
                od.GetItemListBySql(begin_time, end_time, tid, order_status);
                dgHead.DataSource = new BindingList<Item>(od.lItem);
                FormateHead();
            }
        }

        private void btnNetQuery_Click(object sender, EventArgs e)
        {
            if (dtEnd.Value >= dtStart.Value)
            {
                if (backgroundWorker1.IsBusy == false) backgroundWorker1.RunWorkerAsync();
            }
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            ConfigHelper config = new ConfigHelper();            
            constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
            strEUrl = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Url");
            strEDbhost = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Dbhost");
            strESecret = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_secret");
            strEAppkey = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Appkey");
            strEToken = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_token");
            date_type = config.ReadValueByKey(ConfigurationFile.AppConfig, "date_type");
            page_size = config.ReadValueByKey(ConfigurationFile.AppConfig, "page_size");
            comorder_status.SelectedIndex = 0;
            od = new Order_Dal(constr,page_size,date_type);
            LItem = new List<Item>();
            dgHead.DataSource = new BindingList<Item>(LItem);
            FormateHead();
            List<tid_item> Ltid= new List<tid_item>();
            dgList.DataSource = new BindingList<tid_item>(Ltid) ;
            dgError.DataSource = new BindingList<string>(new List<string>());
            FormateEntry();
        }
        private void FormateHead()
        {
            ConfigHelper config = new ConfigHelper();
            string TradeFields = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeFields");
            string TradeDes = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeDes");
            string[] Fields = TradeFields.Split(',');
            string[] Dess = TradeDes.Split(',');
            if (Fields.Length > 0 && Dess.Length > 0 && Fields.Length == Dess.Length)
            {
                LoadGrid(dgHead, Fields, Dess);
            }
        }
        private void FormateEntry()
        {
            ConfigHelper config = new ConfigHelper();
            string TradeEntryFields = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeEntryFields");
            string TradeEntryDes = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeEntryDes");
            string[] EntryFields = TradeEntryFields.Split(',');
            string[] EntryDess = TradeEntryDes.Split(',');
            if (EntryFields.Length > 0 && EntryDess.Length > 0 && EntryFields.Length == EntryDess.Length)
            {
                LoadGrid(dgList, EntryFields, EntryDess);
            }
            dgError.Columns[0].HeaderText = "错误描述";
        }
        private void LoadGrid(DataGridView dg, string[] Fileds, string[] Des)
        {
            for (int i = 0; i < Fileds.Length; i++)
            {
                if (dg.Columns[Fileds[i]] != null) { dg.Columns[Fileds[i]].HeaderText = Des[i]; }
            }
        }

        private void dgHead_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgHead.RowCount )
            {
                if (LItem.Count > 0)
                {
                    Item o = LItem[e.RowIndex];
                    dgList.DataSource = new BindingList<tid_item>(o.tid_item);
                    List<string> lString = od.lError(o);
                    dgError.DataSource = (from s in lString select new { s }).ToList();
                    FormateEntry();
                }
            }       
        }

        private void dgHead_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }

        private void dgList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string tid = txttid.Text.Trim();
            string order_status = comorder_status.SelectedItem.ToString();
            od.GetItemListByNet(dtStart.Text, dtEnd.Text, tid, order_status, strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
            LItem = od.lItem;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgHead.DataSource = new BindingList<Item>(LItem);
            //FormateHead();
        }

        private void toolExpIn_Click(object sender, EventArgs e)
        {
            if (dgHead.CurrentRow.Index > 0 && dgHead.CurrentRow.Index < dgHead.Rows.Count - 1)
            {
                Item i = dgHead.CurrentRow.DataBoundItem as Item;
                if (SqlHelper.ExecuteScalar(constr, CommandType.Text, "select tid from tb_trade where tid='"+ i.tid+"'", null) == null)
                {
                    od.InsertDB(i);
                    MessageBox.Show("导入成功!", "提示");
                }
                else
                {
                    if (MessageBox.Show("是否覆盖", "提示",  MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SqlHelper.ExecuteNonQuery(constr, "delete from tb_trade where tid='" + i.tid + "';delete from tb_tradeentry where tid='" + i.tid + "';", null);
                        od.InsertDB(i);
                        MessageBox.Show("覆盖成功!", "提示");
                    }
                }
            }
        }
    }
}
