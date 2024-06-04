using Microsoft.VisualStudio.TestTools.UnitTesting;
using QP_DDNS;
using System;

namespace QP_DDNSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AliCloudHelper.DescribeDomainRecords("championimage.com.cn", "vol", "A");
        }

        [TestMethod]
        public void UpdateTest()
        {
            AliCloudHelper.Update("vol", "825193460829445120", "47.101.178.142", "A");
            AliCloudHelper.Update("demo", "734571082433774592", "47.101.178.142", "A");
            AliCloudHelper.Update("sample", "724099217879096320", "47.101.178.142", "A");
            AliCloudHelper.Update("qp", "21512307816865792", "47.101.178.142", "A");
            AliCloudHelper.Update("remote", "3392179402148864", "47.101.178.142", "A");
        }

        [TestMethod]
        public void TestIP()
        {
            var ip = IPHelper.GetIP();
            Console.WriteLine(ip);
        }
    }
}
