using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class Shop_DAL
    {
        private string strcon;
        public Shop_DAL(string Constring)
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
        public bool isExistsShop(int Shop_id)
        {
            bool isExists = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select shop_name  from tb_shopSet01 where shop_id=" + Shop_id + " ", null);
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
        public int GetCustID(string Fnumber)
        {
            int CustID = 0;
            try
            {
                object OCustID = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select FCUSTID from T_BD_CUSTOMER where FNUMBER='" + Fnumber + "' ", null);
                if (OCustID != null)
                {
                    CustID =int.Parse( OCustID.ToString());
                }
                else
                {
                    CustID = 0;
                }
            }
            catch
            {
                CustID = 0;
            }
            return CustID;
        }
        public bool Add(Shop so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select shop_name  from tb_shopSet01 where shop_id=" + so.shop_id + " ", null);
                if (IsExists == null)
                {
                    int isAdd = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "insert into tb_shopSet01(shop_id,shop_name,SaleOrg_id,Cust_id)values(" + so.shop_id + ",'" + so.shop_name + "'," + so.SaleOrg_id + "," + so.Cust_id + ") ", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Alter(Shop so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select shop_name  from tb_shopSet01 where shop_id=" + so.shop_id + " ", null);
                if (IsExists != null)
                {
                    int isAlter = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update tb_shopSet01 set shop_name='" + so.shop_name + "',SaleOrg_id=" + so.SaleOrg_id + ",Cust_id=" + so.Cust_id + " where shop_id=" + so.shop_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Del(int shop_id)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select shop_name  from tb_shopSet01 where shop_id=" + shop_id + " ", null);
                if (IsExists != null)
                {
                    int isDel = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "delete from  tb_shopSet01 where shop_id=" + shop_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public List<Shop> GetShopSetList()
        {
            List<Shop> lso = new List<Shop>();
            string strSQL = "select distinct a.shop_id,a.shop_name,b.FORGID,b.FNUMBER FOrgNumber,c.FNAME FOrgName,d.FCUSTID,d.FNUMBER FCustNumber ,e.FNAME FCustName from tb_shopSet01 a " +
                            "inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID " +
                            "inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID " +
                            "inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID   " +
                            "inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    Shop so = new Shop();
                    so.shop_id = int.Parse(sdr["shop_id"].ToString());
                    so.shop_name = sdr["shop_name"].ToString();
                    so.Cust_id =int.Parse( sdr["FCUSTID"].ToString());
                    so.Cust_Name = sdr["FCustName"].ToString();
                    so.Cust_Number = sdr["FCustNumber"].ToString();
                    so.SaleOrg_id = int.Parse(sdr["FORGID"].ToString());
                    so.SaleOrg_Name = sdr["FOrgName"].ToString();
                    so.SaleOrg_Number = sdr["FOrgNumber"].ToString();
                    lso.Add(so);
                }
            }
            return lso;
        }
    }
}
