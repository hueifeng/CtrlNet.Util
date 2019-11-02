using CtrlNet.Util.Security;
using Xunit;

namespace CtrlNet.Util.Test.Security
{
    public class EncrypTest
    {
        /// <summary>
        ///     测试DES加密验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        [Theory]
        [InlineData("", "")]
        [InlineData("1", "")]
        [InlineData("1", "2")]
        public void DESEncryp_ValidateHandler(string input,string key)
        {
            var encode = DESEncrypt.Encrypt(input, key);
            Assert.Equal(input, DESEncrypt.Decrypt(encode, key));
        }
       /// <summary>
       ///  3DES加密验证
       /// </summary>
        [Fact]
        public void _3DESEncrypt_VerifyHandler()
        {
            var Str = "Test";
            var encode = _3DESEncrypt.Encrypt(Str);
            var Str2 = _3DESEncrypt.Decrypt(encode);
            Assert.Equal(Str, Str2);
        }
    }
}
