using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Collections;
using UnityEngine;
using SimpleJson;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System;

namespace tpgm
{

    public class NetHttp
    {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        private static HttpWebResponse CreatePostHttpResponse(string url, string parameters, Encoding charset)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;

            if (parameters != null )
            {
                StringBuilder buffer = new StringBuilder();
                {
                    buffer.Append(parameters);
                    byte[] data = charset.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }
        
        public static void HttpSend<T,S>(string url, T st, S rt)
        {

            //string url = "http://121.40.149.87:3000/login";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            //json序列化
            string json = JsonUtility.ToJson(st);
            json = "params=" + json;
            Debug.Log("" + json);
            HttpWebResponse response = NetHttp.CreatePostHttpResponse(url, json, encoding);
            //打印返回值  
            Stream stream = response.GetResponseStream();   //获取响应的字符串流  
            StreamReader sr = new StreamReader(stream); //创建一个stream读取流  
            string requit = sr.ReadToEnd();   //从头读到尾，放到字符串html  
            //Console.WriteLine(html);
            Debug.Log("httprequit" + requit);
            //json反序列化
            JsonUtility.FromJsonOverwrite(requit, rt);
            //rt = JsonConvert.DeserializeObject<S>(requit);

        }

        //对返回code判断
        public static bool HttpResult(int code)
        {
            if (code == 200)
                return true;
            else
            {
                ErrorMgr.Instance().Err_Event(code);
                return false;
            }
        }


    }

   
}
