//using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace NovaPoshta.API.Messages
{
    public static class Client
    {
        private const string url = @"https://api.novaposhta.ua/v2.0";
        //private const string url = @"http://testapi.novaposhta.ua/v2.0";
        private const string format = "json";
        private const string apiKey = "";

        public static async Task<List<T>> RequestAsync<T>(Request request, RequestType type = RequestType.POST)
        {
            request.apiKey = apiKey;

            var queryString = "";// HttpUtility.ParseQueryString(string.Empty);

            var uri = string.Format(@"{0}/{1}/{2}/{3}?{4}", url, format, request.modelName, request.calledMethod, queryString);

            HttpResponseMessage response;
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(request);
            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes(json)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //if (type == RequestType.POST)
                    response = await client.PostAsync(uri, content);
                //else
                //    response = await client.GetAsync(uri, content);
            }

            var result = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<Response>(result);

            return resp.data.Select(a => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(a))).ToList();
        }
    }
}
