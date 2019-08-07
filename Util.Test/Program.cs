using CtrlNet.Util.HTTP;
using CtrlNet.Util.Offices;
using CtrlNet.Util.Security;
using CtrlNet.Util.Utils;
using System;
using System.Collections.Generic;

namespace Util.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //加密
            var encryptStr= DESEncrypt.Encrypt("xxxx");
            //解密
            var str = DESEncrypt.Decrypt(encryptStr);
           var str2= HttpMethods.PostAsync("url", "jsondata");
           var str1= HttpMethods.GetAsync("url");
            //Guid操作
            Guid  guid= CombUtil.NewComb();
            DateTime date = CombUtil.GetDateFromComb(guid);
            //二进制序列化
            var binary = new BinarySerializer().Serialize("obj");
            var obj= new BinarySerializer().Deserialize(binary);
            //Excel
            //导出
            ExcelHelper.ExportBytes(new List<object>(),new string[1]);
            //导入
            ExcelHelper.ExcelImport<object>("filename");

        }

        public void TestExcel1() {
           
        }
    }
}
