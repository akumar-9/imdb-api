CREATE PROCEDURE usp_UpdateMovie(
@MovieId INT,
@Name VARCHAR(100), 
@Plot VARCHAR(100), 
@YearOfRelease INT, 
@Poster NVARCHAR(500),
@ProducerId INT,
@ActorIds VARCHAR(100),
@GenreIds VARCHAR(100) 
)
AS
BEGIN
UPDATE Movies SET Name = @Name, Plot=@Plot, YearOfRelease=@YearOfRelease, Poster=@Poster, ProducerId=@ProducerId WHERE Id = @MovieId
DELETE FROM ActorMovieMapping WHERE MovieId = @MovieId 
INSERT INTO ActorMovieMapping(MovieId, ActorId)
SELECT   @MovieId [MovieId] , [value] [ActorId]
FROM string_split(@ActorIds, ',') 
DELETE FROM MovieGenreMapping WHERE MovieId = @MovieId
INSERT INTO MovieGenreMapping(MovieId, GenreId)
SELECT   @MovieId [MovieId] , [value] [GenreId]
FROM string_split(@GenreIds, ',') 
END
