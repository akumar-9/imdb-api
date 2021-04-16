using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Tests.Mocks
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> mockGenreRepo = new();
        public static void MockGetAll()
        {
            mockGenreRepo.Setup(repo => repo.GetAll()).Returns(new List<Genre> { 
                new Genre 
                {
                    Id = 1,
                    Name = "Biography"
                },
                new Genre
                {
                    Id=2,
                    Name ="Sport"
                } 
            });
        }
        public static void MockGet()
        {
            mockGenreRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Genre
            {
                Id = 1,
                Name = "Biography"
            });
        }

        public static void MockAdd()
        {
            mockGenreRepo.Setup(repo => repo.Add(It.IsAny<Genre>())).Returns(1);
        }
        public static void MockUpdate()
        {
            mockGenreRepo.Setup(repo => repo.Update(It.IsAny<Genre>()));
        }
        public static void MockDelete()
        {
            mockGenreRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
        public static void MockGetByMovie()
        {
            mockGenreRepo.Setup(repo => repo.GetByMovie(It.IsAny<int>())).Returns(new List<Genre> {
                new Genre
                {
                    Id = 1,
                    Name = "Biography"
                },
                new Genre
                {
                    Id=2,
                    Name ="Sport"
                }
            });
        }
    }
}
