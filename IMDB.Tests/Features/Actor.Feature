Feature: Actor 

@GetAllActors
Scenario: Get all actors
Given I am a client
When I make a GET Request '/actors'
Then The status code is '200'
And The data in the response should look like this '[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","sex":"Male"},{"id":2,"name":"Mila Kunis","bio":"Ukranian","dob":"1973-06-22T00:00:00","sex":"Female"}]'

@GetActorById
Scenario: Get actor by Id
Given I am a client
When I make a GET Request '/actors/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","sex":"Male"}'


@AddAnActor
Scenario: Add an actor
Given I am a client
When I make a POST Request to '/actors' with the following data '{"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","sex":"Male"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@UpdateAnActor
Scenario: Update an actor
Given I am a client
When I make a PUT Request to '/actors/1' with the following data '{"name":"Christian Bale","bio":"British and American","dob":"1979-03-02T00:00:00","sex":"Male"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@DeleteAnActor
Scenario: Delete an actor
Given I am a client
When I make a DELETE Request to '/actors/1' 
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

