using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Moq;

namespace IMDB.Tests.Mocks
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> mockProducerRepo = new();
        public static void MockGetAll()
        {
            mockProducerRepo.Setup(repo => repo.GetAll()).Returns(() => { return GetListOfProducers(); });
        }

        public static void MockGet()
        {
            mockProducerRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => new Producer
            {
                Id = id,
                Name = "James Mangold",
                Bio = "American",
                DOB = new DateTime(1963, 12, 16),
                Sex = "Male"
            });
        }
        public static void MockAdd()
        {
            mockProducerRepo.Setup(repo => repo.Add(It.IsAny<Producer>())).Returns(1);
        }
        public static void MockUpdate()
        {
            mockProducerRepo.Setup(repo => repo.Update(It.IsAny<Producer>()));
        }
        public static void MockDelete()
        {
            mockProducerRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
        private static List<Producer> GetListOfProducers()
        {
            return new List<Producer>()
            {
                new Producer
                {
                    Id = 1,
                    Name = "James Mangold",
                    Bio = "American",
                    DOB = new DateTime(1963,12,16),
                    Sex = "Male"
                },
                new Producer
                {
                    Id = 2,
                    Name ="Chris Morgan",
                    Bio ="American",
                    DOB = new DateTime(1966,11,24),
                    Sex = "Male"
                }
            };
        }
    }
}
