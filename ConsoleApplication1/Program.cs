using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Net;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlLib.Parameter p = new HtmlLib.Parameter();
            HtmlLib.MessageRequester req = new HtmlLib.MessageRequester();
            p.City = "A";
            p.ContractMobile = "15908765432";
            p.ContractName = "测试20150420";
            p.EnrollMonth = "01";
            p.EnrollYear = "2015";
            p.LienceNo = "7684";//车牌号
            p.PId = "122";
            p.Platfrom = "1";
            p.Product = "1";//固定不变
            p.Province = "沪";
            p.Vehicle = "15";//价格

            string str =  req.Resolve(p);
           
            //string str = @"pid=122&platform=1&product=1&province=%E6%B2%AA&city=A&licenseNo=12345&vehiclePrice=12&enrollYear=2015&enrollMonth=01&contactName=%E6%B5%8B%E8%AF%95&contactMobile=15908765432";
            //using (HttpClient client = new HttpClient())
            //{
            //    HttpRequestMessage msg = new HttpRequestMessage();
            //    msg.Method = HttpMethod.Post;
            //    msg.RequestUri = new Uri("http://ad.cheduo.com/act/do.php");
            //    msg.Headers.Add("Host", "ad.cheduo.com");
                
            //   // msg.Headers.Add("Content-Length", str.Length.ToString());
            //    msg.Headers.Add("Cache-Control", "max-age=0");
            //    msg.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            //    msg.Headers.Add("Origin", "http://ad.cheduo.com");
            //    msg.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36");
            
            //    msg.Headers.Add("Referer", "http://ad.cheduo.com/act/iframe.php?p=1&pid=122");
            //    //msg.Headers.Add("Accept-Encoding", "gzip,deflate");
            //    msg.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                 
            //    msg.Content = new StringContent(str);
            //    msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            //    Task<HttpResponseMessage> response = client.SendAsync(msg);
            //    response.Wait();

            //    HttpResponseMessage respMsg = response.Result;
            //    bool isError = respMsg.StatusCode != System.Net.HttpStatusCode.OK;

            //    if (null == respMsg)
            //    {
            //        return ;
            //    }

            //    Task<byte[]> task = respMsg.Content.ReadAsByteArrayAsync();
            //    task.Wait();

            //    byte[] contents = task.Result;
            //    string result =  Encoding.UTF8.GetString(contents);
            //}
            Console.WriteLine(str);
            Console.ReadKey();
        }

        
        public static System.Net.Http.Headers.CacheControlHeaderValue CacheControlHeaderValue { get; set; }
    }

    public class Server
    {
        public Server()
        {
            AppDomain domain = AppDomain.CreateDomain("AutoUpdater");
            System.Reflection.MethodInfo mi;

            domain.DoCallBack(null);
        }
    }
}
