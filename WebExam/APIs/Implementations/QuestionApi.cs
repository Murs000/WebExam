using WebExam.APIs.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebExam.APIs.Implementations
{
    public class QuestionApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/Questions", Get)
                .Produces<List<QuestionModel>>(StatusCodes.Status200OK)
                .WithName("GetAllQuestions")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapGet("/Questions/{id}", GetById)
                .Produces<QuestionModel>(StatusCodes.Status200OK)
                .WithName("GetQuestion")
                .WithTags("Getters")
                .RequireAuthorization("Stuff");

            app.MapPost("/Questions", Post)
                .Accepts<QuestionModel>("application/json")
                .Produces<QuestionModel>(StatusCodes.Status201Created)
                .WithName("CreateQuestion")
                .WithTags("Creators")
                .RequireAuthorization("Stuff");

            app.MapPut("/Questions", Put)
                .Accepts<QuestionModel>("application/json")
                .WithName("UpdateQuestion")
                .WithTags("Updaters")
                .RequireAuthorization("Stuff");

            app.MapDelete("Questions/{id}", Delete)
                .WithName("DeleteQuestion")
                .WithTags("Deleters")
                .RequireAuthorization("Stuff");

        }

        private IResult Get(IServiceUnitOfWork service) =>
            service.QuestionService.Get() is List<QuestionModel> questions
            ? Results.Ok(questions)
            : Results.NotFound();

        private IResult GetById(int id, IServiceUnitOfWork service) =>
            service.QuestionService.Get(id) is QuestionModel question
            ? Results.Ok(question)
            : Results.NotFound();

        private IResult Post([FromBody] QuestionModel question, IServiceUnitOfWork service)
        {
            service.QuestionService.Insert(question);
            return Results.Created($"/Questions/{question.Id}", question);
        }

        private IResult Put([FromBody] QuestionModel question, IServiceUnitOfWork service)
        {
            service.QuestionService.Update(question);
            return Results.NoContent();
        }

        private IResult Delete(int id, IServiceUnitOfWork service)
        {
            service.QuestionService.Delete(id);
            return Results.NoContent();
        }
    }
}
