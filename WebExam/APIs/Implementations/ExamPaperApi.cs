using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebExam.APIs.Implementations
{
    public class ExamPaperApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/ExamPapers", Get)
                .Produces<List<ExamPaperModel>>(StatusCodes.Status200OK)
                .WithName("GetAllExamPapers")
                .WithTags("Getters");

            app.MapGet("/ExamPapers/{id}", GetById)
                .Produces<ExamPaperModel>(StatusCodes.Status200OK)
                .WithName("GetExamPaper")
                .WithTags("Getters");

            app.MapPost("/ExamPapers", Post)
                .Accepts<ExamPaperModel>("application/json")
                .Produces<ExamPaperModel>(StatusCodes.Status201Created)
                .WithName("CreatetExamPaper")
                .WithTags("Creators");

            app.MapPut("/ExamPapers", Put)
                .Accepts<ExamPaperModel>("application/json")
                .WithName("UpdatetExamPaper")
                .WithTags("Updaters");

            app.MapDelete("ExamPapers/{id}", Delete)
                .WithName("DeletetExamPaper")
                .WithTags("Deleters");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.ExamPaperService.Get() is List<ExamPaperModel> choises
            ? Results.Ok(choises)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.ExamPaperService.Get(id) is ExamPaperModel choise
            ? Results.Ok(choise)
            : Results.NotFound();

        private IResult Post([FromBody] ExamPaperModel choise, IServiceUnitOfWork service)
        {
            service.ExamPaperService.Insert(choise);
            return Results.Created($"/ExamPapers/{choise.Id}", choise);
        }

        private IResult Put([FromBody] ExamPaperModel choise, IServiceUnitOfWork service)
        {
            service.ExamPaperService.Update(choise);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.ExamPaperService.Delete(id);
            return Results.NoContent();
        }
    }
}
