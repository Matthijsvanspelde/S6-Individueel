using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AuthenticatieSerivce.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public async Task GET_returns_Unauthorized()
        {
            using var application = new WebApplicationFactory<AuthenticationService.Startup>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/api/test");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
