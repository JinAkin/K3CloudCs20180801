using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class Edb_RETURNSTOCK_DAL
    {
        private string strcon;
        string date_type = "";
        string page_size = "";
        public Edb_RETURNSTOCK_DAL(string Constring, string strpage_size, string strdate_type)
        {
            strcon = Constring;
            date_type = strdate_type;
            page_size = strpage_size;
        }
        
        /// <summary>
        /// 下载当天退货单信息
        /// </summary>
        public void DownloadReturnToDB(string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            ConfigHelper config = new ConfigHelper();
            string strdt1 = config.ReadValueByKey(ConfigurationFile.AppConfig, "退货到货日期");
            if (strdt1 != null)
            {
                DateTime dt1 = Convert.ToDateTime(strdt1);
                if (dt1 < DateTime.Now)
                {
                    for (int i = 1; i <= 24; i++)
                    {
                        DateTime dt2 = dt1.AddHours(1);
                        if (dt2 > DateTime.Now) break;
                        bool isSuccess = false;
                        string strJson = string.Empty;
                        while (isSuccess != true)
                        {
                            EdbLib edb = new EdbLib(StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                            Dictionary<String, String> @params = edb.edbGetCommonParams("edbTradReturnGet");
                            @params["date_type"] = "退货到货日期";
                            @params["start_time"] = dt1.ToString();
                            @params["end_time"] = dt2.ToString();
                            @params["page_no"] = "1";
                            @params["page_size"] = "1000";

                            strJson = edb.edbRequstPost(@params, out isSuccess);
                            edb = null;
                        }
                        
                        if (strJson != string.Empty)
                        {
                            List<Edb_RETURNSTOCK> lco = JsonToObject(strJson);
                             ObjectToData(lco);
                        }
                        dt1 = dt2;
                    }
                    if (dt1 > DateTime.Now)
                    {
                        dt1 = DateTime.Now;
                    }
                    config.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "退货到货日期", dt1.ToString());
                }                
            }           

        }
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="sJson"></param>
        /// <returns></returns>
        private List<Edb_RETURNSTOCK> JsonToObject(string sJson)
        {
            List<Edb_RETURNSTOCK> coList = new List<Edb_RETURNSTOCK>();
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(sJson);
                JArray arr = (JArray)jo["Success"]["items"]["item"];
                for (int i = 0; i < arr.Count; i++)
                {
                    JObject obj = (JObject)arr[i];
                    string strBillNO = obj["aftersale_id"].ToString();
                    if (IsExists(strBillNO) == false)
                    {
                        Edb_RETURNSTOCK co = new Edb_RETURNSTOCK();
                        co.FDate = DateTime.ParseExact(obj["create_time"].ToString(), "yyyyMMdd HH:mm:ss", null);
                        co.FBillNo = strBillNO;
                        co.FOut_tid = obj["out_tid"].ToString();
                        co.FShopID = int.Parse(obj["shop_id"].ToString());
                        co.FStockID = obj["send_storage"].ToString();
                        co.Falipay_id = obj["buyer_id"].ToString();
                        co.Forder_totalfee = StringToDb(obj["total_goods_refund_fee"].ToString());
                        co.FNote = obj["service_remarks"].ToString();

                        JArray arrItems = (JArray)obj["aftersale_id_item"];
                        for (int j = 0; j < arrItems.Count; j++)
                        {
                            JObject objItem = (JObject)arrItems[j];
                            co.FQty = StringToDb(objItem["arrive_num"].ToString());//退货到货数量
                            co.FNumber = objItem["product_id"].ToString();//产品编号
                            co.FPrice = StringToDb(objItem["refund_fee"].ToString());//item_price>商品原销售单价
                            co.FCustName = objItem["Geto_ware"].ToString();//正品转入仓库ID
                            co.Foriginal_price = StringToDb(objItem["item_price"].ToString());//原价
                            co.Fitem_discountfee = 0; //单品优惠金额
                            co.Fcredit_amount = 0; //抵扣分摊金额
                            co.Fdiscount_amount = 0; //打折金额
                            co.FName = objItem["product_name"].ToString();
                            co.FBrand_Number = objItem["band_id"].ToString();
                            co.FBrand_Name = ""; // Node.Nodes[i].NodeByName('tid_item').Nodes[l].NodeByName('brand_name"].ToString();
                            co.FBarcode = ""; // Node.Nodes[i].NodeByName('tid_item').Nodes[l].NodeByName('barcode"].ToString();
                            coList.Add(co);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(Edb_RETURNSTOCK_DAL), ex.ToString());
            }
            return coList;
        }
        /// <summary>
        /// 将对象列表导入到中间表中
        /// </summary>
        /// <param name="coList"></param>
        /// <returns></returns>
        private bool ObjectToData(List<Edb_RETURNSTOCK> coList)
        {
            bool isSuccess = false;
            try
            {
                foreach (Edb_RETURNSTOCK co in coList)
                {
                    SqlParameter[] Param = new SqlParameter[] {
                                new SqlParameter("@FShopID", co.FShopID),
                                new SqlParameter("@FDate", co.FDate),
                                new SqlParameter("@FNumber", co.FNumber),
                                new SqlParameter("@FQty", co.FQty),
                                new SqlParameter("@FPrice", co.FPrice),
                                new SqlParameter("@FCustName", co.FCustName),
                                //new SqlParameter("@FStoreID", co.FStockName),
                                new SqlParameter("@FStockID", co.FStockID),
                                new SqlParameter("@FCustID", co.FCustID),
                                new SqlParameter("@FBillNo", co.FBillNo),
                                new SqlParameter("@Fout_tid", co.FOut_tid),
                                new SqlParameter("@Forder_totalfee", co.Forder_totalfee),
                                new SqlParameter("@Foriginal_price", co.Foriginal_price),
                                new SqlParameter("@Falipay_id", co.Falipay_id),
                                new SqlParameter("@FName", co.FName),
                                new SqlParameter("@FBrand_Number", co.FBrand_Number),
                                 new SqlParameter("@FNote", co.FNote)
                                };
                    string strsql = "insert into tb_StockBillIn(FShopID,FListCount,FDate, FItemID, FNumber, FQty, FPrice, FAmount, FCustName, FStockID,FCustID,FTypeID,FFlag,FBillNo,Fexpress,Fexpress_no,Freal_income_freight,Fout_tid,Forder_totalfee,Foriginal_price,Fitem_discountfee,Fcredit_amount,Fdiscount_amount,Falipay_id,FName,FModel,FOrgID,FBrand_Number,FBrand_Name,FBarcode,FSalePrice,FNote) " +
                                    "values(@FShopID, 0, @FDate, 0, @FNumber, @FQty, @FPrice, 0, @FCustName, @FStockID, @FCustID, 1, 0, @FBillNo, '', '', 0, @Fout_tid, @Forder_totalfee, @Foriginal_price, 0, 0, 0, @Falipay_id, @FName, '', 0, @FBrand_Number, '', '', 0, @FNote)";
                    SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, strsql, Param);
                    strsql = "update a set a.fcustid=b.FNUMBER,a.FOrgID= c.FNUMBER " +
                            "from tb_StockBillin a inner join T_BD_CUSTOMER b on a.FCustName = b.FTAXREGISTERCODE " +
                            "inner join T_ORG_ORGANIZATIONS c on a.FCustName = c.FPOSTCODE " +
                            "where (a.fcustid='' or a.FOrgID='') and a.FCustName<>''";

                    SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, strsql, null);
                }
                isSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(Edb_RETURNSTOCK_DAL), ex.ToString());
            }
            return isSuccess;
        }

        private double StringToDb(string dbString)
        {
            try
            {
                return double.Parse(dbString);
            }
            catch
            {
                return 0;
            }
        }
        private bool IsExists(string strBillNO)
        {
            bool isEx = false;
            object o = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select FID from tb_StockBillin where FBillNo='" + strBillNO + "'");
            if (o != null)
            {
                isEx = true;
            }
            return isEx;
        }

    }
}
