using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebExam.APIs.Implementations
{
    public class ExamApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Exams", Get)
                .Produces<List<ChoiseModel>>(StatusCodes.Status200OK)
                .WithName("GetAllExams")
                .WithTags("Getters");

            app.MapGet("/Exams/{id}", GetById)
                .Produces<ChoiseModel>(StatusCodes.Status200OK)
                .WithName("GetExam")
                .WithTags("Getters");

            app.MapPost("/Exams", Post)
                .Accepts<ChoiseModel>("application/json")
                .Produces<ChoiseModel>(StatusCodes.Status201Created)
                .WithName("CreatetExam")
                .WithTags("Creators");

            app.MapPut("/Exams", Put)
                .Accepts<ChoiseModel>("application/json")
                .WithName("UpdatetExam")
                .WithTags("Updaters");

            app.MapDelete("Exams/{id}", Delete)
                .WithName("DeletetExam")
                .WithTags("Deleters");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.ExamService.Get() is List<ExamModel> choises
            ? Results.Ok(choises)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.ExamService.Get(id) is ExamModel choise
            ? Results.Ok(choise)
            : Results.NotFound();

        private IResult Post([FromBody] ExamModel choise, IServiceUnitOfWork service)
        {
            service.ExamService.Insert(choise);
            return Results.Created($"/Exams/{choise.Id}", choise);
        }

        private IResult Put([FromBody] ExamModel choise, IServiceUnitOfWork service)
        {
            service.ExamService.Update(choise);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.ExamService.Delete(id);
            return Results.NoContent();
        }
    }
}