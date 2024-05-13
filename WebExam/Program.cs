using WebExam.APIs.Implementations;
using WebExam.APIs.Interfaces;
using WebExam.DataAccess.Repositories.Implementations.SqlServer;
using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.Mappers.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Services.Implementations;
using WebExam.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

var apis = app.Services.GetServices<IApi>();
foreach (var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api not found");
    api.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<ExamAppDb>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    });
    services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
    services.AddScoped<IMapperUnitOfWork, MapperUnitOfWork>();
    services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();

    services.AddTransient<IApi, SubjectApi>();
    services.AddTransient<IApi, QuestionApi>();
    services.AddTransient<IApi, ChoiseApi>();
    services.AddTransient<IApi, ExamApi>();
    services.AddTransient<IApi, ExamPaperApi>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ExamAppDb>();
        db.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();
}
