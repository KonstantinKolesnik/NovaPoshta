//using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace NovaPoshta.API.Messages
{
    public class Client
    {
        private const string url = @"https://api.novaposhta.ua/v2.0";
        //private const string url = @"http://testapi.novaposhta.ua/v2.0";
        private const string format = "json";

        public string APIKey
        {
            get; private set;
        }

        public Client(string apiKey)
        {
            APIKey = apiKey;
        }

        public async void Request(Request request, string body)
        {
            request.apiKey = APIKey;

            var client = new HttpClient();
            var queryString = "";// HttpUtility.ParseQueryString(string.Empty);


            var uri = string.Format(@"{0}/{1}/{2}/{3}?{4}", url, format, request.modelName, request.calledMethod, queryString);

            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(request);
            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes(json)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

        }
    }
}
