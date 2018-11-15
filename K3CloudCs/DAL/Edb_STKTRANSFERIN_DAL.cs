using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace K3CloudCs
{
    public class Edb_STKTRANSFERIN_DAL 
    {
        private string strcon;
        public Edb_STKTRANSFERIN_DAL(string Constring)
        {
            strcon = Constring;
        }
        private bool isExists()
        {
            bool sExists = false;
            string strSQL = "select top 1 1 " +
                            "from T_STK_STKTRANSFERIN t3 " +
                            "inner join T_STK_STKTRANSFERINEntry t4 on t3.fid = t4.fid " +
                            "inner join t_BD_Stock_l t8  on t4.FDeststockid = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "inner join T_ORG_ORGANIZATIONS t9 on t3.FSTOCKORGID=t9.FORGID where t3.fbillno<>''  and t7.FNUMBER not like 'CK%' " +
                            "and (select COUNT(distinct FDESTSTOCKID) from T_STK_STKTRANSFERINEntry where FID=t3.FID)=1 " +
                            "and t3.FBILLTYPEID='e65a4f29743a44b7b67dc8145e1f9c92' and t3.FDOCUMENTSTATUS = 'C' and t3.F_PAEZ_CHECKBOX=0 ";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                sExists = sdr.HasRows;
            }
            return sExists;
        }
        public List<string> DownloadOutToDB(string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            List<string> returnList = new List<string>();
            for (int i = -100; i < 0; i++)
            {
                bool isSuccess = false;
                string strJson = string.Empty;
                while (isSuccess != true)
                {
                    EdbLib edb = new EdbLib(StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    Dictionary<String, String> @params = edb.edbGetCommonParams("edbInStoreGet");
                    @params["type"] = "1";
                    @params["date_type"] = "制单日期create_time";
                    @params["begin_time"] = DateTime.Now.AddDays(i).ToShortDateString();
                    @params["end_time"] = DateTime.Now.AddDays(i + 1).ToShortDateString();
                    @params["page_no"] = "1";
                    @params["page_size"] = "1000";

                    strJson = edb.edbRequstPost(@params, out isSuccess);
                    edb = null;
                }
                
                if (strJson != string.Empty)
                {
                    returnList = JsonToStockObject(strJson, returnList);
                }                
            }
            return returnList;
        }
        
        private List<string> JsonToStockObject(string sJson,List<string> slist)
        {
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(sJson);
                JArray arr = (JArray)jo["Success"]["items"]["item"];
                for (int i = 0; i < arr.Count; i++)
                {
                    JObject obj = (JObject)arr[i];
                    string stockname =obj["storage"].ToString() +";"+ obj["storage_name"].ToString();
                    bool isExists = false;
                    foreach(string s in slist)
                    {
                        if (s == stockname)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (isExists == false)
                    {
                        slist.Add(stockname);
                    }
                    
                }
            }
            catch 
            {
            }
            return slist;
        }
        #region
        /// <summary>
        /// 导入分布式调拨单到E店宝入库单
        /// </summary>
        /// <returns></returns>
        public string AddStockIn(string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            string strJson = string.Empty;
            if (isExists() == true)
            {
                bool isSuccess = false;

                while (isSuccess != true)
                {
                    EdbLib edb = new EdbLib(StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    Dictionary<String, String> @params = edb.edbGetCommonParams("edbInStoreAdd");
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<info>");
                    List<string> BillNos = new List<string>();
                    builder = GetCentaur_InStorageList(builder, out BillNos);
                    builder.Append("<product_info>");
                    foreach (string BillNo in BillNos)
                    {
                        builder = GetInStorage_ItemList(builder, BillNo);
                    }
                    builder.Append("</product_info>");
                    builder.Append("</info>");
                    @params["xmlValues"] = builder.ToString();

                    strJson = edb.edbRequstPost(@params, out isSuccess);
                    edb = null;
                }
                
                if (strJson != string.Empty)
                {
                    UpdateSTKTRANSFERIN(strJson);
                }                
            }
            return strJson;            
        }
        private void UpdateSTKTRANSFERIN(string sJson)
        {
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(sJson);
                JArray arr = (JArray)jo["Success"]["items"]["item"];
                for (int i = 0; i < arr.Count; i++)
                {
                    JObject obj = (JObject)arr[i];
                    if (obj["is_success"].ToString() == "true")
                    {
                        string FBillNo = obj["field"].ToString();
                        SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update T_STK_STKTRANSFERIN set F_PAEZ_CHECKBOX=1 where fbillno='"+ FBillNo + "'", null);
                    }                    
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(Edb_STKTRANSFERIN_DAL), ex.ToString());
            }
        }
        private StringBuilder GetInStorage_ItemList(StringBuilder builder, string FBillNo)
        {
            string strSQL = "select t1.FNumber,t4.FQty,t4.FPRICE,t4.FDestLot,t7.FNumber FDestStockID " +
                            "from T_STK_STKTRANSFERIN t3 " +
                            "inner join T_STK_STKTRANSFERINEntry t4 on t3.fid = t4.fid " +
                            "inner join t_bd_material t1 on t1.fmaterialid = t4.fmaterialid " +
                            "inner join t_BD_Stock_l t8  on t4.FDeststockid = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "where T3.FBillNo='" + FBillNo + "'";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    builder.Append("<product_item>");
                    builder.Append("<instorage_no>" + FBillNo + "</instorage_no>");
                    int FQTY = Convert.ToInt32(Convert.ToDouble((sdr["FQty"] == null ? 0 : sdr["FQty"]).ToString()));
                    builder.Append("<instorage_num>" + FQTY.ToString() + "</instorage_num>");
                    builder.Append("<storage_no>" + sdr["FDestStockID"].ToString() + "</storage_no>");
                    builder.Append("<cost>" + sdr["FPRICE"].ToString() + "</cost>");
                    builder.Append("<batch>" + sdr["FDestLot"].ToString() + "</batch>");
                    builder.Append("<expire_Time></expire_Time>");
                    builder.Append("<bar_code>" + sdr["FNumber"].ToString() + "</bar_code>");
                    builder.Append("</product_item>");
                }
            }
            return builder;
        }
        private StringBuilder GetCentaur_InStorageList(StringBuilder builder, out List<string> FBillNos)
        {
            List<string> BillNos = new List<string>();
            string strSQL = "select distinct top 100  t3.FBillNo,t3.FDate,t7.FNUMBER,t3.FNOTE,t9.FNUMBER FORGNumber " +
                            "from T_STK_STKTRANSFERIN t3 " +
                            "inner join T_STK_STKTRANSFERINEntry t4 on t3.fid = t4.fid " +
                            "inner join t_BD_Stock_l t8  on t4.FDeststockid = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "inner join T_ORG_ORGANIZATIONS t9 on t3.FSTOCKORGID=t9.FORGID where t3.fbillno<>''  and t7.FNUMBER not like 'CK%' " + 
                            "and (select COUNT(distinct FDESTSTOCKID) from T_STK_STKTRANSFERINEntry where FID=t3.FID)=1 "+
                            "and t3.FBILLTYPEID='e65a4f29743a44b7b67dc8145e1f9c92' and t3.FDOCUMENTSTATUS = 'C' and t3.F_PAEZ_CHECKBOX=0 ";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    if (sdr["FBillNo"].ToString() != "")
                    {
                        BillNos.Add(sdr["FBillNo"].ToString());
                        builder.Append("<orderInfo>");
                        builder.Append("<instorage_no>" + sdr["FBillNo"].ToString() + "</instorage_no>");
                        builder.Append("<instorage_type>8</instorage_type>");//8正常入库  9采购入库 10其它入库
                        builder.Append("<instorage_time>" + DateTime.Parse(sdr["FDate"].ToString()).ToString("yyyy-MM-dd") + "</instorage_time>");
                        builder.Append("<storage_no>" + sdr["FNUMBER"].ToString() + "</storage_no>");
                        builder.Append("<supplier_no>11</supplier_no>");
                        builder.Append("<delivery_no>铺货退货</delivery_no>");
                        builder.Append("<instorage_reason></instorage_reason>");
                        builder.Append("<cost></cost>");
                        builder.Append("<procure_cost></procure_cost>");
                        builder.Append("<other_cost></other_cost>");
                        builder.Append("<pact_totalAmount></pact_totalAmount>");
                        builder.Append("<out_pactNo></out_pactNo>");
                        builder.Append("<WL_company></WL_company>");
                        builder.Append("<express_no></express_no>");
                        builder.Append("<inStorage_remark>" + sdr["FNote"].ToString() + "</inStorage_remark>");
                        builder.Append("<import_sign>未导入</import_sign>");
                        builder.Append("</orderInfo>");
                    }                    
                }
            }
            FBillNos = BillNos;
            return builder;
        }
        #endregion

    }
}
