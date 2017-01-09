using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web
{
    public static class HtmlContentHelper
    {

        //效果 http://tool.hovertree.com/a/zz/img/
        /// <summary> 
        /// 取得HTML中所有图片的 URL。 
        /// </summary> 
        /// <param name="sHtmlText">HTML代码</param> 
        /// <returns>图片的URL列表</returns> 
        public static string[] GetHvtImgUrls(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签 
            Regex m_hvtRegImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            //参考:http://hovertree.com/hvtart/bjae/e4pya1x0.htm


            // 搜索匹配的字符串 
            MatchCollection matches = m_hvtRegImg.Matches(sHtmlText);
            int m_i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表 
            foreach (Match match in matches)
                sUrlList[m_i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }
        public static string GetFirstImgUrl(string sHtmlText)
        {
            string path = string.Empty;
            string[] sUrlList = GetHvtImgUrls(sHtmlText);
            if (sUrlList.Length > 0)
                path = sUrlList[0].Replace("&amp;","&");
            if (string.IsNullOrEmpty(path))
                path = SystemContext.Instance.GetDefaultImg();//设置默认图片
            return path;
        }
        public static string GetFirstUrl(string sHtmlText)
        {
            string path = string.Empty;
            MatchCollection ms = Regex.Matches(sHtmlText, @"(?is)<a(?:(?!href=).)*href=(['""]?)(?<url>[^""\s>]*)\1[^>]*>(?<text>(?:(?!</?a\b).)*)</a>"
, RegexOptions.IgnoreCase);
            if (ms.Count > 0)
                path = ms[0].Groups["url"].Value;
            return path;
        }
        /// <summary>
        /// 获取摘要
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static string GetSummary(string sHtmlText)
        {
            if (string.IsNullOrEmpty(sHtmlText))
                return string.Empty;
            string szText = Regex.Replace(sHtmlText, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase).Replace("\n", "").Replace("\t", "");
            if (szText.Length <= 150)
                return szText.Substring(0, szText.Length);
            else
                return szText.Substring(0, 150);
        }
        /// <summary>
        /// 获取访问者客户端IP
        /// </summary>
        public static string IP
        {
            get
            {
                string _ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (_ip == null || _ip == "" || _ip == "unknown") { _ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
                if (_ip == null || _ip == "" || _ip == "unknown") { _ip = System.Web.HttpContext.Current.Request.UserHostAddress; }
                if (_ip.Contains(",")) { _ip = _ip.Split(',')[0]; }

                return _ip;
            }
        }

        public static string GetImgBoxUrl(this HtmlHelper htmlHelper, int ImageSize, string ImageUrl)
        {
            string result = string.Empty;
            if (ImageUrl.IndexOf("_") > -1)
            {
                result = ImageUrl.Substring(0, ImageUrl.LastIndexOf("_"))
                    + "_" + ImageSize +
                    ImageUrl.Substring(ImageUrl.LastIndexOf("."));
            }
            else
            {
                result = ImageUrl.Substring(0, ImageUrl.LastIndexOf("."))
                      + "_" + ImageSize +
                      ImageUrl.Substring(ImageUrl.LastIndexOf("."));
            }
            return result;
        }

        /// <summary>
        /// 抓取网页内容
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <returns></returns>
        public static string WebPageContentGet(string url)
        {
            return WebPageContentGet(url, "utf-8");
        }

        /// <summary>
        /// 抓取网页内容
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="charset">网页编码</param>
        /// <returns></returns>
        public static string WebPageContentGet(string url, string charset)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            Encoding coding;
            if (charset == "gb2312")
            {
                coding = System.Text.Encoding.GetEncoding("gb2312");
            }
            else
            {
                coding = System.Text.Encoding.UTF8;
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), coding);
            string s = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();
            response.Close();
            reader = null;
            response = null;
            request = null;
            return s;
        }

        /// <summary>
        /// 抓取网页内容
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="charset">网页编码</param>
        /// <returns></returns>
        public static string WebPageContentGet(string url, Encoding code)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            Encoding coding = code;
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), coding);
            string s = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            response.Close();
            reader = null;
            response = null;
            request = null;
            return s;
        }

        public static string WebPagePostGet(string url, string data, string charset)
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] byte1 = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byte1.Length;
                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(byte1, 0, byte1.Length);    //写入参数
                newStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                Encoding coding;
                if (charset == "gb2312")
                {
                    coding = System.Text.Encoding.GetEncoding("gb2312");
                }
                else
                {
                    coding = System.Text.Encoding.UTF8;
                }
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), coding);
                string s = reader.ReadToEnd();

                reader.Close();
                reader.Dispose();
                response.Close();
                reader = null;
                response = null;
                request = null;
                return s;
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }


        public static string WebPagePostGet(string url, string data, Encoding code)
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] byte1 = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byte1.Length;
                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(byte1, 0, byte1.Length);    //写入参数
                newStream.Close();
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                Encoding coding = code;
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), coding);
                string s = reader.ReadToEnd();

                reader.Close();
                reader.Dispose();
                response.Close();
                reader = null;
                response = null;
                request = null;
                return s;
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }
        /// <summary>
        /// 抓取网页标题
        /// </summary>
        /// <param name="content">网页内容</param>
        /// <returns></returns>
        public static string WebPageTitleGet(string content)
        {
            Match match = Regex.Match(content, "<title>(.*)</title>");
            string result = match.Groups[1].Value.ToString();
            return result;
        }
        /// <summary>
        /// 抓取网页描述
        /// </summary>
        /// <param name="content">网页内容</param>
        /// <returns></returns>
        public static string WebPageDescriptionGet(string content)
        {
            string regex = "<meta" + @"\s+" + "name=\"description\"" + @"\s+" + "content=\"(?<content>[^\"" + @"\<\>" + "]*)\"";
            Match match = Regex.Match(content, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string result = match.Groups[1].Value.ToString();
            return result;
        }
        /// <summary>
        /// 抓取网页关键词
        /// </summary>
        /// <param name="content">网页内容</param>
        /// <returns></returns>
        public static string WebPageKeywordsGet(string content)
        {
            string regex = "<meta" + @"\s+" + "name=\"keywords\"" + @"\s+" + "content=\"(?<content>[^\"" + @"\<\>" + "]*)\"";
            Match match = Regex.Match(content, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string result = match.Groups[1].Value.ToString();
            return result;
        }

        /// <summary>
        /// 抓取网页文章内容
        /// </summary>
        /// <param name="content">网页内容</param>
        /// <returns></returns>
        public static string WebPageArticleGet(string content)
        {
            string regex = @"(?is)<div\s+class=""article-content"">(?><div[^>]*>(?<o>)|</div>(?<-o>)|(?:(?!</?div\b).)*)*(?(o)(?!))</div>";
            Match match = Regex.Match(content, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string result = match.Value.ToString();
            return result;
        }
    }
}