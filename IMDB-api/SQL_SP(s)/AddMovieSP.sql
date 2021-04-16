CREATE PROCEDURE usp_AddMovie (

@Name VARCHAR(100), 
@Plot VARCHAR(100), 
@YearOfRelease INT, 
@Poster NVARCHAR(500),
@ProducerId INT,
@ActorIds VARCHAR(100),
@GenreIds VARCHAR(100)) 
AS
DECLARE @MovieId INT
BEGIN
INSERT INTO Movies(Name,Plot,YearOfRelease,Poster,ProducerId) Values(@Name, @Plot, @YearOfRelease, @Poster, @ProducerId)
SET @MovieId = SCOPE_IDENTITY()
INSERT INTO ActorMovieMapping(MovieId, ActorId)
SELECT   @MovieId [MovieId] , [value] [ActorId]
FROM string_split(@ActorIds, ',') 
INSERT INTO MovieGenreMapping(MovieId, GenreId)
SELECT   @MovieId [MovieId] , [value] [GenreId]
FROM string_split(@GenreIds, ',') 
END
