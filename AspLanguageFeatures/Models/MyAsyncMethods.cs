using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspLanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static async Task<long?> GetPageLength()
        {
            HttpClient httpClient = new HttpClient();

            var httpResponse = await httpClient.GetAsync("http://apress.com");

            return httpResponse.Content.Headers.ContentLength;
        }
    }
}
