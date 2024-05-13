using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebExam.Infrasrtucture;
using WebExam.Infrasrtucture.Interfaces;
using WebExam.Infrasrtucture.UnitOfWork.Implementations;
using WebExam.Infrasrtucture.UnitOfWork.Interfaces;

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

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ExamApphbksdfbhjdsvfbhvfbhvhbwhbowbbhberwvvbyvybafvbiovfbao"))
        };
    });

    builder.Services.AddAuthorization();

    services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
    services.AddScoped<IMapperUnitOfWork, MapperUnitOfWork>();
    services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();

    /*services.AddTransient<IApi, SubjectApi>();
    services.AddTransient<IApi, QuestionApi>();
    services.AddTransient<IApi, ExamApi>();
    services.AddTransient<IApi, ExamPaperApi>();*/
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

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();
}
