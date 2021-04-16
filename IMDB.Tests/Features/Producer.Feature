Feature: Producer

@GetAllProducer
Scenario: Get all producer
Given I am a client
When I make a GET Request '/producers'
Then The status code is '200'
And The data in the response should look like this '[{"id":1,"name":"James Mangold","bio":"American","dob":"1963-12-16T00:00:00","sex":"Male"},{"id":2,"name":"Chris Morgan","bio":"American","dob":"1966-11-24T00:00:00","sex":"Male"}]'

@GetProducerById
Scenario: Get producer by id
Given I am a client
When I make a GET Request '/producers/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1,"name":"James Mangold","bio":"American","dob":"1963-12-16T00:00:00","sex":"Male"}'

@AddAProducer
Scenario: Add a producer
Given I am a client
When I make a PUT Request to '/producers/1' with the following data '{"name":"James Mangold","bio":"American","dob":"1963-12-16T00:00:00","sex":"Male"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@UpdateAProducer
Scenario: Update a producer
Given I am a client
When I make a PUT Request to '/producers/1' with the following data '{"name":"James Mangold","bio":"American producer and actor","dob":"1963-12-16T00:00:00","sex":"Male"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@DeleteAProducer
Scenario: Delete a producer
Given I am a client
When I make a DELETE Request to '/producers/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'



