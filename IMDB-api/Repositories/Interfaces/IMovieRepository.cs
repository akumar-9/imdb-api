using IMDB_api.Models.DB;
using IMDB_api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public Movie Get(int id);
        public IEnumerable<Movie> GetAll();
        public void Add(Movie movie, string actorIds, string genreIds);
        public void Update(Movie movie, string actorIds, string genreIds);
        public void Delete(int id);
    }
}
