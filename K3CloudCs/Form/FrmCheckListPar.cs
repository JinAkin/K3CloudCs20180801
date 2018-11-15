using System;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmCheckListPar : Form
    {
        ConfigHelper config;
        public FrmCheckListPar()
        {
            InitializeComponent();
        }

        private void FrmCheckListPar_Load(object sender, EventArgs e)
        {
            config = new ConfigHelper();
            string strTradeFields = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeFields");
            string[] TradeFields = strTradeFields.Split(',');
            string strTradeDefaultValues = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeDefaultValues");
            string[] TradeDefaultValues = strTradeDefaultValues.Split(',');
            string strTradeDes = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeDes");
            string[] TradeDes = strTradeDes.Split(',');
            FillGrid(TradeFields, TradeDefaultValues, TradeDes,dgHead);
            string strTradeEntryFields = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeEntryFields");
            string[] TradeEntryFields = strTradeEntryFields.Split(',');
            string strTradeEntryDefaultValues = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeEntryDefaultValues");
            string[] TradeEntryDefaultValues = strTradeEntryDefaultValues.Split(',');
            string strTradeEntryDes = config.ReadValueByKey(ConfigurationFile.AppConfig, "TradeEntryDes");
            string[] TradeEntryDes = strTradeEntryDes.Split(',');
            FillGrid(TradeEntryFields, TradeEntryDefaultValues, TradeEntryDes, dgEntry);
        }
        private void FillGrid(string[] Fields,string[] DefaultValues,string[] Dess,DataGridView dg)
        {
            int iLen = 0;
            if (Fields.Length > iLen) { iLen = Fields.Length; }
            if (DefaultValues.Length > iLen) { iLen = DefaultValues.Length; }
            if (Dess.Length > iLen) { iLen = Dess.Length; }
            dg.Rows.Clear();
            for (int i = 0; i < iLen; i++)
            {
                int index = dg.Rows.Add();
                if (i < Fields.Length) { dg.Rows[index].Cells[0].Value = Fields[i]; }
                if (i < DefaultValues.Length) dg.Rows[index].Cells[1].Value = DefaultValues[i];
                if (i < Dess.Length) dg.Rows[index].Cells[2].Value = Dess[i];
            }
        }
        private void dgHead_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }

        private void dgEntry_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strTradeFields = "";
            string strTradeDefaultValues = "";
            string strTradeDes = "";
            for (var i = 0; i < dgHead.Rows.Count; i++)
            {
                string TradeFields = "";
                if (dgHead.Rows[i].Cells[0].Value != null)
                {
                    TradeFields = dgHead.Rows[i].Cells[0].Value.ToString().Trim();
                }
                string TradeDefaultValues = "";
                if (dgHead.Rows[i].Cells[1].Value != null)
                {
                    TradeDefaultValues = dgHead.Rows[i].Cells[1].Value.ToString();
                }
                string TradeDes = "";
                if (dgHead.Rows[i].Cells[2].Value != null)
                {
                    TradeDes = dgHead.Rows[i].Cells[2].Value.ToString();
                }
                if (TradeFields != string.Empty && TradeDes != string.Empty)
                {
                    if (strTradeFields != string.Empty)
                    {
                        strTradeFields = strTradeFields + "," + TradeFields;
                        strTradeDefaultValues = strTradeDefaultValues + "," + TradeDefaultValues;
                        strTradeDes = strTradeDes + "," + TradeDes;
                    }
                    else
                    {
                        strTradeFields = TradeFields;
                        strTradeDefaultValues = TradeDefaultValues;
                        strTradeDes = TradeDes;
                    }
                }
            }
            if (strTradeFields != string.Empty)
            {
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeFields", strTradeFields);
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeDefaultValues", strTradeDefaultValues);
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeDes", strTradeDes);
            }
            string strTradeEntryFields = "";
            string strTradeEntryDefaultValues = "";
            string strTradeEntryDes = "";
            for (var i = 0; i < dgEntry.Rows.Count; i++)
            {
                string TradeEntryFields = "";
                if (dgEntry.Rows[i].Cells[0].Value != null)
                {
                    TradeEntryFields = dgEntry.Rows[i].Cells[0].Value.ToString().Trim();
                }
                string TradeEntryDefaultValues = "";
                if (dgEntry.Rows[i].Cells[1].Value != null)
                {
                    TradeEntryDefaultValues = dgEntry.Rows[i].Cells[1].Value.ToString().Trim();
                }
                string TradeEntryDes = "";
                if (dgEntry.Rows[i].Cells[2].Value != null)
                {
                    TradeEntryDes = dgEntry.Rows[i].Cells[2].Value.ToString().Trim();
                }
                
                if (TradeEntryFields != string.Empty && TradeEntryDes != string.Empty)
                {
                    if (strTradeEntryFields != string.Empty)
                    {
                        strTradeEntryFields = strTradeEntryFields + "," + TradeEntryFields;
                        strTradeEntryDefaultValues = strTradeEntryDefaultValues + "," + TradeEntryDefaultValues;
                        strTradeEntryDes = strTradeEntryDes + "," + TradeEntryDes;
                    }
                    else
                    {
                        strTradeEntryFields = TradeEntryFields;
                        strTradeEntryDefaultValues = TradeEntryDefaultValues;
                        strTradeEntryDes = TradeEntryDes;
                    }
                }
            }
            if (strTradeEntryFields != string.Empty)
            {
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeEntryFields", strTradeEntryFields);
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeEntryDefaultValues", strTradeEntryDefaultValues);
                config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "TradeEntryDes", strTradeEntryDes);
            }
            this.Dispose();
            this.Close();
        }

        private void toolHeadAdd_Click(object sender, EventArgs e)
        {
            dgHead.Rows.Add();
        }

        private void toolHeadDel_Click(object sender, EventArgs e)
        {
            if (dgHead.CurrentRow.Index > 0 && dgHead.CurrentRow.Index < dgHead.Rows.Count-1)
            {
                dgHead.Rows.Remove(dgHead.CurrentRow);
            }
        }

        private void toolEntryAdd_Click(object sender, EventArgs e)
        {
            dgEntry.Rows.Add();
        }

        private void toolEntryDel_Click(object sender, EventArgs e)
        {
            if (dgEntry.CurrentRow.Index > 0 && dgEntry.CurrentRow.Index<dgEntry.Rows.Count-1)
            {
                dgEntry.Rows.Remove(dgEntry.CurrentRow);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
