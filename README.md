# PactNet.XUnit

Setup steps:

- Clone the repo.
- Open the solution in VS.
- Build the project.
- Tests will appear in Test explorer.
- Run the tests in Test Explorer.
- Test results pass/fail will be displayed.
- Pact Broker results will be displayed.

Folder structures:

- /Consumer/ConsumerPact: Pact config setup
- /Mock/MockClient: Hitting localhost API http://localhost:8081/clients/1 with simple response returned: {"firstName":"Lisa","lastName":"Simpson","age":8,"id":1}
- /Tests/ConsumerTests: Run ConsumerTest to generate contract in pacts folder
- /Tests/ProviderTests: Run ProviderTests to verify the contract via pact broker vs API
- /Tests/PublisherTests: Action to publish contract to pact broker
- /pacts/consumer-clients.json: contract generated
- /logs/clients_mock_service.log: log file

Tests Results:

![image](https://user-images.githubusercontent.com/31697022/129194344-e8b6f088-b5d2-473a-a06b-732ceb806e65.png)

Pact Broker Results:

![image](https://user-images.githubusercontent.com/31697022/129194536-70682030-7dbb-41d4-9f33-667170c923c7.png)

