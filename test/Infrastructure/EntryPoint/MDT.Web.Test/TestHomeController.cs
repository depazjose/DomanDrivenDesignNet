using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MDT.Web.Test
{
    public class TestHomeController
    {
        private HttpClient _client { get; }
        public TestServer Server { get; }
        public TestHomeController()
        {   
            var builder = new WebHostBuilder()            
                            .UseEnvironment("Testing")
                            .UseStartup<TestStartup>();
            
            Server = new TestServer(builder);
                        
            this._client = Server.CreateClient();
         }


        [Fact]
        public async Task GetFood()
        {            
            var response = await _client.GetAsync($"api/Home/GetFood");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            String jsonResponse = await response.Content.ReadAsStringAsync();
            JObject foodResponse = JObject.Parse(jsonResponse);           
            Assert.Equal("Burger", foodResponse["food"] );
        }

        [Fact]
        public async Task GetFoo()
        {            
            var foo="foo";
            var response = await _client.GetAsync($"api/Home/GetFoo?foo={foo}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject fooResponse = JObject.Parse(jsonResponse);           
            Assert.Equal(foo, fooResponse["foo"] );

        }
    }
}
