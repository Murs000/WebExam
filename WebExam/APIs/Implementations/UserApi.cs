using Microsoft.AspNetCore.Mvc;
using WebExam.APIs.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.APIs.Implementations
{
    public class UserApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Users", Get)
                .Produces<List<User>>(StatusCodes.Status200OK)
                .WithName("GetAllUsers")
                .WithTags("Getters")
                .RequireAuthorization("AdminOnly");

            app.MapGet("/Users/{id}", GetById)
                .Produces<User>(StatusCodes.Status200OK)
                .WithName("GetUser")
                .WithTags("Getters")
                .RequireAuthorization("AdminOnly");

            app.MapPost("/Users", Post)
                .Accepts<User>("application/json")
                .Produces<User>(StatusCodes.Status201Created)
                .WithName("CreateUser")
                .WithTags("Creators");
                //.RequireAuthorization("AdminOnly");

            app.MapPut("/Users", Put)
                .Accepts<User>("application/json")
                .WithName("UpdateUser")
                .WithTags("Updaters")
                .RequireAuthorization("AdminOnly");

            app.MapDelete("Users/{id}", Delete)
                .WithName("DeleteUser")
                .WithTags("Deleters")
                .RequireAuthorization("AdminOnly");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.UserService.Get() is List<User> user
            ? Results.Ok(user)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.UserService.Get(id) is User user
            ? Results.Ok(user)
            : Results.NotFound();

        private IResult Post([FromBody] User user, IServiceUnitOfWork service)
        {
            service.UserService.Insert(user);
            return Results.Created($"/Users/{user.Id}", user);
        }

        private IResult Put([FromBody] User user, IServiceUnitOfWork service)
        {
            service.UserService.Update(user);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.UserService.Delete(id);
            return Results.NoContent();
        }
    }
}
