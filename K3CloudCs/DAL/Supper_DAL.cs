using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class SupperSet
    {
        private string strcon;
        public SupperSet(string Constring)
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
        public bool isExistsSUPPLIER(int Supper_id)
        {
            bool isExists = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Supper_name  from tb_SupperSet where Supper_id=" + Supper_id + " ", null);
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
        public int GetSUPPLIERID(string Fnumber)
        {
            int SUPPLIERID = 0;
            try
            {
                object OSUPPLIERID = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select FSUPPLIERID from T_BD_SUPPLIER where FNUMBER='" + Fnumber + "' ", null);
                if (OSUPPLIERID != null)
                {
                    SUPPLIERID = int.Parse(OSUPPLIERID.ToString());
                }
                else
                {
                    SUPPLIERID = 0;
                }
            }
            catch
            {
                SUPPLIERID = 0;
            }
            return SUPPLIERID;
        }
        public bool Add(Supper so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Supper_name  from tb_SupperSet where Supper_id=" + so.Supper_id + " ", null);
                if (IsExists == null)
                {
                    int isAdd = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "insert into tb_SupperSet(Supper_id,Supper_name,UserOrg_id,SUPPLIER_id)values(" + so.Supper_id + ",'" + so.Supper_name + "'," + so.UserOrg_id + "," + so.SUPPLIER_id + ") ", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Alter(Supper so)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Supper_name  from tb_SupperSet where Supper_id=" + so.Supper_id + " ", null);
                if (IsExists != null)
                {
                    int isAlter = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "update tb_SupperSet set Supper_name='" + so.Supper_name + "',UserOrg_id=" + so.UserOrg_id + ",SUPPLIER_id=" + so.SUPPLIER_id + " where Supper_id=" + so.Supper_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Del(int Supper_id)
        {
            bool isSuccess = false;
            try
            {
                object IsExists = SqlHelper.ExecuteScalar(strcon, CommandType.Text, "select Supper_name  from tb_SupperSet where Supper_id=" + Supper_id + " ", null);
                if (IsExists != null)
                {
                    int isDel = SqlHelper.ExecuteNonQuery(strcon, CommandType.Text, "delete from  tb_SupperSet where Supper_id=" + Supper_id + "", null);
                    isSuccess = true;
                }

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public List<Supper> GetSupperSetList()
        {
            List<Supper> lso = new List<Supper>();
            string strSQL = "select a.Supper_id,a.Supper_name,b.FORGID,b.FNUMBER FOrgNumber,c.FNAME FOrgName,d.FSUPPLIERID,d.FNUMBER FSUPPLIERNumber ,e.FNAME FSUPPLIERName from tb_SupperSet a " +
                            "inner join T_ORG_ORGANIZATIONS b on a.UserOrg_id = b.FORGID  " +
                            "inner join T_ORG_ORGANIZATIONS_L c on a.UserOrg_id = c.FORGID  " +
                            "inner join T_BD_SUPPLIER d on a.SUPPLIER_id = d.FSUPPLIERID  and d.FUSEORGID = b.FORGID  " +
                            "inner join T_BD_SUPPLIER_L e on a.SUPPLIER_id = e.FSUPPLIERID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(strcon, CommandType.Text, strSQL))
            {
                while (sdr.Read())
                {
                    Supper so = new Supper();
                    so.Supper_id = int.Parse(sdr["Supper_id"].ToString());
                    so.Supper_name = sdr["Supper_name"].ToString();
                    so.SUPPLIER_id = int.Parse(sdr["FSUPPLIERID"].ToString());
                    so.SUPPLIER_Name = sdr["FSUPPLIERName"].ToString();
                    so.SUPPLIER_Number = sdr["FSUPPLIERNumber"].ToString();
                    so.UserOrg_id = int.Parse(sdr["FORGID"].ToString());
                    so.UserOrg_Name = sdr["FOrgName"].ToString();
                    so.UserOrg_Number = sdr["FOrgNumber"].ToString();
                    lso.Add(so);
                }
            }
            return lso;
        }
    }
}
