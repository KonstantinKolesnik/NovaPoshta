namespace NovaPoshta.API.Messages
{
    public class Response
    {
        public bool success { get; set; }
        public object[] data { get; set; }
        public string[] errors { get; set; }
        public string[] warnings { get; set; }
        public string[] info { get; set; }
    }
}
