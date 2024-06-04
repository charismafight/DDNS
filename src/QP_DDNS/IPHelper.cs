using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QP_DDNS
{
    public class IPHelper
    {
        public static string GetIP()
        {
            Stream stream = null;
            StreamReader streamReader = null;
            try
            {
                stream = WebRequest.Create("https://www.ipip5.com/").GetResponse().GetResponseStream();
                streamReader = new StreamReader(stream, Encoding.UTF8);
                var str = streamReader.ReadToEnd();
                int first = str.IndexOf("<span class=\"c-ip\">") + 19;
                int last = str.IndexOf("</span>", first);
                return str.Substring(first, last - first);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"出错了，{ex.Message}。获取失败");
            }
            finally
            {
                streamReader?.Dispose();
                stream?.Dispose();
            }

            return string.Empty;
        }
    }
}
