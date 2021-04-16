using IMDB_api.Models;
using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionString> options):base(options.Value)
        {

        }
        public int Add(Genre genre)
        {
            const string sql = @"INSERT INTO Genres(Name) VALUES(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
            return Add(sql, genre);
        }

        public void Delete(int id)
        {
            const string sql = @"DELETE FROM Genres WHERE Id = @Id";
            Delete(sql, id);
        }

        public Genre Get(int id)
        {
            const string sql = @"SELECT * FROM Genres WHERE Id = @Id";
            return Get(sql, id);
        }

        public IEnumerable<Genre> GetAll()
        {
            const string sql = @"SELECT * FROM Genres";
            return GetAll(sql);
        }

        public IEnumerable<Genre> GetByMovie(int movieId)
        {
            const string sql = @"SELECT G.* FROM Genres G JOIN MovieGenreMapping MG ON G.Id = MG.GenreId WHERE MG.MovieId = @MovieId";
            return GetByMovie(sql, movieId);
        }

        public void Update(Genre genre)
        {
            const string sql = @"UPDATE Genres SET Name=@Name WHERE Id=@Id";
            Update(sql, genre);
            
        }
    }
}
