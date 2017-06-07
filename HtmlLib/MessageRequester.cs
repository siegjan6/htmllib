using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HtmlLib
{
    public class MessageRequester
    {


        public string Resolve(Parameter p)
        {
            string req = PrepareParamert(p);

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Post;
                msg.RequestUri = new Uri("http://ad.cheduo.com/act/do.php");
                msg.Headers.Add("Host", "ad.cheduo.com");

                // msg.Headers.Add("Content-Length", str.Length.ToString());
                msg.Headers.Add("Cache-Control", "max-age=0");
                msg.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                msg.Headers.Add("Origin", "http://ad.cheduo.com");
                msg.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36");

                msg.Headers.Add("Referer", "http://ad.cheduo.com/act/iframe.php?p=1&pid=122");
                //msg.Headers.Add("Accept-Encoding", "gzip,deflate");
                msg.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");

                msg.Content = new StringContent(req);
                msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                Task<HttpResponseMessage> response = client.SendAsync(msg);
                response.Wait();

                HttpResponseMessage respMsg = response.Result;
                bool isError = respMsg.StatusCode != System.Net.HttpStatusCode.OK;

                if (null == respMsg)
                {
                    return string.Empty;
                }

                Task<byte[]> task = respMsg.Content.ReadAsByteArrayAsync();
                task.Wait();

                byte[] contents = task.Result;
                string result = Encoding.UTF8.GetString(contents);

                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(result);

                HtmlNodeCollection hc = hd.DocumentNode.SelectNodes("//html/body/div[1]/div[2]/div[1]/div[1]/span[1]");


                if (null != hc && hc.Count > 0)
                {
                    return hc[0].InnerHtml;
                }
               
            }
            return string.Empty;
        }

        private string PrepareParamert(Parameter pm)
        {
            string str = @"pid={0}&platform={1}&product={2}&province={3}&city={4}&licenseNo={5}&vehiclePrice={6}&enrollYear={7}&enrollMonth={8}&contactName={9}&contactMobile={10}";

            str = string.Format(str,pm.PId,pm.Platfrom,pm.Product,pm.Province,pm.City,pm.LienceNo,pm.Vehicle,pm.EnrollYear,pm.EnrollMonth,pm.ContractName,pm.ContractMobile);

            return str;
        }
    }
}
