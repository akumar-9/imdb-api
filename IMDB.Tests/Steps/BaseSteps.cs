using IMDB_api;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IMDB.Tests.Steps
{
    public class BaseSteps
    {
        protected HttpClient Client;
        protected   WebApplicationFactory<TestStartup> baseFactory;
        protected HttpResponseMessage message;

        public BaseSteps(WebApplicationFactory<TestStartup> baseFactory)
        {
            this.baseFactory = baseFactory;
        }

        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            Client = baseFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            });
        }

        [When(@"I make a GET Request '(.*)'")]
        public async Task WhenIMakeAGETRequest(string endPoint)
        {
            var uri = new Uri(endPoint, UriKind.Relative);  
            message = await Client.GetAsync(uri);
        }

        [When(@"I make a POST Request to '(.*)' with the following data '(.*)'")]
        public async Task WhenIMakeAPOSTRequestToWithTheFollowingData(string endPoint, string postData)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            message = await Client.PostAsync(uri, content);
        }

        [When(@"I make a PUT Request to '(.*)' with the following data '(.*)'")]
        public async Task WhenIMakeAPUTRequestToWithTheFollowingData(string endPoint, string putData)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            var content = new StringContent(putData, Encoding.UTF8, "application/json");
            message = await Client.PutAsync(uri, content);
        }

        [When(@"I make a DELETE Request to '(.*)'")]
        public async Task WhenIMakeADELETERequestTo(string endPoint)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            message = await Client.DeleteAsync(uri);
        }

        [Then(@"The status code is '(.*)'")]
        public void ThenTheStatusCodeIs(int excpectedCode)
        {
            Assert.Equal((HttpStatusCode)excpectedCode, message.StatusCode);
        }


        [Then(@"The data in the response should look like this '(.*)'")]
        public async Task ThenTheDataInTheResponseShouldLookLikeThis(string expectedData)
        {
            var responseData = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.Equal(responseData, expectedData);
        }

    }
}
