namespace WebExamMVC.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class TokenManagementService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        public async Task<string> GetOrRenewTokenAsync(string username, string password)
        {
            var currentToken = httpContextAccessor.HttpContext.Session.GetString("JWTToken");

            if (string.IsNullOrEmpty(currentToken))
            {
                // Token doesn't exist or has expired, retrieve a new one
                currentToken = await AuthenticateAndGetTokenAsync(username, password);
                httpContextAccessor.HttpContext.Session.SetString("JWTToken", currentToken);
            }

            return currentToken;
        }

        private async Task<string> AuthenticateAndGetTokenAsync(string username, string password)
        {
            var formData = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password)
        });

            var response = await httpClient.PostAsync("https://localhost:7160/Login", formData);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadAsStringAsync();
            return tokenResponse;
        }
    }
}
