using System;
using System.Linq;

namespace CtrlNet.Util.Extensions
{
    /// <summary>
    ///     扩展验证
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        ///     检测空值,为null则跑出Argumentnullexception异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="parameterName">参数名</param>
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
        }
        /// <summary>
        ///     是否为空
        /// </summary>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 是否为空Guid
        /// </summary>
        /// <param name="guid">guid</param>
        /// <returns>是否为空Guid</returns>
        public static bool IsEmptyGuid(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        /// <summary>
        /// 是否为空或者null的Guid
        /// </summary>
        /// <param name="guid">guid值</param>
        /// <returns>是否为空或者null的Guid</returns>
        public static bool IsNullOrEmptyGuid(this Guid? guid)
        {
            return guid == null || guid == Guid.Empty;
        }
        /// <summary>
        /// 判断字符串是否相等
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public static bool EqualsEx(this string text1, string text2)
        {
            return string.Equals(text1, text2, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 根据传入的字符串组装为符合更新或者删除sql语句in部分的字符串(字符串必须以‘,’分割)
        /// </summary>
        /// <param name="value">扩展类型</param>
        /// <returns>替换后的字符串</returns>
        public static string SqlRemoveStr(this string value)
        {
            string param = "";
            if (!string.IsNullOrEmpty(value))
            {
                var strList = value.Split(',');
                param = strList.Aggregate(param, (current, str) => current + ("'" + str + "',"));
            }
            return param.TrimEnd(',');
        }

        /// <summary>
        /// 判断是否包含字符串
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsEx(this string text, string value)
        {
            return text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// 判断是否以指定字符串开头
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StartWithEx(this string text, string value)
        {
            return text.StartsWith(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断是否以指定字符串结尾
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EndWithEx(this string text, string value)
        {
            return text.EndsWith(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断字符串是否空
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

    }
}
