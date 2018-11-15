using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class Store_DAL
    {
        private string strcon;
        public Store_DAL(string Constring)
        {
            strcon = Constring;
        }
        public int GetOrgID(string Fnumber)
        {
            int OrgID = 0;
            try
            {
                object oOrgID = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select FORGID from T_ORG_ORGANIZATIONS where FNUMBER='" + Fnumber + "'", null);
                if (oOrgID != null)
                {
                    OrgID = int.Parse(oOrgID.ToString());
                }
                else
                {
                    OrgID = 0;
                }
            }
            catch
            {
                OrgID = 0;
            }
            return OrgID;
        }
        public bool isExistsStore(int Store_id)
        {
            bool isExists = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Store_name  from tb_StoreSet where Store_id=" + Store_id + " ", null);
                if (IsExists != null)
                {
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }
            }
            catch
            {
                isExists = false;
            }
            return isExists;
        }
        public int GetStoreID(string Fnumber)
        {
            int StoreID = 0;
            try
            {
                object OStoreID = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select FSTOCKID from T_BD_STOCK where FNUMBER='" + Fnumber + "' ", null);
                if (OStoreID != null)
                {
                    StoreID = int.Parse(OStoreID.ToString());
                }
                else
                {
                    StoreID = 0;
                }
            }
            catch
            {
                StoreID = 0;
            }
            return StoreID;
        }
        public bool Add(Store so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Store_name  from tb_StoreSet where Store_id=" + so.Store_id + " ", null);
                if (IsExists == null)
                {
                    int isAdd = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "insert into tb_StoreSet(Store_id,Store_name,StockOrg_id,Stock_id)values(" + so.Store_id + ",'" + so.Store_name + "'," + so.StoreOrg_id + "," + so.Stock_id + ") ", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Alter(Store so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Store_name  from tb_StoreSet where Store_id=" + so.Store_id + " ", null);
                if (IsExists != null)
                {
                    int isAlter = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update tb_StoreSet set Store_name='" + so.Store_name + "',StockOrg_id=" + so.StoreOrg_id + ",Stock_id=" + so.Stock_id + " where Store_id=" + so.Store_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Del(int Store_id)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Store_name  from tb_StoreSet where Store_id=" + Store_id + " ", null);
                if (IsExists != null)
                {
                    int isDel = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "delete from  tb_StoreSet where Store_id=" + Store_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public List<Store> GetStoreSetList()
        {
            List<Store> lso = new List<Store>();
            string strSQL = "select a.Store_id,a.Store_name,b.FORGID,b.FNUMBER FOrgNumber,c.FNAME FOrgName,d.FSTOCKID,d.FNUMBER FStoreNumber ,e.FNAME FStoreName from tb_StoreSet a "+
                            "inner join T_ORG_ORGANIZATIONS b on a.StockOrg_id = b.FORGID "+
                            "inner join T_ORG_ORGANIZATIONS_L c on a.StockOrg_id = c.FORGID "+
                            "inner join T_BD_STOCK d on a.Store_id = d.FSTOCKID  and d.FUSEORGID = b.FORGID "+
                            "inner join T_BD_STOCK_L e on a.Store_id = e.FSTOCKID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    Store so = new Store();
                    so.Store_id = int.Parse(sdr["Store_id"].ToString());
                    so.Store_name = sdr["Store_name"].ToString();
                    so.Stock_id = int.Parse(sdr["FSTOCKID"].ToString());
                    so.Stock_Name = sdr["FStoreName"].ToString();
                    so.Stock_Number = sdr["FStoreNumber"].ToString();
                    so.StoreOrg_id = int.Parse(sdr["FORGID"].ToString());
                    so.StoreOrg_Name = sdr["FOrgName"].ToString();
                    so.StoreOrg_Number = sdr["FOrgNumber"].ToString();
                    lso.Add(so);
                }
            }
            return lso;
        }
    }
}
