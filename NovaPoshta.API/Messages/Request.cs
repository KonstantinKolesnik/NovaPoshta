namespace NovaPoshta.API.Messages
{
    public class Request
    {
        public string apiKey { get; set; }
        public string modelName { get; set; }
        public string calledMethod { get; set; }
        public dynamic methodProperties { get; set; }
    }
}
