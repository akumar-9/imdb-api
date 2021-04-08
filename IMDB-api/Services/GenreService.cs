using IMDB_api.Models.DB;
using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using IMDB_api.Repositories.Interfaces;
using IMDB_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public void Add(GenreRequest genreRequest)
        {
            _genreRepository.Add(new Genre
            {
                Name = genreRequest.Name
            });
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        public GenreResponse Get(int id)
        {
           var genre = _genreRepository.Get(id);
            return new GenreResponse
            {   
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public IEnumerable<GenreResponse> GetAll()
        {
            return _genreRepository.GetAll().Select(g => new GenreResponse
            {
                Id = g.Id,
                Name = g.Name
            });
        }

        public void Update(GenreRequest genreRequest, int id)
        {
            _genreRepository.Update(new Genre { 
                Id = id,
                Name = genreRequest.Name });
        }
    }
}
