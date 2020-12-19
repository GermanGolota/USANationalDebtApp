using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DataAccessLibrary.Data.API
{
    public class APIClient : IAPIClient
    {
        private HttpClient client;
        public APIClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var header = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(header);
        }
        public HttpClient Client
        {
            get
            {
                return this.client;
            }
        }
    }
}
