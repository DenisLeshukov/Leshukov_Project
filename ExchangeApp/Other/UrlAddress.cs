namespace ExchangeApp.Other
{
    public class UrlAddress
    {
        public HttpClient httpClient = new HttpClient();
        public UrlAddress()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7218");
        }
    }
}

