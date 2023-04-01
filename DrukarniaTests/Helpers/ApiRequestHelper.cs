﻿using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace DrukarniaTests.Helpers
{
    public class ApiRequestHelper
    {
        public CookieContainer cookies = new CookieContainer();
        HttpClientHandler handler = new HttpClientHandler();

        protected string _url;
        protected HttpClient client => new HttpClient(handler);

        public ApiRequestHelper(string url)
        {
            _url = url;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, string body, Dictionary<string, string> headers = null)
        {
            handler.CookieContainer = cookies;
            using (var request = new HttpRequestMessage(HttpMethod.Post, _url + endpoint))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                request.Content = content;

                var response = await this.client.SendAsync(request);
                return response;
            }
        }
    }
}
