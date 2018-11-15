using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace K3CloudCs
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteFileLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }
        public static void DelDbLog()
        {
            try
            {
                ConfigHelper config = new ConfigHelper();
                string strdt1 = config.ReadValueByKey(ConfigurationFile.AppConfig, "LogDays");
                string strSQL = "delete from tb_LogInfo where FDate<DATEADD(d,-"+ strdt1 + ",getdate()) ";
                string constr = config.ReadValueByKey(ConfigurationFile.AppConfig, "ConnectionString");
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, strSQL);
            }
            catch
            {

            }
        }
        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteFileLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        #endregion
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(string ConnectString, string FBillType, string FMesType, string FUser, string FContent)
        {
            SqlParameter[] Param = new SqlParameter[] {
                    new SqlParameter("@FBillType", FBillType),
                    new SqlParameter("@FMesType", FMesType),
                    new SqlParameter("@FUser", FUser),
                    new SqlParameter("@FContent", FContent)
                };
            string strsql = "insert into tb_LogInfo(FBillType,FDate,FMesType,FUser,FContent) values (@FBillType,GetDate(),@FMesType,@FUser,@FContent)";
            int iResult = System.Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConnectString, CommandType.Text, strsql, Param));
        }

        #endregion
        #region 将Base64编码的文本转换成普通文本
        /// <summary>
        /// 将Base64编码的文本转换成普通文本
        /// </summary>
        /// <param name="base64">Base64编码的文本</param>
        /// <returns></returns>
        public static string Base64StringToString(string base64)
        {
            if (base64 != "")
            {
                char[] charBuffer = base64.ToCharArray();
                byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);
                string returnstr = Encoding.Default.GetString(bytes);
                return returnstr;
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region 字符串转为base64字符串
        public static string changebase64(string str)
        {
            if (str != "" && str != null)
            {
                byte[] b = Encoding.Default.GetBytes(str);
                string returnstr = Convert.ToBase64String(b);
                return returnstr;
            }
            else
            {
                return "";
            }
        }
        #endregion
        //二进制转字符串：      
        public static string ConvertToString(byte[] thebyte)
        {
            char[] Chars = new char[System.Text.Encoding.Default.GetCharCount(thebyte, 0, thebyte.Length)];
            System.Text.Encoding.Default.GetChars(thebyte, 0, thebyte.Length, Chars, 0);
            string newString = new string(Chars);
            return newString;
        }

        //字符串转二进制：      
        public static byte[] ConvertToByte(string theString)
        {
            byte[] byteStream = System.Text.Encoding.Default.GetBytes(theString);
            return byteStream;
        }
    }
}
