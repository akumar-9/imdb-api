using Dapper;
using IMDB_api.Models;
using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories
{
    public class ActorRepository : BaseRepository<Actor> , IActorRepository
    {
        public ActorRepository(IOptions<ConnectionString> connectionString)
          : base(connectionString.Value)
        {

        }
        public void Add(Actor actor)
        {
           const string sql = @"INSERT INTO Actors(Name,DOB,Sex,Bio) VALUES(@Name,@DOB,@Sex,@Bio)";
           Add(sql, actor);
            
        }

        public void Delete(int id)
        {
            const string sql = @"DELETE FROM Actors WHERE Id = @id";
            Delete(sql, id);
        }

        public Actor Get(int id)
        {
            const string sql = @"SELECT * FROM Actors WHERE Id = @id";
            return Get(sql, id);
        }

        public IEnumerable<Actor> GetAll()
        {
            const string sql = @"SELECT * FROM Actors";
            return GetAll(sql);
        }

        public void Update(Actor actor)
        {
            const string sql = @"UPDATE Actors SET Name = @Name, DOB = @DOB, Sex = @Sex, Bio = @Bio WHERE Id = @Id";
            Update(sql, actor);
        }

        public IEnumerable<Actor> GetByMovie(int movieId)
        {
            const string sql = @"SELECT A.* FROM Actors A JOIN ActorMovieMapping AM ON A.Id = AM.ActorId WHERE AM.MovieId = @MovieId";
            return GetByMovie(sql, movieId);
        }
    }
}
