using System.Net.Http;
using Xunit;

namespace PactNet.XUnit
{
    public class PulisherTests
    {

        private static string PactFilePath = @"/Users/<user>/source/repos/DotNet/PactNet.XUnit/pacts/consumer-clients.json";
        private const string ConsumerVersion = "1.0.1";
        private const string BrokerBaseUriHttp = "https://pact-broker";
        private static readonly PactUriOptions AuthOptions = new PactUriOptions().SetBearerAuthentication("token");

        private PactPublisher GetSubject(string brokerBaseUri, PactUriOptions brokerUriOptions = null)
        {

            return new PactPublisher(brokerBaseUri, brokerUriOptions);
        }
      

        [Fact]
        public void PublishToBrokerWithAuthentication()
        {
            var pactPublisher = GetSubject(BrokerBaseUriHttp, AuthOptions);

            pactPublisher.PublishToBroker(PactFilePath, ConsumerVersion);
        }
    }
}
