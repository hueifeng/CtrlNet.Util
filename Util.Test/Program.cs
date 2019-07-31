using CtrlNet.Util.Security;
using System;

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
            Console.WriteLine("Hello World!");
        }
    }
}
