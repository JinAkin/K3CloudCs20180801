using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class SAL_RETURNSTOCK_DAL
    {
        private ApiClient client;
        public bool loginResult;
        private string sUser;
        string strcon;
        public SAL_RETURNSTOCK_DAL(string strUrl, string strDbId, string strUser, string strPassword, string Constring, int intPort = 2052)
        {
            try
            {
                sUser = strUser;
                client = new ApiClient(strUrl);
                loginResult = client.Login(strDbId, strUser, strPassword, intPort);
                strcon = Constring;
            }
            catch
            {
                loginResult = false;
            }
        }
        public bool isExists()
        {
            bool sExists = false;
            string strSQL = "select top 1 FNumber,FQty,FPrice,FAmount,FOut_tid,FStockID  from tb_StockBillin "+
                            "where exists(select 1 from tb_shopSet01 a " +
                            "inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID "+
                            "inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID "+
                            "inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID  "+
                            "inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID "+
                            "where a.shop_id = tb_stockbillin.FCustName)   " +
                             "and FQty> 0 and FFlag = 0";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                sExists = sdr.HasRows;
            }
            return sExists;
        }
        public void BatchSave()
        {
            string strSerializeJSON = "";
            try
            {
                if (loginResult == true)
                {
                    List<SAL_RETURNSTOCK> LSR = new List<SAL_RETURNSTOCK>();
                    string strSQL = "select  distinct top 100 t.FBillNo,t.FDate,t.FAlipay_ID,t1.FCustID,t1.FOrgID,t1.FStockNumber from tb_StockBillin t " +
                                    "inner join (select b.FNUMBER FOrgID, d.FNUMBER FCustID, shop_id,case " +
                                    "when e.FNAME like '%聚美%' then '7'  " +
                                    "when e.FNAME like '%JVC%' then '23'  " +
                                    "when e.FNAME like '%京东%' then '25'  " +
                                    "when e.FNAME like '%唯品会%' then 'CK031'  " +
                                    "else '1'  " +
                                    "end as FStockNumber from tb_shopSet01 a " +
                                    "inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID " +
                                    "inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID " +
                                    "inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID " +
                                    "inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID ) t1 on  t1.shop_id = t.FCustName " +
                                    "where t.FQty > 0 and t.FFlag = 0  order by t.FDate";
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
                    {
                        while (sdr.Read())
                        {
                            string sFSettleCurrID = "PRE001";
                            string sFSettleOrgID = "01";
                            SAL_RETURNSTOCK__SubHeadEntity SubHeadEntitys = new SAL_RETURNSTOCK__SubHeadEntity(sFSettleCurrID, sFSettleOrgID);
                            SAL_RETURNSTOCK__FEntity[] FEntitys = GetEntitys(sdr["FBillNo"].ToString(), sdr["FDate"].ToString(),sdr["FStockNumber"].ToString());
                            string sFBillTypeID = "XSTHD01_SYS";
                            string sFSaleOrgId = (sdr["FOrgID"] == null || sdr["FOrgID"].ToString().Trim() == "" ? "01" : sdr["FOrgID"].ToString());
                            string sFDate = sdr["FDate"].ToString();
                            string sFStockOrgId = "01";
                            string sFCustomerID = sdr["FCustID"].ToString();
                            SAL_RETURNSTOCK sr = new SAL_RETURNSTOCK(sFBillTypeID, sFSaleOrgId, sFDate, sFCustomerID, sFStockOrgId, SubHeadEntitys, FEntitys);

                            sr.F_PAEZ_Text = sdr["FBillNo"].ToString();
                            sr.F_PAEZ_Text2 = sdr["FAlipay_ID"].ToString(); ;
                            sr.F_PAEZ_REMARKS = "导入订单";
                            LSR.Add(sr);
                        }
                    }
                    if (LSR.Count > 0)
                    {
                        SAL_RETURNSTOCK_BatchOBJECT m = new SAL_RETURNSTOCK_BatchOBJECT(LSR.ToArray());
                        m.BatchCount = LSR.Count;
                        strSerializeJSON = JsonConvert.SerializeObject(m);
                        LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "PostJsonData", sUser, strSerializeJSON);
                        string result = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.BatchSave", new object[] { "SAL_RETURNSTOCK", strSerializeJSON });
                        JObject jo = new JObject();
                        jo = (JObject)JsonConvert.DeserializeObject(result);
                        string sResult = jo["Result"].ToString();
                        JObject jsonObj = JObject.Parse(sResult);
                        Boolean IsSuccess = Convert.ToBoolean(jsonObj["ResponseStatus"]["IsSuccess"].ToString());
                        SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update t1 set t1.FFlag=1 from dbo.T_SAL_RETURNSTOCK t  inner join tb_StockBillin t1 on t.F_PAEZ_Text = t1.FBillNo where t1.FFlag = 0");
                        if (IsSuccess == true)
                        {
                            LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ResultJsonData", sUser, result);
                        }
                        else
                        {
                            LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, result);
                            LogHelper.WriteFileLog(typeof(SAL_RETURNSTOCK_DAL), result);
                        }
                    }
                    else
                    {
                        LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, "没有符合要求数据！");
                    }
                }
                else
                {
                    LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, "登陆到K3Cloud失败!");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(SAL_RETURNSTOCK_DAL), ex.ToString());
            }
        }
        public void SAVE(string FBillNo)
        {
            try
            {
                if (loginResult == true)
                {
                    string strSQL = "select  distinct top 100 t.FBillNo,t.FDate,t.FAlipay_ID,t1.FCustID,t1.FOrgID,t1.FStockNumber from tb_StockBillin t " +
                                    "inner join (select b.FNUMBER FOrgID,d.FNUMBER FCustID,shop_id,case " +
                                    "when e.FNAME like '%聚美%' then '7'  " +
                                    "when e.FNAME like '%JVC%' then '23'  " +
                                    "when e.FNAME like '%京东%' then '25'  " +
                                    "when e.FNAME like '%唯品会%' then 'CK031'  " +
                                    "else '1'  " +
                                    "end as FStockNumber  from tb_shopSet01 a " +
                                    "inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID " +
                                    "inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID " +
                                    "inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID " +
                                    "inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID ) t1 on  t1.shop_id = t.FCustName " +
                                    "Where t.FQty> 0 and t.FFlag = 0 AND t.FBillNo ='"+ FBillNo + "'";
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
                    {
                        while (sdr.Read())
                        {
                            string sFSettleCurrID = "PRE001";
                            string sFSettleOrgID = "01";
                            SAL_RETURNSTOCK__SubHeadEntity SubHeadEntitys = new SAL_RETURNSTOCK__SubHeadEntity(sFSettleCurrID, sFSettleOrgID);
                            SAL_RETURNSTOCK__FEntity[] FEntitys = GetEntitys(sdr["FBillNo"].ToString(), sdr["FDate"].ToString(),sdr["FStockNumber"].ToString());
                            string sFBillTypeID = "XSTHD01_SYS";
                            string sFSaleOrgId = (sdr["FOrgID"] == null || sdr["FOrgID"].ToString().Trim() == "" ? "01" : sdr["FOrgID"].ToString());
                            string sFDate = sdr["FDate"].ToString();
                            string sFStockOrgId = "01";
                            string sFCustomerID =  sdr["FCustID"].ToString();
                            SAL_RETURNSTOCK sr = new SAL_RETURNSTOCK(sFBillTypeID, sFSaleOrgId, sFDate,sFCustomerID,sFStockOrgId, SubHeadEntitys, FEntitys);

                            sr.F_PAEZ_Text=sdr["FBillNo"].ToString();       
                            sr.F_PAEZ_Text2= sdr["FAlipay_ID"].ToString(); ;
                            sr.F_PAEZ_REMARKS = "导入订单";
                            SAL_RETURNSTOCK_OBJECT m = new SAL_RETURNSTOCK_OBJECT(sr);
                            m.Creator = sUser;
                            string strSerializeJSON = JsonConvert.SerializeObject(m);
                            LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, strSerializeJSON);
                            string result = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SAL_RETURNSTOCK", strSerializeJSON });

                            JObject jo = new JObject();
                            jo = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                            string sResult = jo["Result"].ToString();
                            JObject jsonObj = JObject.Parse(sResult);
                            Boolean IsSuccess = Convert.ToBoolean(jsonObj["ResponseStatus"]["IsSuccess"].ToString());
                            if (IsSuccess == true)
                            {
                                SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update tb_Stockbill set FFlag=1 where FBillNo='" + sdr["FBillNo"].ToString() + "'");
                                LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, "生成销售出库单成功:" + jsonObj["Number"].ToString());
                            }
                            else
                            {
                                LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, "生成失败,错误代码:" + result);
                            }
                        }
                    }
                    LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, "生成销售退货单成功！");
                }
                
            }
            catch(Exception ex)
            {
                LogHelper.WriteLog(strcon, "SAL_RETURNSTOCK_DAL", "ErrorInfo", sUser, ex.ToString());
            }
        }
        public SAL_RETURNSTOCK__FEntity[] GetEntitys(string FBillNO,string FDate,string FStockNumber)
        {
            List<SAL_RETURNSTOCK__FEntity> lsrf = new List<SAL_RETURNSTOCK__FEntity>();
            string strSQL = "select FNumber,FQty,FPrice,FAmount,FOut_tid,FStockID  from tb_StockBillin "+
                             "where exists (select 1 from tb_shopSet01 a " +
                            "inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID "+
                            "inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID "+
                            "inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID "+
                            "inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID "+
                            "where a.shop_id = tb_StockBillin.FCustName) " +
                            "and FQty> 0 and FFlag = 0 and FBillNo='" + FBillNO + "' order by FNumber";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    string sFOwnerID = "";
                    string sFUnitID = "Pcs";
                    string sFMaterialID = sdr["FNumber"].ToString();
                    string sFDeliveryDate = FDate;
                    string sFReturnTyp = "THLX01_SYS";
                    SAL_RETURNSTOCK__FEntity sof = new SAL_RETURNSTOCK__FEntity(sFMaterialID,sFOwnerID, sFDeliveryDate, sFReturnTyp, sFUnitID, FStockNumber);
                    //sof.FPriceUnitId.FNumber = "Pcs";
                    sof.FUnitID.FNumber = "Pcs";
                    sof.FBASEARQTY = Getdecimal(sdr["FQty"].ToString());
                    sof.FPriceUnitQty = Getdecimal(sdr["FQty"].ToString());
                    sof.FRealQty = Getdecimal(sdr["FQty"].ToString());
                    sof.FTaxPrice = Getdecimal(sdr["FPrice"].ToString());
                    sof.F_PAEZ_Text4 = sdr["FOut_tid"].ToString();
                    sof.FIsFree = (sof.FTaxPrice == 0 ? "true" : "false");
                    sof.FAmount = Getdecimal(sdr["FAmount"].ToString());
                    sof.FStockId.FNumber = FStockNumber;
                    lsrf.Add(sof);
                }
            }
            return lsrf.ToArray();
        }
        private decimal Getdecimal(string strValue)
        {
            try
            {
                return decimal.Parse(strValue);
            }
            catch
            {
                return 0;
            }
        }
    }
}
