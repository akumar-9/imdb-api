using IMDB.Tests.Mocks;
using IMDB_api;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IMDB.Tests.Steps
{
    [Scope(Feature = "Genre")]
    [Binding]
    public class GenreSteps: BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory) : base(factory.WithWebHostBuilder(builder =>
         {
             builder.ConfigureServices(services =>
           {
               services.AddScoped(service => GenreMock.mockGenreRepo.Object);
           });
 
         }))
        {

        }

        [BeforeScenario]
        public static void MockRepositories()
        {
            GenreMock.MockGetAll();
            GenreMock.MockGet();
            GenreMock.MockAdd();
            GenreMock.MockUpdate();
            GenreMock.MockDelete();
        }
    }
}
