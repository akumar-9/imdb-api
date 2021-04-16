using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Moq;

namespace IMDB.Tests.Mocks
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> actorRepoMock = new();

        public static void MockGetAll()
        {
            actorRepoMock.Setup(repo => repo.GetAll()).Returns(() => { return GetListOfActors(); });
        }

        public static void MockGet()
        {
            actorRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => {
                return new Actor
                {   Id = id,
                    Name = "Christian Bale",
                    Bio = "British",
                    DOB = new DateTime(1979, 03, 02),
                    Sex = "Male"
                };
            });
        }

        public static void MockAdd()
        {
            actorRepoMock.Setup(repo => repo.Add(It.IsAny<Actor>())).Returns(1);
        }

        public static void MockUpdate()
        {
            actorRepoMock.Setup(repo => repo.Update(It.IsAny<Actor>()));
        }

        public static void MockDelete()
        {
            actorRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

        public static void MockGetByMovie()
        {
            actorRepoMock.Setup(repo => repo.GetByMovie(It.IsAny<int>())).Returns(new List<Actor> {
                new Actor{
                    Id = 1,
                    Name = "Christian Bale",
                    Bio ="British",
                    DOB =new DateTime(1979,03,02),
                    Sex = "Male"
                },
                new Actor
                {
                    Id = 2,
                    Name = "Matt Damon",
                    Bio = "American",
                    DOB = new DateTime(1970,10,08),
                    Sex = "Male"
                }
            });
            }
        private static IEnumerable<Actor> GetListOfActors()
        {
            return new List<Actor>()
            {
                new Actor()
                {
                    Id = 1,
                    Name = "Christian Bale",
                    Bio ="British",
                    DOB =new DateTime(1979,03,02),
                    Sex = "Male"
                },
                new Actor()
                {
                    Id = 2,
                    Name = "Mila Kunis",
                    Bio ="Ukranian",
                    DOB =new DateTime(1973,06,22),
                    Sex = "Female"
                }
            };
        }
    }
}
