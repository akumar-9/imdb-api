using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services.Interfaces
{
   public interface IGenreService
    {
        public GenreResponse Get(int id);
        public IEnumerable<GenreResponse> GetAll();
        public int Add(GenreRequest genreRequest);
        public void Delete(int id);
        public void Update(GenreRequest genreRequest, int id);
    }
}
