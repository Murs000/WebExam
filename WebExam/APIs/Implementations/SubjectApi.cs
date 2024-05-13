using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebExam.APIs.Implementations
{
    public class SubjectApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Subjects", Get)
                .Produces<List<SubjectModel>>(StatusCodes.Status200OK)
                .WithName("GetAllSubjects")
                .WithTags("Getters")
                .RequireAuthorization("Admin");

            app.MapGet("/Subjects/{id}", GetById)
                .Produces<SubjectModel>(StatusCodes.Status200OK)
                .WithName("GetSubject")
                .WithTags("Getters")
                .RequireAuthorization("Admin");

            app.MapPost("/Subjects", Post)
                .Accepts<SubjectModel>("application/json")
                .Produces<SubjectModel>(StatusCodes.Status201Created)
                .WithName("CreateSubject")
                .WithTags("Creators")
                .RequireAuthorization("Admin");

            app.MapPut("/Subjects", Put)
                .Accepts<SubjectModel>("application/json")
                .WithName("UpdateSubject")
                .WithTags("Updaters")
                .RequireAuthorization("Admin");

            app.MapDelete("Subjects/{id}", Delete)
                .WithName("DeleteSubject")
                .WithTags("Deleters")
                .RequireAuthorization("Admin");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.SubjectService.Get() is List<SubjectModel> subjects
            ? Results.Ok(subjects)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.SubjectService.Get(id) is SubjectModel subject
            ? Results.Ok(subject)
            : Results.NotFound();

        private IResult Post([FromBody] SubjectModel subject, IServiceUnitOfWork service)
        {
            service.SubjectService.Insert(subject);
            return Results.Created($"/Subjects/{subject.Id}", subject);
        }

        private IResult Put([FromBody] SubjectModel subject, IServiceUnitOfWork service)
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
