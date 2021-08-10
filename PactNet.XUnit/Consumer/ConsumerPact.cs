using System;
using PactNet.Mocks.MockHttpService;

namespace PactNet.XUnit.Consumer
{
    public class ConsumerPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 9224; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }

        public ConsumerPact()
        { 
            PactConfig pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"/Users/joyce/source/repos/DotNet/PactNet.XUnit/pacts",
                LogDir = @"/Users/joyce/source/repos/DotNet/PactNet.XUnit/logs"
            };

            PactBuilder = new PactBuilder(pactConfig);

            PactBuilder
              .ServiceConsumer("Consumer")
              .HasPactWith("clients");

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
   
}
