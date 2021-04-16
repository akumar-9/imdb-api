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
    [Scope(Feature = "Producer")]
    [Binding]
    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory): base(factory.WithWebHostBuilder(builder=>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(service => ProducerMock.mockProducerRepo.Object);
            });
        }))
        {
               
        }
        [BeforeScenario]
        public void Repositories()
        {
            ProducerMock.MockGetAll();
            ProducerMock.MockGet();
            ProducerMock.MockAdd();
            ProducerMock.MockUpdate();
            ProducerMock.MockDelete();
        }
    }
}
