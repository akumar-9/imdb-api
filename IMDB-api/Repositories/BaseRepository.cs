using Dapper;
using IMDB_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly ConnectionString _connectionString;

        public BaseRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> GetAll(string sql)
        {
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            return connection.Query<T>(sql);
        }

        public void Add(string sql, T entity)
        {
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            connection.Execute(sql, entity);
        }

        public void Delete(string sql, int id)
        {
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            connection.Execute(sql, new { Id = id });
        }
        public T Get(string sql, int id)
        {
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            return connection.QueryFirst<T>(sql, new { Id = id });
        }
        public void Update(string sql, T entity)
        {
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            connection.Execute(sql, entity);
        }
        public IEnumerable<T> GetByMovie(string sql,int movieId)
        {           
            using var connection = new SqlConnection(_connectionString.DefaultConnection);
            return connection.Query<T>(sql,new { MovieId = movieId });
        }
    }
}
