using WebExam.APIs.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebExam.APIs.Implementations
{
    public class ChoiseApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Choises", Get)
                .Produces<List<Choise>>(StatusCodes.Status200OK)
                .WithName("GetAllChoises")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapGet("/Choises/{id}", GetById)
                .Produces<Choise>(StatusCodes.Status200OK)
                .WithName("GetChoise")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapPost("/Choises", Post)
                .Accepts<Choise>("application/json")
                .Produces<Choise>(StatusCodes.Status201Created)
                .WithName("CreateChoise")
                .WithTags("Creators")
                .RequireAuthorization("Stuff");

            app.MapPut("/Choises", Put)
                .Accepts<Choise>("application/json")
                .WithName("UpdateChoise")
                .WithTags("Updaters")
                .RequireAuthorization("Stuff");

            app.MapDelete("Choises/{id}", Delete)
                .WithName("DeleteChoise")
                .WithTags("Deleters")
                .RequireAuthorization("Stuff");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.ChoiseService.Get() is List<Choise> choises
            ? Results.Ok(choises)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.ChoiseService.Get(id) is Choise choise
            ? Results.Ok(choise)
            : Results.NotFound();

        private IResult Post([FromBody] Choise choise, IServiceUnitOfWork service)
        {
            service.ChoiseService.Insert(choise);
            return Results.Created($"/Choises/{choise.Id}", choise);
        }

        private IResult Put([FromBody] Choise choise, IServiceUnitOfWork service)
        {
            service.ChoiseService.Update(choise);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.ChoiseService.Delete(id);
            return Results.NoContent();
        }
    }
}
