using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace K3CloudCs
{
    public class SAL_OUTSTOCK_DAL
    {
        private ApiClient client;
        public bool loginResult;
        private string sUser;
        string strcon;
        public SAL_OUTSTOCK_DAL(string strUrl, string strDbId, string strUser, string strPassword, string Constring, int intPort = 2052)
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
            bool sExists= false;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, "exec dbo.p_edb_Exists"))
            {
                sExists = sdr.HasRows;
            }
            return sExists;
        }
        public List<K3CloudMaterial> GetNotExistsK3CloudStockMaterial()
        {
            List<K3CloudMaterial> K3CloudMaterialList = new List<K3CloudMaterial>();
            string strSQL = "select distinct product_no,pro_name,specification from v_EDB_MaterialErrorList order by product_no";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    K3CloudMaterial KM = new K3CloudMaterial();
                    KM.FNumber = sdr["product_no"].ToString();
                    KM.FName = sdr["pro_name"].ToString();
                    KM.FDes = sdr["specification"].ToString();
                    K3CloudMaterialList.Add(KM);
                }
            }
            return K3CloudMaterialList;
        }
        public List<K3CloudMaterial> GetNotExistK3CloudMaterial()
        {
            List<K3CloudMaterial> K3CloudMaterialList = new List<K3CloudMaterial>();
            string strSQL = "select distinct product_no,pro_name,specification from tb_TradeEntry where not  exists(select 1 from T_BD_MATERIAL where FNUMBER = tb_TradeEntry.product_no) order by product_no";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    K3CloudMaterial KM = new K3CloudMaterial();
                    KM.FNumber = sdr["product_no"].ToString();
                    KM.FName = sdr["pro_name"].ToString();
                    KM.FDes = sdr["specification"].ToString();
                    K3CloudMaterialList.Add(KM);
                }
            }
            return K3CloudMaterialList;
        }
        public void BatchSave()
        {
            string strSerializeJSON="";
            try
            {
                if (loginResult == true)
                {
                    List<SAL_OUTSTOCK> LSO = new List<SAL_OUTSTOCK>();
                    StringBuilder builder = new StringBuilder();
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, "exec dbo.p_edb_BatchSave"))
                    {
                        while (sdr.Read())
                        {
                            string sFSettleCurrID = "PRE001";
                            string sFSettleOrgID = "01";
                            SAL_OUTSTOCK__SubHeadEntity SubHeadEntitys = new SAL_OUTSTOCK__SubHeadEntity(sFSettleCurrID, sFSettleOrgID);
                            SAL_OUTSTOCK__FEntity[] FEntitys = GetEntitys(sdr["FBillNo"].ToString());
                            List<SAL_OUTSTOCK__FOutStockTrace> lsofst = new List<SAL_OUTSTOCK__FOutStockTrace>();
                            SAL_OUTSTOCK__FOutStockTrace[] FOutStockTraces = lsofst.ToArray();
                            string sFBillTypeID = "XSCKD01_SYS";

                            string sFSaleOrgId = (sdr["FOrgNumber"] == null || sdr["FOrgNumber"].ToString().Trim() == "" ? "01" : sdr["FOrgNumber"].ToString());
                            string sFDate = sdr["FDate"].ToString();
                            string sFStockOrgId = "01";
                            string sFCustomerID = (sdr["FCustID"] == null || sdr["FCustID"].ToString() == "" || decimal.Parse(sdr["FCustID"].ToString()) == 0 ? "02.001" : sdr["FCustID"].ToString());
                            SAL_OUTSTOCK so = new SAL_OUTSTOCK(sFBillTypeID, sFSaleOrgId, sFDate, sFStockOrgId, sFCustomerID, SubHeadEntitys, FEntitys, FOutStockTraces);
                            so.FNote = "备注";
                            builder.Append(sdr["FBillNo"].ToString()+",");
                            so.F_PAEZ_Text = sdr["FBillNo"].ToString();
                            so.F_PAEZ_Text2 = sdr["FCustID"].ToString();
                            LSO.Add(so);
                        }
                    }
                    
                    if (LSO.Count>0)
                    {
                        SAL_OUTSTOCK_BatchOBJECT m = new SAL_OUTSTOCK_BatchOBJECT(LSO.ToArray());
                        m.BatchCount = LSO.Count;
                        strSerializeJSON = JsonConvert.SerializeObject(m);
                        string result = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.BatchSave", new object[] { "SAL_OUTSTOCK", strSerializeJSON });
                        JObject jo = new JObject();
                        jo = (JObject)JsonConvert.DeserializeObject(result);
                        string sResult = jo["Result"].ToString();
                        JObject jsonObj = JObject.Parse(sResult);
                        Boolean IsSuccess = Convert.ToBoolean(jsonObj["ResponseStatus"]["IsSuccess"].ToString());
                        string tids = builder.ToString();
                        tids = tids.Substring(0, tids.Length - 1);
                        SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "exec dbo.p_edb_UpdateFlag '" + tids + "'");
                        if (IsSuccess != true)
                        {
                            LogHelper.WriteFileLog(typeof(SAL_OUTSTOCK_DAL), tids);
                            LogHelper.WriteFileLog(typeof(SAL_OUTSTOCK_DAL), jsonObj["ResponseStatus"]["Errors"].ToString());
                        }
                    }
                    else
                    {
                        LogHelper.WriteFileLog(typeof(SAL_OUTSTOCK_DAL), "没有符合要求数据！");
                    }                   
                }
                else
                {
                    LogHelper.WriteFileLog(typeof(SAL_OUTSTOCK_DAL), "登陆到K3Cloud失败!");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(SAL_OUTSTOCK_DAL), ex.ToString());              
            }
        }
        public void SAVE(string FBillNo)
        {
            try
            {
                if (loginResult == true)
                {
                    SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@FBillNo", FBillNo) };
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, "exec dbo.p_edb_GetHead @FBillNo", Param))
                    {
                        while (sdr.Read())
                        {
                            string sFSettleCurrID = "PRE001";
                            string sFSettleOrgID = "01";
                            SAL_OUTSTOCK__SubHeadEntity SubHeadEntitys = new SAL_OUTSTOCK__SubHeadEntity(sFSettleCurrID, sFSettleOrgID);
                            SAL_OUTSTOCK__FEntity[] FEntitys = GetEntitys(sdr["FBillNo"].ToString());
                            List<SAL_OUTSTOCK__FOutStockTrace> lsofst = new List<SAL_OUTSTOCK__FOutStockTrace>();
                            SAL_OUTSTOCK__FOutStockTrace[] FOutStockTraces = lsofst.ToArray();
                            string sFBillTypeID = "XSCKD01_SYS";
                            
                            string sFSaleOrgId = (sdr["FOrgNumber"] == null || sdr["FOrgNumber"].ToString().Trim()=="" ? "01" : sdr["FOrgNumber"].ToString());
                            string sFDate = sdr["FDate"].ToString();
                            string sFStockOrgId = "01";
                            string sFCustomerID = (sdr["FCustID"] == null || sdr["FCustID"].ToString()=="" || decimal.Parse(sdr["FCustID"].ToString()) == 0  ? "02.001" : sdr["FCustID"].ToString());
                            SAL_OUTSTOCK so = new SAL_OUTSTOCK(sFBillTypeID, sFSaleOrgId, sFDate, sFStockOrgId, sFCustomerID, SubHeadEntitys, FEntitys, FOutStockTraces);
                            so.FNote = "备注";

                            so.F_PAEZ_Text = sdr["FBillNo"].ToString();
                            so.F_PAEZ_Text2 = sdr["FCustID"].ToString();

                            SAL_OUTSTOCK_OBJECT m = new SAL_OUTSTOCK_OBJECT(so);
                            m.Creator = sUser;
                            string strSerializeJSON = JsonConvert.SerializeObject(m);                          
                            string result  = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SAL_OUTSTOCK", strSerializeJSON });
                            JObject jo = new JObject();
                            jo = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                            string sResult = jo["Result"].ToString();
                            JObject jsonObj = JObject.Parse(sResult);
                            Boolean IsSuccess = Convert.ToBoolean(jsonObj["ResponseStatus"]["IsSuccess"].ToString());
                            if (IsSuccess == true)
                            {
                                LogHelper.WriteLog(strcon, "SAL_OUTSTOCK", "ResultJsonData", sUser, result);
                                SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update tb_Trade set is_flag=1 where tid='" + sdr["FBillNo"].ToString() + "'");
                            }
                            else
                            {
                                JArray arr = (JArray)jsonObj["ResponseStatus"]["Errors"];
                                LogHelper.WriteLog(strcon, "SAL_OUTSTOCK", "ErrorInfo", sUser, arr.ToString());
                            }
                        }
                    }                   
                }
                else
                {
                    LogHelper.WriteLog(strcon, "SAL_OUTSTOCK", "ErrorInfo", sUser, "登陆到K3Cloud失败!");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(strcon, "SAL_OUTSTOCK", "ErrorInfo", sUser, ex.ToString());
            }
        }
        public SAL_OUTSTOCK__FEntity[] GetEntitys(string FBillNO)
        {
            List<SAL_OUTSTOCK__FEntity> lsof = new List<SAL_OUTSTOCK__FEntity>();
            SqlParameter[] Param = new SqlParameter[] {new SqlParameter("@FBillNo", FBillNO)};
            using (SqlDataReader sdrDetail = SqlHelper.ExecuteReader(strcon, CommandType.Text, "exec dbo.p_edb_GetEntitys @FBillNo", Param))
            {
                while (sdrDetail.Read())
                {
                    string sFOwnerID = "01";
                    string sFUnitID = "Pcs";
                    string sFNumber = sdrDetail["FNumber"].ToString();
                    SAL_OUTSTOCK_BD_MATERIAL sFMaterialID = new SAL_OUTSTOCK_BD_MATERIAL(sFNumber);
                    SAL_OUTSTOCK__FEntity sof = new SAL_OUTSTOCK__FEntity(sFOwnerID, sFUnitID, sFMaterialID);                   
                    sof.FUnitID.FNumber = "Pcs";
                    sof.FBASEARQTY = (sdrDetail["FQty"] == null || sdrDetail["FQty"].ToString() == "" ? "1" : sdrDetail["FQty"].ToString());
                    sof.FPriceUnitQty = (sdrDetail["FQty"] == null || sdrDetail["FQty"].ToString() == "" ? "1" : sdrDetail["FQty"].ToString());
                    sof.FInventoryQty = (sdrDetail["FQty"] == null || sdrDetail["FQty"].ToString() == "" ? "1" : sdrDetail["FQty"].ToString());
                    sof.FRealQty =(sdrDetail["FQty"]==null || sdrDetail["FQty"].ToString()=="" ? "1": sdrDetail["FQty"].ToString());
                    sof.FPrice = (sdrDetail["FPrice"].ToString() == "" || sdrDetail["FPrice"] == null ? 0 : decimal.Parse(sdrDetail["FPrice"].ToString()));
                    sof.FTaxNetPrice = (sdrDetail["FPrice"].ToString() == "" || sdrDetail["FPrice"] == null ? 0 : decimal.Parse(sdrDetail["FPrice"].ToString()));
                    sof.FTaxPrice = (sdrDetail["FPrice"].ToString() == "" || sdrDetail["FPrice"] == null ? 0 : decimal.Parse(sdrDetail["FPrice"].ToString()));
                    sof.FIsFree = (sdrDetail["FPrice"].ToString() == "" || sdrDetail["FPrice"] == null|| decimal.Parse(sdrDetail["FPrice"].ToString())==0 ? "true" :"false");
                    sof.F_PAEZ_Text3 = sdrDetail["FOut_tid"].ToString();
                    sof.FAmount= decimal.Parse(sdrDetail["FAmount"].ToString());
                    sof.FAmount_LC = decimal.Parse(sdrDetail["FAmount"].ToString());
                    sof.FAllAmount_LC = decimal.Parse(sdrDetail["FAmount"].ToString());
                    sof.FAllAmount= decimal.Parse(sdrDetail["FAmount"].ToString());
                    sof.FStockID.FNumber = sdrDetail["FStockID"].ToString(); //从中间表中取到的仓库值为1
                    lsof.Add(sof);
                }
            }
            return  lsof.ToArray();
        }

    }
}
