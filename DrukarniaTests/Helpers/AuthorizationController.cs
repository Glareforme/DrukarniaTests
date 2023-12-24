using DrukarniaTests.Constants;
using System.Net;

namespace DrukarniaTests.Helpers
{
    internal class AuthorizationController
    {
        ApiRequestHelper apiRequestHelper = new ApiRequestHelper(BaseConstants.BaseURL);
        AuthorizationController controller = new AuthorizationController();

        private async Task<Cookie> GetValidToken(string email, string password)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Connection", "keep-alive" },
                {"User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36" },
            };
            var body = $"{{\"email\":\"{email}\",\"password\":\"{password}\"}}";
            var request = await apiRequestHelper.PostAsync("api/users/login", body, headers);
            IEnumerable<Cookie> responseCookies = apiRequestHelper.cookies.GetAllCookies();
            return responseCookies.FirstOrDefault(x => x.Name == "token");
        }

        public async Task LoginWithApi(string login, string password)
        {
            var cookies = await controller.GetValidToken(login, password);
            BrowserHelper.SetCookie(new OpenQA.Selenium.Cookie(cookies.Name, cookies.Value));
        }
    }
}
