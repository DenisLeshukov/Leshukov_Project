namespace ExchangeApp.Other
{
    public class UrlAddress
    {
        public HttpClient httpClient = new HttpClient();
        public UrlAddress()
        {
            httpClient.BaseAddress = new Uri("https://0heax9-93-152-213-57.a.2na.am/");
        }
    }
}

