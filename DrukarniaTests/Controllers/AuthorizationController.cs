using DrukarniaTests.Constants;
using DrukarniaTests.Helpers;
using System.Text.Json;
using System.Net;

namespace DrukarniaTests.Controllers
{
    internal class AuthorizationController
    {
        ApiRequestHelper apiRequestHelper = new ApiRequestHelper(BaseConstants.BaseURL);

        public class dsadasd
        {

        }

        public async Task<string> GetValidToken()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Connection", "keep-alive" }
            };

            var body = @"{""email"":""ronpo.amx.st@gmail.com"",""password"":""fAscvuvkdp7339$#_""}";

            var request = await apiRequestHelper.PostAsync("api/users/login", body, headers);
            //var response = request.Content.ReadAsStringAsync();
            IEnumerable<Cookie> responseCookies = apiRequestHelper.cookies.GetAllCookies();
            var authorizeToken = responseCookies.FirstOrDefault(x => x.Name == "token");
            return authorizeToken.Value.ToString();
        }
    }
}
