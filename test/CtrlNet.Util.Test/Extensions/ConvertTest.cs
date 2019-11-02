using CtrlNet.Util.Extensions;
using System;
using Xunit;

namespace CtrlNet.Util.Test.Extensions
{
    public class ConvertTest
    {
        /// <summary>
        ///     转换整型测试
        /// </summary>
        [Theory]
        [InlineData(null,0)]
        [InlineData("",0)]
        [InlineData("XX",0)]
        [InlineData("1", 1)]
        [InlineData("100.68", 101)]
        [InlineData("100.460", 100)]
        public void ToIntTest(object input,int result) {
            Assert.Equal(result, input.ToInt());
        }
        /// <summary>
        ///     转换可空整形测试
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        [Theory]
        [InlineData(null,null)]
        [InlineData("", null)]
        [InlineData("XX", null)]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("100.68", 101)]
        [InlineData("100.460", 100)]
        public void ToIntOrNullTest(object input,int? result) {
            Assert.Equal(result, input.ToIntOrNull());
        }
        /// <summary>
        ///     转换为64位浮点型
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="digits"></param>
        [Theory]
        [InlineData(null,0,null)]
        [InlineData("",0,null)]
        [InlineData("XX",0, null)]
        [InlineData("0",0, 0)]
        [InlineData("1",1, 1)]
        [InlineData("1.2",1.2,null)]
        [InlineData("11.626",11.63, 2)]
        [InlineData("11.624",11.62,2)]
        [InlineData("11.625", 11.62, 2)]
        public void ToDoubleTest(object input,double result, int? digits) {
            Assert.Equal(result,input.ToDouble(digits));
        }

        /// <summary>
        ///     转换为64位可空浮点型
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="digits"></param>
        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", null, null)]
        [InlineData("XX", null, null)]
        [InlineData("0", 0d, null)]
        [InlineData("1", 1d, 1)]
        [InlineData("1.2", 1.2, null)]
        [InlineData("11.626", 11.63, 2)]
        [InlineData("11.624", 11.62, 2)]
        [InlineData("11.625", 11.62, 2)]
        public void ToDoubleOrNullTest(object input,double? result,int? digits) {
            Assert.Equal(result,input.ToDoubleOrNull(digits));
        }

        /// <summary>
        ///     转换为128位浮点数
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="digits"></param>
        [Theory]
        [InlineData(null, 0, null)]
        [InlineData("", 0, null)]
        [InlineData("1A", 0, null)]
        [InlineData("0", 0, null)]
        [InlineData("1", 1, null)]
        [InlineData("1.2", 1.2, null)]
        [InlineData("12.235", 12.24, 2)]
        [InlineData("12.345", 12.34, 2)]
        [InlineData("12.3451", 12.35, 2)]
        [InlineData("12.346", 12.35, 2)]
        public void ToDecimalTest(object input,decimal result,int? digits) {
            Assert.Equal(result,input.ToDecimal(digits));
        }
        /// <summary>
        ///     转换为128位可空浮点数
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="digits"></param>
        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", null, null)]
        [InlineData("1A", null, null)]
        [InlineData("1A", null, 2)]
        public void ToDecimalOrNullTest(object input,decimal? result,int? digits) {
            Assert.Equal(result,input.ToDecimalOrNull(digits));
        }
        /// <summary>
        ///     转换为日期
        /// </summary>
        [Fact]
        public void ToDateTest() {
            Assert.Equal(new DateTime(2019,1,1),"2019-1-1".ToDate());
        }

        /// <summary>
        ///     转换为可空日期
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        [Theory]
        [InlineData(null,null)]
        [InlineData("", null)]
        [InlineData("XX", null)]
        public void ToDateOrNullTest(object input,DateTime? result) {
            Assert.Equal(result,input.ToDateOrNull());
        }

        [Theory]
        [InlineData("",false)]
        [InlineData(null,false)]
        [InlineData("XX",false)]
        [InlineData("0",false)]
        [InlineData("否",false)]
        [InlineData("no", false)]
        [InlineData("true", true)]
        [InlineData("1",true)]
        [InlineData("是", true)]
        [InlineData("yes", true)]
        public void ToBoolTest(object input, bool result) {
            Assert.Equal(result,input.ToBool());
        }

        /// <summary>
        /// 转换为可空布尔型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("XX", null)]
        [InlineData("0", false)]
        [InlineData("否", false)]
        [InlineData("no", false)]
        [InlineData("false", false)]
        [InlineData("1", true)]
        [InlineData("是", true)]
        [InlineData("yes", true)]
        [InlineData("true", true)]
        public void ToBoolOrNullTest(object input, bool? result)
        {
            Assert.Equal(result, input.ToBoolOrNull());
        }



    }
}
