using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services.Interfaces
{
    public interface IMovieService
    {
        public MovieResponse Get(int id);
        public IEnumerable<MovieResponse> GetAll();
        public void Add(MovieRequest movieRequest);
        public void Update(MovieRequest movieRequest, int id);
        public void Delete(int id);
    }
}
