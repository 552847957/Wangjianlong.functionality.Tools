using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wangjianlong.API.Test
{
    public class APITestTool
    {
        public string HOST_ADDRESS { get; set; }

        public void Post(string url, string postData)
        {
            url = HOST_ADDRESS + url;
            Console.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Console.WriteLine("成功设置request的MIME类型及内容长度");


            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            Console.WriteLine("打开request字符流");

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch(WebException ex)
            {
                response = ex.Response;
            }
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            Console.WriteLine("完成POST");
        }

        public void Get(string url,string getData)
        {
            url = HOST_ADDRESS + url;
            Console.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
            request.Method = "get";
            byte[] byteArray = Encoding.UTF8.GetBytes(getData);
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            //request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Console.WriteLine("成功设置request的MIME类型及内容长度");


            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            Console.WriteLine("打开request字符流");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            Console.WriteLine("完成Get");
        }

        public string Post1(string url,string postData)
        {
            url = HOST_ADDRESS + url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Accept = "test/html,application/xhtml+xml,*/*";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch(WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }

        }
    }
}
