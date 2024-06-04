using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlibabaCloud.SDK.Alidns20150109;
using AlibabaCloud.SDK.Alidns20150109.Models;
using Aliyun.Credentials.Models;
using Tea;

namespace QP_DDNS
{
    public static class AliCloudHelper
    {
        private static Client _client;
        static AliCloudHelper()
        {
            _client = CreateClient();
        }

        public static AlibabaCloud.SDK.Alidns20150109.Client CreateClient()
        {
            //Config config = new Config()
            //{
            //    Type = "access_key",
            //    AccessKeyId = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["AccessKeyId"]),
            //    AccessKeySecret = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["AccessKeySecret"]),
            //};
            //var akCredential = new Aliyun.Credentials.Client(config);

            AlibabaCloud.OpenApiClient.Models.Config apiConfig = new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = ConfigurationManager.AppSettings["AccessKeyId"],
                AccessKeySecret = ConfigurationManager.AppSettings["AccessKeySecret"]
            };
            apiConfig.Endpoint = "alidns.cn-hangzhou.aliyuncs.com";
            return new AlibabaCloud.SDK.Alidns20150109.Client(apiConfig);
        }


        public static void DescribeDomainRecords(string domainName, string RR, string recordType)
        {
            AlibabaCloud.SDK.Alidns20150109.Models.DescribeDomainRecordsRequest describeDomainRecordsRequest = new AlibabaCloud.SDK.Alidns20150109.Models.DescribeDomainRecordsRequest();            // 主域名
            AlibabaCloud.TeaUtil.Models.RuntimeOptions runtime = new AlibabaCloud.TeaUtil.Models.RuntimeOptions();
            describeDomainRecordsRequest.DomainName = "championimage.com.cn";
            var resp = _client.DescribeDomainRecordsWithOptions(describeDomainRecordsRequest, runtime);
            Console.WriteLine(AlibabaCloud.TeaUtil.Common.ToJSONString(resp.ToMap()));
        }

        public static void UpdateDomainRecord(AlibabaCloud.SDK.Alidns20150109.Models.UpdateDomainRecordRequest req)
        {
            AlibabaCloud.SDK.Alidns20150109.Models.UpdateDomainRecordResponse resp = _client.UpdateDomainRecord(req);
        }

        public static void Update(string rr, string recordId, string ip, string type)
        {
            //AlibabaCloud.SDK.Alidns20150109.Models.DescribeDomainRecordsResponse resp = DescribeDomainRecords(client, "championimage.com.cn", RR, recordType);


            AlibabaCloud.SDK.Alidns20150109.Models.UpdateDomainRecordRequest req =
                new AlibabaCloud.SDK.Alidns20150109.Models.UpdateDomainRecordRequest
                {
                    RR = rr,
                    RecordId = recordId,
                    Value = ip,
                    Type = type
                };
            try
            {
                UpdateDomainRecord(req);
            }
            catch (Exception e)
            {

            }
        }
    }
}
