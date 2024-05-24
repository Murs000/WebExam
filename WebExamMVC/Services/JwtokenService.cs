using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebExamMVC.Services
{
    public class JwtTokenService(IHttpContextAccessor httpContextAccessor)
    {
        public void StoreToken(string token)
        {
            httpContextAccessor.HttpContext.Session.SetString("JwtToken", token);
        }

        public string GetToken()
        {
            return httpContextAccessor.HttpContext.Session.GetString("JwtToken");
        }
        public string GetRole()
        {
            var token = httpContextAccessor.HttpContext.Session.GetString("JwtToken");
            if (token == null)
            {
                return "none";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("9NlCOGZ79ANvHktNCIcJrZVGpPaX6wFT");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            var role = principal.FindFirst(ClaimTypes.Role)?.Value;
            if (role == null)
                role = "None";
            return role;
        }
    }
}
