using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace K3CloudCs
{

    public class EdbLib
    {
        private string dbhost = string.Empty;// 主账号(正式时让EDB分配)
        private string appkey = string.Empty;// (正式时让EDB分配)
        private string appscret = string.Empty;// (正式时让EDB分配)
        private string token = string.Empty;// (正式时让EDB分配)        
        private string serviceUrl = string.Empty;// 服务器地址(正式时让EDB分配)
        public EdbLib(string StrserviceUrl,string Strdbhost,string Strappkey,string Strappscret,string Strtoken)
        {
            serviceUrl = StrserviceUrl;
            dbhost = Strdbhost;
            appkey = Strappkey;
            appscret = Strappscret;
            token = Strtoken;
        }
        /// <summary>
        /// 获取公共参数
        /// </summary>
        /// <param name="method">接口名称</param>
        /// <returns>公共参数</returns>
        public Dictionary<String, String> edbGetCommonParams(String method)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            map["method"] = method;// 接口名称
            map["dbhost"] = this.dbhost;
            map["appkey"] = this.appkey;
            map["format"] = "JSON";// 返回的数据格式
            map["timestamp"] = DateTime.Now.ToString("yyyyMMddHHmm");// timestamp 全小写
            map["v"] = "2.0";// 版本号
            map["slencry"] = "1";//
            map["ip"] = "192.168.1.153";// 本机ip
            return map;
        }

        /// <summary>
        /// 开始请求
        /// </summary>
        /// <param name="params"> 参数(不要包含appscret和token)</param>
        /// <returns>服务回应</returns>
        public String edbRequstPost(Dictionary<String, String> @params,out bool isSuccess)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder1 = new StringBuilder();
            foreach (String key in @params.Keys)
            {
                string val = key.ToLower() == "xmlvalues" ? HttpUtility.UrlEncode(@params[key], Encoding.UTF8) : @params[key];
                builder.AppendFormat("{0}={1}&", key, HttpUtility.UrlEncode(val, Encoding.UTF8));
                builder1.AppendFormat("{0}={1}&", key, @params[key]);
            }
            builder.Append("sign=" + edbSignature(@params));            
            byte[] bytesToPost = Encoding.UTF8.GetBytes(builder.ToString());
            HttpWebRequest httpWebRequest = null;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Timeout = 300000;
                System.Net.ServicePointManager.DefaultConnectionLimit = 50;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Method = "POST";
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.ContentLength = bytesToPost.Length;
                httpWebRequest.ServicePoint.Expect100Continue = false;
                httpWebRequest.GetRequestStream().Write(bytesToPost, 0, bytesToPost.Length);
                string response = string.Empty;
                while (true)
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                        continue;                    
                    using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream())) response = reader.ReadToEnd();
                    //httpWebResponse.Close();
                    break;
                }
                isSuccess = true;
                return response;
            }
            catch(Exception ex)
            {
                if (httpWebRequest != null) httpWebRequest.Abort();
                httpWebRequest = null;
                isSuccess = false;
                return ex.ToString();
                //return string.Empty;
                //return ex.ToString();
                //return string.Empty;
            }
        }
      
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="params">参数</param>
        /// <returns>签名结果</returns>
        private String edbSignature(Dictionary<String, String> @params)
        {
            SortedDictionary<String, String> treeMap = new SortedDictionary<String, String>(@params, new Comparator());
            treeMap["appscret"] = this.appscret;
            treeMap["token"] = this.token;
            // 拼接要签名的字符串
            StringBuilder builder = new StringBuilder(this.appkey);
            foreach (string key in treeMap.Keys)
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(treeMap[key])) continue;
                builder.Append(key + treeMap[key]);
            }
            // 使用MD5加密
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
            //把二进制转化为大写的十六进制
            builder.Clear();
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X");
                builder.Append(hex.Length == 1 ? "0" + hex : hex);
            }
            return builder.ToString();
        }

        /**
         * 比较器
         */
        private class Comparator : IComparer<String>
        {
            public int Compare(string x, string y)
            {
                return x.ToLower().CompareTo(y.ToLower());
            }
        }
    }
}


