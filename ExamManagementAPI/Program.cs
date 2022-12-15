using ExamManagementAPI.Data;
using ExamManagementAPI.Extensions;
using ExamManagementAPI.Services.Implementations;
using ExamManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = environment == Environments.Development;
IConfiguration config = ConfigurationSetup.GetConfig(isDevelopment);
LoggerConfig.SetUpSerilog(config);


try
{
    Log.Information("Starting application...");
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IExamService, ExamService>();

    var configuration = builder.Configuration;
    builder.Services.AddDbContext<AppDataContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    /*if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }*/

    /*builder.Services.AddCors(policyBuilder =>
        policyBuilder.AddDefaultPolicy(policy =>
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
    );*/

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRouting();
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MigrateDatabase();
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e.Message, e.StackTrace, "application unable to start correctly");
}