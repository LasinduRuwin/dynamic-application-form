using DynamicApplicationFormAPI.DatabaseContext;
using DynamicApplicationFormAPI.Models;
using DynamicApplicationFormAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Configure Entity Framework Core to use Azure Cosmos DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseCosmos(
        builder.Configuration["CosmosDb:AccountEndpoint"],
        builder.Configuration["CosmosDb:AccountKey"],
        builder.Configuration["CosmosDb:DatabaseName"]
    ));

// Register Repositories
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
