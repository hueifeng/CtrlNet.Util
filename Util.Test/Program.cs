using CtrlNet.Util.HTTP;
using CtrlNet.Util.Offices;
using CtrlNet.Util.Security;
using CtrlNet.Util.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Util.Test;

namespace Util.Test
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            // //加密
            // var encryptStr= DESEncrypt.Encrypt("xxxx");
            // //解密
            // var str = DESEncrypt.Decrypt(encryptStr);
            //var str2= HttpMethods.PostAsync("url", "jsondata");
            //var str1= HttpMethods.GetAsync("url");
            // //Guid操作
            // Guid  guid= CombUtil.NewComb();
            // DateTime date = CombUtil.GetDateFromComb(guid);
            // //二进制序列化
            // var binary = new BinarySerializer().Serialize("obj");
            // var obj= new BinarySerializer().Deserialize(binary);
            // //Excel
            // //导出
            // ExcelHelper.ExportBytes(new List<object>(),new string[1]);
            // //导入
            // ExcelHelper.ExcelImport<object>("filename");
            HostFactory.Run(x =>
            {
                x.Service<Startup>(sc =>
                {
                    sc.ConstructUsing(name => new Startup(name));
                    sc.WhenStarted((s, hostControl) => s.Start(hostControl));
                    sc.WhenStopped((s, hostControl) => s.Stop(hostControl));
                });
                x.RunAsLocalSystem();
                x.SetDescription("洪力网Signalr服务");
                x.SetServiceName("洪力网SignalrService");
            });
            
  
        }
 

        public static  void HttpAsync()
        {

            Parallel.For(0, 100000, (i) =>
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync("http://123.233.116.37:8082/sysManage/Account/Login").Result;
                    Console.WriteLine($"{i}:{result.StatusCode}");
                }

            });


        }
    }
}
