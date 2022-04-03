using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace BanqueMisrOnlinePayment.Helpers
{
    public static class HttpService
    {
        public static T HttpPost<T>(string url, object body, List<KeyValuePair<string, string>> headerList = null)
        {
            using (var client = new HttpClient())
            {
                StringContent content = client.PrepareRequest(body, headerList);

                return ParseResponse<T>(client.PostAsync(url, content).Result);
            }
        }
        public static T HttpPut<T>(string url, object body, List<KeyValuePair<string, string>> headerList = null)
        {
            using (var client = new HttpClient())
            {
                StringContent content = client.PrepareRequest(body, headerList);
                try
                {
                    return ParseResponse<T>(client.PutAsync(url, content).Result);

                }
                catch (Exception ex)
                {

                }
                return default(T);
            }
        }

        public static T HttpGet<T>(string url, List<KeyValuePair<string, string>> headerList = null)
        {
            using (var client = new HttpClient())
            {
                client.PrepareRequest(null, headerList);

                return ParseResponse<T>(client.GetAsync(url).Result);
            }
        }

        private static StringContent PrepareRequest(this HttpClient client, object body, List<KeyValuePair<string, string>> headerList = null)
        {
            // Add Authorization Header
            string authHeaderValue = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("merchant." + "aa" + ":" + "dada"));

            client.DefaultRequestHeaders.Add("Authorization", authHeaderValue);
            if (headerList != null)
            {
                foreach (KeyValuePair<string, string> header in headerList)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            try
            {
                if (body != null)
                {
                    string bodyStr = body.ToJSON();
                    StringContent Content = new StringContent(bodyStr, Encoding.UTF8, "application/json");
                    
                    return Content;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private static T ParseResponse<T>(HttpResponseMessage response)
        {
            string responseString = string.Empty;
            T httpResponse = default(T);

            if (response != null)
            {

                responseString = response.Content.ReadAsStringAsync().Result;
                //responseString = response.Content.ReadAsStringAsync().Result;
            }
            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            {
                if (response.Content.Headers.ContentType.MediaType.ToLower() == "application/json" && typeof(T) != typeof(string))
                {
                    //HttpErrorResponse httpError = JsonConvert.DeserializeObject<HttpErrorResponse>(responseString);
                   // throw new Exception(httpError.Error.Explanation);
                }
            }

            if (!string.IsNullOrEmpty(responseString))
            {
                if (response.Content.Headers.ContentType.MediaType.ToLower() == "application/json" && typeof(T) != typeof(string))
                {
                    httpResponse = JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    httpResponse = (T)Convert.ChangeType(responseString, typeof(T));
                }
            }
            else
            {
                httpResponse = default(T);
            }

            return httpResponse;
        }

        public static string ToJSON(this object _obj)
        {
            if (_obj == null)
                return "";

            string stringJson = JsonConvert.SerializeObject(_obj, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateParseHandling = DateParseHandling.DateTime,
                NullValueHandling = NullValueHandling.Ignore
            });
            stringJson = stringJson.Replace("\r\n", "");

            return stringJson;
        }
    }
}
