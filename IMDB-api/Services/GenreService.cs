using IMDB_api.Helpers;
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
        public int Add(GenreRequest genreRequest)
        {
           ValidationHelper.ValidateGenre(genreRequest);
           return _genreRepository.Add(new Genre
            {
                Name = genreRequest.Name
            });
        }

        public void Delete(int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre != null)
            {
                _genreRepository.Delete(id);
                return;
            }
            throw new Exception($"Genre with id = {id} doesn't exist");
        }

        public GenreResponse Get(int id)
        {
           var genre = _genreRepository.Get(id);
            if(genre != null)
                return new GenreResponse
                {   
                    Id = genre.Id,
                    Name = genre.Name
                };
            throw new Exception($"Genre with id = {id} doesn't exist");
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
            if (_genreRepository.Get(id) != null)
            {
                ValidationHelper.ValidateGenre(genreRequest);
                _genreRepository.Update(new Genre
                {
                    Id = id,
                    Name = genreRequest.Name
                });
                return;
            }
            throw new Exception($"Genre with id = {id} doesn't exist");
        }
    }
}
