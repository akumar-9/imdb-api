    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB_api.Models.DB;
using IMDB_api.Models.Responses;
using IMDB_api.Repositories.Interfaces;
using Moq;

namespace IMDB.Tests.Mocks
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> movieRepoMock = new();
        public static void MockGetAll()
        {
            movieRepoMock.Setup(repo => repo.GetAll()).Returns(() => { return GetListOfMovies(); });
        }
        private static List<Movie> GetListOfMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Ford v Ferrari",
                    YearOfRelease = 2019,
                    Plot = "American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws",
                    Poster="poster-url",
                    ProducerId = 1
                }   
            };
        }

        public  static void MockGet()
        {
            movieRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => GetListOfMovies().First(x => x.Id == id) );
            //movieRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => new Movie { 
            //Id=id,
            //Name = "Ford v Ferrari",
            //YearOfRelease = 2019,
            //Plot = "American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws",
            //Poster = "poster-url",
            //ProducerId = 1
            //});
        }

        public static void MockAdd()
        {
            movieRepoMock.Setup(repo => repo.Add(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>())).Returns(1);
        }

        public static void MockUpdate()
        {
            movieRepoMock.Setup(repo => repo.Update(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        public static void MockDelete()
        {
            movieRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
