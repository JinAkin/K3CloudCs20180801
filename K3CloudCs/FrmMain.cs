using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace K3CloudCs
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        string constr = "";
        string strUrl = "";
        string strDbId = "";
        string strUser = "";
        string strPassword = "";
        string strEUrl = "";
        string strEDbhost = "";
        string strESecret = "";
        string strEAppkey = "";
        string strEToken = "";
        string date_type = "";
        string page_size = "";
        private class ErrorInfo
        {
            public string type;
            public List<K3CloudMaterial> ObjectList;
        }
        private void bwSalOutK3Cloud_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SAL_OUTSTOCK_DAL s = new SAL_OUTSTOCK_DAL(strUrl, strDbId, strUser, strPassword, constr);
            if(s.loginResult == true)
            {
                if (s.isExists() == true)
                {
                    s.BatchSave();
                }
            }
            else
            {
                LogHelper.WriteFileLog(typeof(FrmMain), "K3Cloud登录失败!");
            }
        }
        private void toolParSet_Click(object sender, EventArgs e)
        {
            FrmParSet frm = new FrmParSet();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ConfigHelper config = new ConfigHelper();
            timerEdbSTKTRANSFER.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerEdbSTKTRANSFER"));
            timerEdbOUTSTOCK.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerEdbOUTSTOCK"));
            timerErrorOUTSTOCK.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerErrorOUTSTOCK"));
            timerEdbRETURNSTOCK.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerEdbRETURNSTOCK"));            
            timerK3CloudSalOut.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerK3CloudSalOut"));            
            timerK3CloudSalReturn.Interval = int.Parse(config.ReadValueByKey(ConfigurationFile.AppConfig, "timerK3CloudSalReturn"));                     
            constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
            strUrl = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_Url");
            strDbId = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_DbId");
            strUser = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_User");
            strPassword = config.ReadValueByKey(ConfigurationFile.AppConfig, "K_Password");
            strEUrl = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Url");
            strEDbhost = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Dbhost");
            strESecret = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_secret");
            strEAppkey = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_Appkey");
            strEToken = config.ReadValueByKey(ConfigurationFile.AppConfig, "E_token");
            date_type = config.ReadValueByKey(ConfigurationFile.AppConfig, "date_type");
            page_size = config.ReadValueByKey(ConfigurationFile.AppConfig, "page_size");
            Start();
        }

        private void toolStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Start()
        {
            timerEdbSTKTRANSFER.Enabled = true;
            timerEdbOUTSTOCK.Enabled = true;
            timerEdbRETURNSTOCK.Enabled = true;
            timerK3CloudSalOut.Enabled = true;
            timerErrorOUTSTOCK.Enabled = true;
            timerK3CloudSalReturn.Enabled = true;
            timerDelDbLog.Enabled = true;
            toolEnd.Enabled = true;
            toolStart.Enabled = false;
            if (bwK3CloudSalOut.IsBusy == false) bwK3CloudSalOut.RunWorkerAsync();
            if (bwK3CloudSalReturn.IsBusy == false) bwK3CloudSalReturn.RunWorkerAsync();
            if (bwEDBOUTSTOCK.IsBusy == false) bwEDBOUTSTOCK.RunWorkerAsync();
            if (bwEDBErrorOUTSTOCK.IsBusy == false) bwEDBErrorOUTSTOCK.RunWorkerAsync();
            if (bwEDBRETURNSTOCK.IsBusy == false) bwEDBRETURNSTOCK.RunWorkerAsync();
            if (bwEDBSTKTRANSFER.IsBusy == false) bwEDBSTKTRANSFER.RunWorkerAsync();
        }
        private void End()
        {
            timerEdbSTKTRANSFER.Enabled = false;
            timerEdbOUTSTOCK.Enabled = false;
            timerErrorOUTSTOCK.Enabled = false;
            timerEdbRETURNSTOCK.Enabled = false;
            timerK3CloudSalOut.Enabled = false;
            timerK3CloudSalReturn.Enabled = false;
            timerDelDbLog.Enabled = false;
            if (bwK3CloudSalOut.IsBusy == true) bwK3CloudSalOut.CancelAsync();
            if (bwK3CloudSalReturn.IsBusy == true) bwK3CloudSalReturn.CancelAsync();
            if (bwEDBOUTSTOCK.IsBusy == true) bwEDBOUTSTOCK.CancelAsync();
            if (bwEDBErrorOUTSTOCK.IsBusy == true) bwEDBErrorOUTSTOCK.CancelAsync();
            if (bwEDBRETURNSTOCK.IsBusy == true) bwEDBRETURNSTOCK.CancelAsync();
            if (bwEDBSTKTRANSFER.IsBusy == true) bwEDBSTKTRANSFER.CancelAsync();
            toolEnd.Enabled = false;
            toolStart.Enabled = true;
        } 

        private void toolEnd_Click(object sender, EventArgs e)
        {
            End();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            End();
        }

        private void dgMaterialErrorList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }       

        private void bwMaterialErrorList_DoWork(object sender, DoWorkEventArgs e)
        {
            Object type = e.Argument as Object;
            ErrorInfo ei = new ErrorInfo();
            switch (type.ToString())
            {
                case "Item":
                    SAL_OUTSTOCK_DAL sod = new SAL_OUTSTOCK_DAL(strUrl, strDbId, strUser, strPassword, constr);
                    ei.type = "Item";
                    ei.ObjectList = sod.GetNotExistK3CloudMaterial();
                    break;
                case "Stock":
                    SAL_OUTSTOCK_DAL sod1 = new SAL_OUTSTOCK_DAL(strUrl, strDbId, strUser, strPassword, constr);
                    ei.type = "Stock";
                    ei.ObjectList = sod1.GetNotExistsK3CloudStockMaterial();
                    break;
            }
            e.Result = ei;
        }

        private void bwMaterialErrorList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ErrorInfo ei = e.Result as ErrorInfo;
                if (ei.ObjectList.Count > 0)
                {
                    this.dgMaterialErrorList.Rows.Clear();
                    foreach (K3CloudMaterial x in ei.ObjectList)
                    {
                        int index = this.dgMaterialErrorList.Rows.Add();
                        this.dgMaterialErrorList.Rows[index].Cells[0].Value = x.FNumber;
                        this.dgMaterialErrorList.Rows[index].Cells[1].Value = x.FName;
                        this.dgMaterialErrorList.Rows[index].Cells[2].Value = x.FDes;
                    }
                }
            }
        }        
        private void timerEDBSTKTRANSFER_Tick(object sender, EventArgs e)
        {
            if (bwEDBSTKTRANSFER.IsBusy == false) bwEDBSTKTRANSFER.RunWorkerAsync();
        }

        private void bwEdbOUTSTOCK_DoWork(object sender, DoWorkEventArgs e)
        {
            Edb_OUTSTOCK_DAL EOD = new Edb_OUTSTOCK_DAL(constr,page_size,date_type);
            EOD.DownloadOutToDB(strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
            EOD = null;
        }

        private void bwSalReturnK3CloudAsy_DoWork(object sender, DoWorkEventArgs e)
        {
            SAL_RETURNSTOCK_DAL s = new SAL_RETURNSTOCK_DAL(strUrl, strDbId, strUser, strPassword, constr);
            if(s.loginResult == true)
            {
                if (s.isExists() == true)
                {
                    s.BatchSave();
                }
            }
        }
        private void bwEDBRETURNSTOCK_DoWork(object sender, DoWorkEventArgs e)
        {
            Edb_RETURNSTOCK_DAL ERD = new Edb_RETURNSTOCK_DAL(constr,page_size,date_type);
            ERD.DownloadReturnToDB(strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
            ERD = null;
        }

        private void bwEDBSTKTRANSFER_DoWork(object sender, DoWorkEventArgs e)
        {
            Edb_STKTRANSFERIN_DAL ESID = new Edb_STKTRANSFERIN_DAL(constr);
            ESID.AddStockIn(strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
            ESID = null;
            Edb_STKTRANSFEROUT_DAL ESOD = new Edb_STKTRANSFEROUT_DAL(constr);
            ESOD.AddStockOut(strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
            ESOD = null;
        }        

        private void timerEdbOUTSTOCK_Tick(object sender, EventArgs e)
        {
            if (bwEDBOUTSTOCK.IsBusy == false) bwEDBOUTSTOCK.RunWorkerAsync();
        }

        private void timerEdbRETURNSTOCK_Tick(object sender, EventArgs e)
        {
            if (bwEDBRETURNSTOCK.IsBusy == false) bwEDBRETURNSTOCK.RunWorkerAsync();
        }

        private void timerDelDbLog_Tick(object sender, EventArgs e)
        {
            LogHelper.DelDbLog();
        }

        private void timerK3CloudSalOut_Tick(object sender, EventArgs e)
        {
            if (bwK3CloudSalOut.IsBusy == false) bwK3CloudSalOut.RunWorkerAsync();
        }

        private void timerK3CloudSalReturn_Tick(object sender, EventArgs e)
        {
            if (bwK3CloudSalReturn.IsBusy == false) bwK3CloudSalReturn.RunWorkerAsync();
        }

        private void toolCheckList_Cust_Click(object sender, EventArgs e)
        {
            FrmCheckListCust frm = new FrmCheckListCust();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void toolCheckList_Stock_Click(object sender, EventArgs e)
        {
            FrmCheckListStock frm = new FrmCheckListStock();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void toolCheckList_Supper_Click(object sender, EventArgs e)
        {
            FrmCheckListSupper frm = new FrmCheckListSupper();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void toolCheckList_Par_Click(object sender, EventArgs e)
        {
            FrmCheckListPar frm = new FrmCheckListPar();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void toolOrder_Click(object sender, EventArgs e)
        {
            FrmOrder frm = new FrmOrder();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void bwEDBErrorOUTSTOCK_DoWork(object sender, DoWorkEventArgs e)
        {
            Edb_OUTSTOCK_DAL EOD = new Edb_OUTSTOCK_DAL(constr,page_size,date_type);
            EOD.DownloadErrorOutToDB(strEUrl, strEDbhost, strEAppkey, strESecret, strEToken);
        }

        private void timerErrorOUTSTOCK_Tick(object sender, EventArgs e)
        {
            if (bwEDBErrorOUTSTOCK.IsBusy == false) bwEDBErrorOUTSTOCK.RunWorkerAsync();
        }

        private void toolMaterialErrorInfo_Click(object sender, EventArgs e)
        {
            if (bwMaterialErrorList.IsBusy == false) bwMaterialErrorList.RunWorkerAsync("Item");
        }

        private void toolStockErrorInfo_Click(object sender, EventArgs e)
        {
            if (bwMaterialErrorList.IsBusy == false) bwMaterialErrorList.RunWorkerAsync("Stock");
        }

        private void toolMaterialErrorList_Click(object sender, EventArgs e)
        {
            ExcelHelper ex = new ExcelHelper();
            ex.DataToExcel(dgMaterialErrorList);
        }
    }
}
