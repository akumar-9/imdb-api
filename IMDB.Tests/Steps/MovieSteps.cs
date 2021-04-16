using IMDB_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IMDB.Tests.Mocks;
using TechTalk.SpecFlow;

namespace IMDB.Tests.Steps
{
    [Scope(Feature = "Movie")]
    [Binding]
    public class MovieSteps: BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory) : base(factory.WithWebHostBuilder(builder => 
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(service => MovieMock.movieRepoMock.Object);
                services.AddScoped(service => ProducerMock.mockProducerRepo.Object);
                services.AddScoped(service => GenreMock.mockGenreRepo.Object);
                services.AddScoped(service => ActorMock.actorRepoMock.Object);
                
            });
        }))
        {

        }
        [BeforeScenario]
        public void Repositories()
        {
            ActorMock.MockGetByMovie();
            ProducerMock.MockGet();
            GenreMock.MockGetByMovie();
            MovieMock.MockGetAll();
            MovieMock.MockGet();
            MovieMock.MockAdd();
            MovieMock.MockUpdate();
            MovieMock.MockDelete();
        }
    }
}
    