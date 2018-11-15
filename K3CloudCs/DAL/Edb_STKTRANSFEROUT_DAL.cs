using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace K3CloudCs
{
    public class Edb_STKTRANSFEROUT_DAL
    {
        private string strcon;
        public Edb_STKTRANSFEROUT_DAL(string Constring)
        {
            strcon = Constring;
        }
        private bool isExists()
        {
            bool sExists = false;
            string strSQL = "select top 1 1 " +
                            "from T_STK_STKTRANSFEROUT t3 " +
                            "inner join T_STK_STKTRANSFEROUTENTRY t4 on t3.fid = t4.fid " +
                            "inner join t_bd_material t1 on t1.fmaterialid = t4.fmaterialid " +
                            "inner join t_BD_Stock_l t8  on t4.FSRCSTOCKID = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "inner join T_ORG_ORGANIZATIONS t9 on t3.FSTOCKORGID=t9.FORGID where t3.FBillNo<>'' and t7.FNUMBER not like 'CK%' " +
                            "and t3.FBILLTYPEID='de3bcacc98434ec68a358aa5abcd9183' " +
                            "and t3.FDOCUMENTSTATUS = 'C' and t3.F_PAEZ_CHECKBOX=0 ";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                sExists = sdr.HasRows;
            }
            return sExists;
        }
        #region
        /// <summary>
        /// 导入分布式调拨出库单到E店宝出库单
        /// </summary>
        /// <returns></returns>
        public string AddStockOut(string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            string strJson = string.Empty;
            if (isExists() == true)
            {
                bool isSuccess = false;

                while (isSuccess != true)
                {
                    EdbLib edb = new EdbLib(StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    Dictionary<String, String> @params = edb.edbGetCommonParams("edbOutStoreAdd");
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<info>");
                    List<string> BillNos = new List<string>();
                    builder = GetCentaur_OutStorageList(builder, out BillNos);
                    builder.Append("<product_info>");
                    foreach (string BillNo in BillNos)
                    {
                        builder = GetOutStorage_ItemList(builder, BillNo);
                    }
                    builder.Append("</product_info>");
                    builder.Append("</info>");
                    @params["xmlValues"] = builder.ToString();

                    strJson = edb.edbRequstPost(@params, out isSuccess);
                    edb = null;
                }
                
                if (strJson != string.Empty)
                {
                    UpdateSTKTRANSFEROUT(strJson);
                }
                
            }
            LogHelper.WriteLog(strcon, "Edb_STKTRANSFEROUT_DAL", "ResultJsonData", "", strJson);
            return strJson;
        }
        private void UpdateSTKTRANSFEROUT(string sJson)
        {
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(sJson);
                JArray arr = (JArray)jo["Success"]["items"]["item"];
                for (int i = 0; i < arr.Count; i++)
                {
                    JObject obj = (JObject)arr[i];
                    if (obj["is_success"].ToString() == "True")
                    {
                        string FBillNo = obj["field"].ToString();
                        SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update T_STK_STKTRANSFEROUT set F_PAEZ_CHECKBOX=1 where fbillno='" + FBillNo + "'", null);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(Edb_STKTRANSFEROUT_DAL), ex.ToString());
            }
        }
        private StringBuilder GetOutStorage_ItemList(StringBuilder builder, string FBillNo)
        {
            string strSQL = "select t1.FNumber,t4.FQty,t4.FPRICE,t4.FLot,t7.FNumber FDestStockID " +
                            "from T_STK_STKTRANSFEROUT t3 " +
                            "inner join T_STK_STKTRANSFEROUTENTRY t4 on t3.fid = t4.fid " +
                            "inner join t_bd_material t1 on t1.fmaterialid = t4.fmaterialid " +
                            "inner join t_BD_Stock_l t8  on t4.FDeststockid = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "where T3.FBillNo='" + FBillNo + "'";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    builder.Append("<product_item>");
                    builder.Append("<outstorage_no>" + FBillNo + "</outstorage_no>");                    
                    int FQTY = Convert.ToInt32(Convert.ToDouble((sdr["FQty"] == null ? 0 : sdr["FQty"]).ToString()));
                    builder.Append("<outstorage_num>" + FQTY.ToString() + "</outstorage_num>");
                    builder.Append("<storage_no>" + sdr["FDestStockID"].ToString() + "</storage_no>");
                    builder.Append("<productItem_no></productItem_no>");
                    builder.Append("<location_no></location_no>");
                    builder.Append("<outstorage_price>" + sdr["FPRICE"].ToString() + "</outstorage_price>");
                    builder.Append("<batch>" + sdr["FLot"].ToString() + "</batch>");
                    builder.Append("<freight_avg></freight_avg>");
                    builder.Append("<outstorage_remark></outstorage_remark>");
                    builder.Append("<bar_code>" + sdr["FNumber"].ToString() + "</bar_code>");
                    builder.Append("</product_item>");
                }
            }
            return builder;
        }
        private StringBuilder GetCentaur_OutStorageList(StringBuilder builder, out List<string> FBillNos)
        {
            List<string> BillNos = new List<string>();
            string strSQL = "select distinct top 100  t3.FBillNo,t3.FCREATEDATE,t7.FNUMBER,t3.FNOTE,t9.FNUMBER FORGNumber " +
                            "from T_STK_STKTRANSFEROUT t3 " +
                            "inner join T_STK_STKTRANSFEROUTENTRY t4 on t3.fid = t4.fid " +
                            "inner join t_bd_material t1 on t1.fmaterialid = t4.fmaterialid " +
                            "inner join t_BD_Stock_l t8  on t4.FSRCSTOCKID = t8.fstockid " +
                            "inner join t_BD_Stock t7 on t7.fstockid = t8.fstockid " +
                            "inner join T_ORG_ORGANIZATIONS t9 on t3.FSTOCKORGID=t9.FORGID where t3.FBillNo<>'' and t7.FNUMBER not like 'CK%' " +
                            "and t3.FBILLTYPEID='de3bcacc98434ec68a358aa5abcd9183' " +
                            "and t3.FDOCUMENTSTATUS = 'C' and t3.F_PAEZ_CHECKBOX=0 ";

            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    BillNos.Add(sdr["FBillNo"].ToString());
                    builder.Append("<orderInfo>");
                    builder.Append("<outstorage_no>" + sdr["FBillNo"].ToString() + "</outstorage_no>");
                    builder.Append("<outstorage_type>299</outstorage_type>");//8正常入库  9采购入库 10其它入库
                    builder.Append("<outstorage_time>" + DateTime.Parse(sdr["FCREATEDATE"].ToString()).ToString("yyyy-MM-dd") + "</outstorage_time>");
                    builder.Append("<storage_no>" + sdr["FNUMBER"].ToString() + "</storage_no>");
                    builder.Append("<supplier_no>11</supplier_no>");
                    builder.Append("<freight_avgway></freight_avgway>");
                    builder.Append("<freight></freight>");
                    builder.Append("<outStorage_remark>" + sdr["FNote"].ToString() + "</outStorage_remark>");
                    builder.Append("<import_sign>未导入</import_sign>");
                    builder.Append("<relate_orderNo></relate_orderNo>");
                    builder.Append("<YS_instorage_no></YS_instorage_no>");
                    builder.Append("</orderInfo>");
                }
            }
            FBillNos = BillNos;
            return builder;
        }
        #endregion
    }
}
