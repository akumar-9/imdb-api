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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IProducerRepository producerRepository, 
            IActorRepository actorRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _producerRepository = producerRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
        }
        public int Add(MovieRequest movieRequest)
        {
           
          return  _movieRepository.Add(new Movie
            {
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                YearOfRelease = movieRequest.YearOfRelease,
                Poster = movieRequest.Poster,
                ProducerId = movieRequest.ProducerId
            },
                    String.Join(',', movieRequest.ActorIds),
                    String.Join(',', movieRequest.GenreIds)
                );
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.Get(id);
            return new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Poster = movie.Poster,
                Producer = _producerRepository.Get(movie.ProducerId),
                Actors = _actorRepository.GetByMovie(movie.Id).ToList(),
                Genres = _genreRepository.GetByMovie(movie.Id).ToList()
            };
        }

        public IEnumerable<MovieResponse> GetAll()
        {
            var movies = _movieRepository.GetAll();
            return movies.Select(m => new MovieResponse
            {
                Id = m.Id,
                Name = m.Name,
                YearOfRelease= m.YearOfRelease,
                Plot = m.Plot,
                Poster = m.Poster,
                Producer = _producerRepository.Get(m.ProducerId),
                Actors = _actorRepository.GetByMovie(m.Id).ToList(),
                Genres = _genreRepository.GetByMovie(m.Id).ToList()
            });
        }

        public void Update(MovieRequest movieRequest, int id)
        {
            _movieRepository.Update(new Movie
            {   Id= id,
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                YearOfRelease = movieRequest.YearOfRelease,
                Poster = movieRequest.Poster,
                ProducerId = movieRequest.ProducerId
            },
                    String.Join(',', movieRequest.ActorIds),
                    String.Join(',', movieRequest.GenreIds)
                );
        }
    }
}
