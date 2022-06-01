using AuthenticationService.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AuthenticatieSerivce.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GivenMissingAuthorization_ThenUnauthorized()
        {
            var controller = new TestController();




            var response = await HttpRequestFactory.PostAnonymous(_clientApiUrl, _checkoutResourceUrlSegment, new { postalCode = "K1A 0A4" });

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }
    }
}
