using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetStore.Http.Utilities.Authentication
{
    internal class AuthenticationHelper
    {
        private static string _token = null;

        public async static Task<string> GetToken(string baseUrl)
        {
            if (!string.IsNullOrEmpty(_token))
            {
                return _token;
            }
            var response = await HttpRequestFactory.PostAnonymous(baseUrl, "authentication/token", new { Username = "marc" });
            var content = response.ContentAsType<TokenResponse>();
            _token = content.Token;
            return _token;
        }
    }
}
