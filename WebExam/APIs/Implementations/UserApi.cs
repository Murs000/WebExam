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
                .Produces<List<UserModel>>(StatusCodes.Status200OK)
                .WithName("GetAllUsers")
                .WithTags("Getters");
            //.RequireAuthorization("Admin");

            app.MapGet("/Users/{id}", GetById)
                .Produces<UserModel>(StatusCodes.Status200OK)
                .WithName("GetUser")
                .WithTags("Getters");
                //.RequireAuthorization("Admin");

            app.MapPost("/Users", Post)
                .Accepts<UserModel>("application/json")
                .Produces<UserModel>(StatusCodes.Status201Created)
                .WithName("CreateUser")
                .WithTags("Creators");
                //.RequireAuthorization("Admin");

            app.MapPut("/Users", Put)
                .Accepts<UserModel>("application/json")
                .WithName("UpdateUser")
                .WithTags("Updaters");
                //.RequireAuthorization("Admin");

            app.MapDelete("Users/{id}", Delete)
                .WithName("DeleteUser")
                .WithTags("Deleters");
                //.RequireAuthorization("Admin");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.UserService.Get() is List<UserModel> user
            ? Results.Ok(user)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.UserService.Get(id) is UserModel user
            ? Results.Ok(user)
            : Results.NotFound();

        private IResult Post([FromBody] UserModel user, IServiceUnitOfWork service)
        {
            service.UserService.Insert(user);
            return Results.Created($"/Users/{user.Id}", user);
        }

        private IResult Put([FromBody] UserModel user, IServiceUnitOfWork service)
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
