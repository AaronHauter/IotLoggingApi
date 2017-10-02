using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;

namespace Gentex.MES.IotLoggingApi.Contracts.Clients
{
    public class Http_Client : IHttpClient
    {
        string _version;
        string _baseUrl;
        public Http_Client(string endpoint)
        {
            //Verify that the incoming endpoint is a valid endpoint
            if (!(endpoint == StandardEndpoints.QaEndpoint || endpoint == StandardEndpoints.DevEndpoint || endpoint == StandardEndpoints.ProdEndpoint))
            {
                throw new Exception("Not a valid endpoint.");
            }

            _version = "v1/";
            _baseUrl = string.Concat(endpoint, _version);
        }

        private HttpClient getHttpClient(int timeoutSeconds = 15)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.Timeout = new TimeSpan(0, 0, timeoutSeconds);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        private static readonly HttpClient client = new HttpClient();
        private HttpClient postHttpClient(int timeoutSeconds = 15)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.Timeout = new TimeSpan(0, 0, timeoutSeconds);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
