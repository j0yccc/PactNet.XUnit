using System;
using System.Collections.Generic;
using PactNet.Infrastructure.Outputters;
using PactNet.XUnit.Tests.ProviderTests;
using Xunit;
using Xunit.Abstractions;

namespace PactNet.XUnit
{
    public class ProviderTests
    {
        private readonly ITestOutputHelper _output;

        public ProviderTests(ITestOutputHelper output)
        {
            _output = output;
        }

       
        [Fact]
        public void TestProvider()
        {
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput> //NOTE: We default to using a ConsoleOutput, however xUnit 2 does not capture the console output, so a custom outputter is required.
                {
                    new XUnitOutput(_output)
                },
             
                Verbose = true //Output verbose verification logs to the test output
            };

            new PactVerifier(config)
                .ServiceProvider("clients", "http://localhost:8081")
                .HonoursPactWith("Consumer")
                .PactUri(@"/Users/joyce/source/repos/DotNet/PactNet.XUnit/pacts/consumer-clients.json")
                .Verify();
        }
    }
}
