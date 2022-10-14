using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HttpClientDotNetStandard
{
    public class Class1
    {
        public static void test()
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Hello, World!");
        }


    }
    public static class ExtensionMethods
    {
        public async static Task<T> GetAsync<T>(this HttpClient httpClient, string url, Func<string, T> responseParser, Dictionary<string, string>? querString = null)
        {
            if (querString != null)
            {
                url += QueryString(querString);
            }
            await httpClient.GetAsync(url).ContinueWith((taskwithresponse) =>
            {
                var response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.ContinueWith((taskwithjsonstring) =>
                {
                    return responseParser(taskwithjsonstring.Result);
                });
            });
            return default;
        }
        public async static Task<T> PostAsync<T>(this HttpClient httpClient, HttpOptions httpOptions, string url, Func<string, T> responseParser, object body = null)
        {
            await httpClient.PostAsync(url, PrepareRequest(httpOptions, body)).ContinueWith((taskwithresponse) =>
            {
                var response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.ContinueWith((taskwithjsonstring) =>
                {
                    return responseParser(taskwithjsonstring.Result);
                });
            });
            return default;
        }
        /// <summary>
        /// uses FormUrlEncodedContent wich will encode the data and send it using application/x-www-form-urlencoded content type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="responseParser"></param>
        /// <returns></returns>
        public async static Task<T> PostFormDataAsync<T>(
            this HttpClient httpClient,
            string url,
            Dictionary<string, string> body,
            Func<string, T> responseParser)
        {
            var content = new FormUrlEncodedContent(body);
            await httpClient.PostAsync(url, content).ContinueWith((taskwithresponse) =>
            {
                HttpResponseMessage response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.ContinueWith((taskwithjsonstring) =>
                {
                    return responseParser(taskwithjsonstring.Result);
                });
            });
            return default;
        }

        private static StringContent PrepareRequest(HttpOptions httpOptions, object body = null, Dictionary<string, object> headers = null)
        {
            //if (headers != null)
            //{
            //    client.DefaultRequestHeaders.Clear();
            //    foreach (KeyValuePair<string, object> header in headers)
            //    {
            //        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
            //    }
            //}
            if (body != null)
            {

                string stringBody = JsonConvert.SerializeObject(body);
                return new StringContent(stringBody, Encoding.UTF8, httpOptions.ToString());
            }
            return null;
        }
        private static string QueryString(Dictionary<string, string> queryString)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in queryString)
            {
                query.Add(item.Key, item.Value);
            }
            return '?' + query.ToString();
        }
    }

    public class HttpOptions
    {
        public static ContentTypes? ContentType { get; }
    }
    public class ContentTypes
    {
        public static readonly string application_json = "application/json";
        public static readonly string application_x_www_form_urlencoded = "application/x-www-form-urlencoded";
        public static readonly string application_octet_stream = "application/octet-stream";
        public static readonly string image_jpeg = "image/jpeg";
        public static readonly string multipart_form_data = "multipart/form-data";
        public static readonly string Content_Disposition = "Content-Disposition";
    }
}

