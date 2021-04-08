using IMDB_api.Models.DB;
using IMDB_api.Models.Requests;
using IMDB_api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using IMDB_api.Models;
using Microsoft.Extensions.Options;

namespace IMDB_api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        ConnectionString _connectionString;
        public MovieRepository(IOptions<ConnectionString> options)
        {
            _connectionString = options.Value;
        }
     
        public void Add(Movie movie, string actorIds, string genreIds)
        {
            const string sql = @"EXEC usp_AddMovie @Name, @Plot, @YearOfRelease, @Poster, @ProducerId, @ActorIds, @GenreIds";           
            using var connection = new SqlConnection(_connectionString.DefaultConnection);                
                var affected = connection.Query(sql, new
                {
                    movie.Name,
                    movie.Plot,
                    movie.YearOfRelease,
                    movie.Poster,
                    movie.ProducerId,
                    ActorIds = actorIds,
                    GenreIds = genreIds
                });
        }

        public void Delete(int id)
        {
            const string sql = @"EXEC usp_DeleteMovie @MovieId";
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            connection.Execute(sql, new { MovieId = id });
        }

        public Movie Get(int id)
        {
            const string sql = @"SELECT * FROM Movies WHERE ID=@Id";
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            return connection.QueryFirst<Movie>(sql, new { Id = id });
        }

        public IEnumerable<Movie> GetAll()
        {
            const string sql = @"SELECT * FROM Movies";
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            return connection.Query<Movie>(sql);
        }

        public void Update(Movie movie, string actorIds, string genreIds)
        {
            const string sql = @"EXEC usp_UpdateMovie @MovieId, @Name, @Plot, @YearOfRelease, @Poster, @ProducerId, @ActorIds, @GenreIds";
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            connection.Execute(sql, new
            {   MovieId=movie.Id,
                movie.Name,
                movie.Plot,
                movie.YearOfRelease,
                movie.Poster,
                movie.ProducerId,
                ActorIds = actorIds,
                GenreIds = genreIds
            });
        }
    }
}
