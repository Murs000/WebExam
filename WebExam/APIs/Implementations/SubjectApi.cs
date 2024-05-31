using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebExam.Entity.Implementations;

namespace WebExam.APIs.Implementations
{
    public class SubjectApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Subjects", Get)
                .Produces<List<Subject>>(StatusCodes.Status200OK)
                .WithName("GetAllSubjects")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapGet("/Subjects/{id}", GetById)
                .Produces<Subject>(StatusCodes.Status200OK)
                .WithName("GetSubject")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapPost("/Subjects", Post)
                .Accepts<Subject>("application/json")
                .Produces<Subject>(StatusCodes.Status201Created)
                .WithName("CreateSubject")
                .WithTags("Creators")
                .RequireAuthorization("AdminOnly");

            app.MapPut("/Subjects", Put)
                .Accepts<Subject>("application/json")
                .WithName("UpdateSubject")
                .WithTags("Updaters")
                .RequireAuthorization("AdminOnly");

            app.MapDelete("Subjects/{id}", Delete)
                .WithName("DeleteSubject")
                .WithTags("Deleters")
                .RequireAuthorization("AdminOnly");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.SubjectService.Get() is List<Subject> subjects
            ? Results.Ok(subjects)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.SubjectService.Get(id) is Subject subject
            ? Results.Ok(subject)
            : Results.NotFound();

        private IResult Post([FromBody] Subject subject, IServiceUnitOfWork service)
        {
            service.SubjectService.Insert(subject);
            return Results.Created($"/Subjects/{subject.Id}", subject);
        }

        private IResult Put([FromBody] Subject subject, IServiceUnitOfWork service)
        {
            service.SubjectService.Update(subject);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.SubjectService.Delete(id);
            return Results.NoContent();
        }
    }
}
