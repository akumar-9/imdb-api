Feature: Genre

@GetAllGenres
Scenario: Get all genres
Given I am a client
When I make a GET Request '/genres'
Then The status code is '200'
And The data in the response should look like this '[{"id":1,"name":"Biography"},{"id":2,"name":"Sport"}]'

@GetGenreById
Scenario: Get genre by Id
Given I am a client
When I make a GET Request '/genres/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1,"name":"Biography"}'

@AddGenre
Scenario: Add a genre
Given I am a client
When I make a POST Request to '/genres' with the following data '{"name":"Biography"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@UpdateGenre
Scenario: Update a genre
Given I am a client
When I make a PUT Request to '/genres/1' with the following data '{"name":"Sport"}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@DelteGenre
Scenario: Delete a genre
Given I am a client
When I make a DELETE Request to '/genres/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'


