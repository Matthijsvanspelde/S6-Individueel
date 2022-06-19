using AuthenticationService.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AuthenticatieSerivce.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public async Task GivenMissingAuthorization_ThenUnauthorized()
        {
            using var application = new WebApplicationFactory<AuthenticationService.Startup>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/api/test");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        [Fact]
        public async Task GivenInvalidInput_ThenBadRequest()
        {
            using var application = new WebApplicationFactory<AuthenticationService.Startup>();
            using var client = application.CreateClient();

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", "Pa55w0rd!"),
                new KeyValuePair<string, string>("email", "JohnDoe@example.com")
            });

            var response = await client.PostAsync("/api/authentication/register", formContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GivenInvalidPassword_ThenInternalServerError()
        {
            using var application = new WebApplicationFactory<AuthenticationService.Startup>();
            using var client = application.CreateClient();

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "John Doe"),
                new KeyValuePair<string, string>("password", "TeSimpel"),
                new KeyValuePair<string, string>("email", "JohnDoe@example.com")
            });

            var response = await client.PostAsync("/api/authentication/register", formContent);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
