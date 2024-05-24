using Microsoft.AspNetCore.Mvc;
using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using WebExam.Utils;

namespace WebExam.APIs.Implementations
{
    public class AuthApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/api/Login", Login)
                .Accepts<LoginModel>("application/json")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

        }
        private IResult Login(HttpContext context, IServiceUnitOfWork service, [FromBody] LoginModel login)
        {
            var user = service.UserService.GetByLogin(login.Login);

            if (user == null || user.PasswordHash != login.Password)
                return Results.NotFound();

            var token = JWTHelper.GenerateJwtToken(user.Name, user.Role.ToString());
            return Results.Ok(token);
        }
    }
}
