using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebExam.Entity.Implementations;

namespace WebExam.APIs.Implementations
{
    public class ExamApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Exams", Get)
                .Produces<List<Exam>>(StatusCodes.Status200OK)
                .WithName("GetAllExams")
                .WithTags("Getters")
                .RequireAuthorization("AdminOnly");

            app.MapGet("/Exams/{id}", GetById)
                .Produces<Exam>(StatusCodes.Status200OK)
                .WithName("GetExam")
                .WithTags("Getters")
                .RequireAuthorization("AdminOnly");

            app.MapPost("/Exams", Post)
                .Accepts<Exam>("application/json")
                .Produces<Exam>(StatusCodes.Status201Created)
                .WithName("CreatetExam")
                .WithTags("Creators")
                .RequireAuthorization("AdminOnly");

            app.MapPut("/Exams", Put)
                .Accepts<Exam>("application/json")
                .WithName("UpdatetExam")
                .WithTags("Updaters")
                .RequireAuthorization("AdminOnly");

            app.MapDelete("Exams/{id}", Delete)
                .WithName("DeletetExam")
                .WithTags("Deleters")
                .RequireAuthorization("AdminOnly");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.ExamService.Get() is List<Exam> exams
            ? Results.Ok(exams)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.ExamService.Get(id) is Exam exam
            ? Results.Ok(exam)
            : Results.NotFound();

        private IResult Post([FromBody] Exam exam, IServiceUnitOfWork service)
        {
            service.ExamService.Insert(exam);
            return Results.Created($"/Exams/{exam.Id}", exam);
        }

        private IResult Put([FromBody] Exam exam, IServiceUnitOfWork service)
        {
            service.ExamService.Update(exam);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.ExamService.Delete(id);
            return Results.NoContent();
        }
    }
}