using System;
using System.Collections.Generic;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using PactNet.XUnit.Consumer;
using PactNet.XUnit.Mock;
using Xunit;

namespace PactNet.XUnit
{
    public class ConsumerTests : IClassFixture<ConsumerPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerTests(ConsumerPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        [Fact]
        public void GetClients_VerifyClientExists()
        {
            //Arrange
            _mockProviderService
              .Given("Client Details for id '1'")
              .UponReceiving("A GET request to retrieve client details")
              .With(new ProviderServiceRequest
              {
                  Method = HttpVerb.Get,
                  Path = "/clients/1",
                  Headers = new Dictionary<string, object>
                  {
                    { "Accept", "application/json" }
                  }
              })
              .WillRespondWith(new ProviderServiceResponse
              {
                  Status = 200,
                  Headers = new Dictionary<string, object>
                  {
                    { "Content-Type", "application/json; charset=utf-8" }
                  },
                  Body = new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
                  {
                      firstName = "Lisa",
                      lastName = "Simpson",
                      age = 8,
                      id = 1
                  }
              }); //NOTE: WillRespondWith call must come last as it will register the interaction

            var consumer = new MockClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetClient("1");

            //Assert
            Assert.Equal(1, result.Id);
          
            _mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called at least once
        }
    }
}
