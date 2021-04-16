CREATE PROCEDURE usp_DeleteMovie( @MovieId INT)
AS
BEGIN
DELETE FROM ActorMovieMapping WHERE MovieId = @MovieId 
DELETE FROM MovieGenreMapping WHERE MovieId = @MovieId
DELETE FROM Movies WHERE ID = @MovieId
END
