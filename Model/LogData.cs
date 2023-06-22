namespace.LoggerCode.Model
{

    public class GetLogData
    {
        public DateTime timeStamp { get; set; }

        public string host { get; set; }

        public string source { get; set; }

        public string correlationId { get; set; }

        public string code { get; set; }

        public string message { get; set; }

        public string http { get; set; }

        public string trace { get; set; }

        public List<string> data { get; set; }
    }
}