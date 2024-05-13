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
                .Produces<List<ChoiseModel>>(StatusCodes.Status200OK)
                .WithName("GetAllChoises")
                .WithTags("Getters");

            app.MapGet("/Choises/{id}", GetById)
                .Produces<ChoiseModel>(StatusCodes.Status200OK)
                .WithName("GetChoise")
                .WithTags("Getters");

            app.MapPost("/Choises", Post)
                .Accepts<ChoiseModel>("application/json")
                .Produces<ChoiseModel>(StatusCodes.Status201Created)
                .WithName("CreateChoise")
                .WithTags("Creators");

            app.MapPut("/Choises", Put)
                .Accepts<ChoiseModel>("application/json")
                .WithName("UpdateChoise")
                .WithTags("Updaters");

            app.MapDelete("Choises/{id}", Delete)
                .WithName("DeleteChoise")
                .WithTags("Deleters");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.ChoiseService.Get() is List<ChoiseModel> choises
            ? Results.Ok(choises)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.ChoiseService.Get(id) is ChoiseModel choise
            ? Results.Ok(choise)
            : Results.NotFound();

        private IResult Post([FromBody] ChoiseModel choise, IServiceUnitOfWork service)
        {
            service.ChoiseService.Insert(choise);
            return Results.Created($"/Choises/{choise.Id}", choise);
        }

        private IResult Put([FromBody] ChoiseModel choise, IServiceUnitOfWork service)
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
