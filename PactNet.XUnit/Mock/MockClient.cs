using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PactNet.XUnit.Mock
{
    public class MockClient
    {
        private readonly HttpClient _client;

        public MockClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:8081") };
        }

        public async Task<AsyncCallback> GetClient(string id)
        {
            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/clients/" + id);
            request.Headers.Add("Accept", "application/json");

            var response = await _client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var status = response.StatusCode;

            reasonPhrase = response.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<AsyncCallback>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);
        }
    }
}
