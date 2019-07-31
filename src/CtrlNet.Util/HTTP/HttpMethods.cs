using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CtrlNet.Util.HTTP
{
    /// <summary>
    ///     Http方法
    /// </summary>
    public class HttpMethods
    {
        /// <summary>
        /// 创建HttpClient
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreateHttpClient(string url, IDictionary<string, string> cookies = null)
        {
            HttpClient httpclient;
            HttpClientHandler handler = new HttpClientHandler();
            var uri = new Uri(url);
            if (cookies != null)
            {
                foreach (var key in cookies.Keys)
                {
                    string one = key + "=" + cookies[key];
                    handler.CookieContainer.SetCookies(uri, one);
                }
            }
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                httpclient = new HttpClient(handler);
            }
            else
            {
                httpclient = new HttpClient(handler);
            }
            return httpclient;
        }
        #region 同步请求

        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, string jsonData)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent(jsonData);
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="req">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, byte[] req)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new ByteArrayContent(req);
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }
        /// <summary>
        ///     post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="pairs">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> pairs)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new FormUrlEncodedContent(pairs);
            var result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;

        }
        /// <summary>
        /// get 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            Task<string> result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        #endregion

        #region 异步请求
        /// <summary>
        ///     post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">请求参数</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostAsync(string url, string jsonData)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent(jsonData);
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var result = httpClient.PostAsync(url, postData);
            return result;
        }
        /// <summary>
        ///     post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="req">请求参数</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostAsync(string url, byte[] req)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new ByteArrayContent(req);
            var result = httpClient.PostAsync(url, postData);
            return result;
        }
        /// <summary>
        ///     post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="pairs">请求参数</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> pairs)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new FormUrlEncodedContent(pairs);
            var result = httpClient.PostAsync(url, postData);
            return result;
        }

        /// <summary>
        ///     get 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var result = httpClient.GetAsync(url);
            return result;
        }
        #endregion

    }
}
