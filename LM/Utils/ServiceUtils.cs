using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace LM.Utils
{
    public static class ServiceUtils
    {
        public static async Task<string> SendHttpRequestAsync(string serviceUrl, HttpMethod httpMethod, StringContent requestContent, string accessToken = "")
        {
            short attempts = 0;

            while (++attempts <= AppConstants.DefaultTryAttempts)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromMinutes(ConfigUtils.Instance.DefaultTimeOutMinute);
                        using (var request = new HttpRequestMessage(httpMethod, serviceUrl))
                        {
                            request.Content = requestContent;

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                            }

                            var response = httpClient.SendAsync(request).Result;

                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                catch (WebException)
                {
                    Thread.Sleep(AppConstants.DefaultSleepTime);
                }
            }

            return string.Empty;
        }

        public static async Task<string> SendHttpRequestAsync(string serviceUrl, string credential)
        {
            short attempts = 0;

            while (++attempts <= AppConstants.DefaultTryAttempts)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Get, serviceUrl))
                        {
                            request.Headers.Add("Authorization", credential);
                            var response = await httpClient.SendAsync(request);
                            response.EnsureSuccessStatusCode();

                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                catch (HttpRequestException)
                {
                    return string.Empty;
                }
                catch (WebException)
                {
                    Thread.Sleep(AppConstants.DefaultSleepTime);
                }
            }

            return string.Empty;
        }
    }
}
