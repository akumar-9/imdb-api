Feature: Movie

@GetAllMovies
Scenario: Get all movies
Given I am a client
When I make a GET Request '/movies'
Then The status code is '200'
And The data in the response should look like this '[{"id":1,"name":"Ford v Ferrari","yearOfRelease":2019,"plot":"American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws","poster":"poster-url","producer":{"id":1,"name":"James Mangold","bio":"American","dob":"1963-12-16T00:00:00","sex":"Male"},"actors":[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","sex":"Male"},{"id":2,"name":"Matt Damon","bio":"American","dob":"1970-10-08T00:00:00","sex":"Male"}],"genres":[{"id":1,"name":"Biography"},{"id":2,"name":"Sport"}]}]'


@GetMovieById
Scenario: Get a movie by id
Given I am a client
When I make a GET Request '/movies/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1,"name":"Ford v Ferrari","yearOfRelease":2019,"plot":"American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws","poster":"poster-url","producer":{"id":1,"name":"James Mangold","bio":"American","dob":"1963-12-16T00:00:00","sex":"Male"},"actors":[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","sex":"Male"},{"id":2,"name":"Matt Damon","bio":"American","dob":"1970-10-08T00:00:00","sex":"Male"}],"genres":[{"id":1,"name":"Biography"},{"id":2,"name":"Sport"}]}'


@AddMovie
Scenario: Add a movie
Given I am a client
When I make a POST Request to '/movies' with the following data '{"name":"Ford v Ferrari","yearOfRelease":2019,"plot":"American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws","poster":"poster-url","producerId":1,"actorIds":[1,2],"genreIds":[1,2]}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@UpdateMovie
Scenario: Update a movie
Given I am a client
When I make a PUT Request to '/movies/1' with the following data '{"name":"Ford v Ferrari","yearOfRelease":2019,"plot":" '66 Le Mans","poster":"poster-url","producerId":1,"actorIds":[1,2],"genreIds":[1,2]}'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'

@DeleteMovie
Scenario: Delete a movie
Given I am a client
When I make a DELETE Request to '/movies/1'
Then The status code is '200'
And The data in the response should look like this '{"id":1}'