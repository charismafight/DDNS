using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QP_DDNS
{
    public partial class Service1 : ServiceBase
    {
        private bool _stopping = false;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new Task(() =>
            {
                while (true)
                {
                    if (_stopping)
                    {
                        break;
                    }

                    // 刷新
                    var ip = IPHelper.GetIP();
                    if (!string.IsNullOrWhiteSpace(ip))
                    {
                        AliCloudHelper.Update("vol", "825193460829445120", ip, "A");
                        AliCloudHelper.Update("demo", "734571082433774592", ip, "A");
                        AliCloudHelper.Update("sample", "724099217879096320", ip, "A");
                        AliCloudHelper.Update("qp", "21512307816865792", ip, "A");
                        AliCloudHelper.Update("remote", "3392179402148864", ip, "A");
                    }

                    Thread.Sleep(10000);
                }
            }).Start();
        }

        protected override void OnStop()
        {
            _stopping = true;
        }
    }
}
