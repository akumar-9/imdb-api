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
    [Scope(Feature = "Actor")]
    [Binding]
    public class ActorSteps: BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory): base(factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(service => ActorMock.actorRepoMock.Object);
            });
        })) 
        {

        }
        [BeforeScenario]
        public void MockRepositories()
        {
            ActorMock.MockGetAll();
            ActorMock.MockGet();
            ActorMock.MockAdd();
            ActorMock.MockUpdate();
        }

    }
}
