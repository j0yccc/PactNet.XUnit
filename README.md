# PactNet.XUnit

/Consumer/ConsumerPact
- Pact config setup
/Mock/MockClient
- Hitting localhost http://localhost:8081/clients/1 with response returned: {"firstName":"Lisa","lastName":"Simpson","age":8,"id":1}
/Tests/ConsumerTests
- Run ConsumerTest to generate contract in pacts folder
/Tests/ProviderTests
- Run ProviderTests to verify the contract in pacts folder vs API
/pacts/consumer-clients.json
- contract generated
/logs/clients_mock_service.log
- log file

Tests Results:
![image](https://user-images.githubusercontent.com/31697022/128877033-1100c72c-ba4e-42ec-9f0c-54614c9e27ad.png)
