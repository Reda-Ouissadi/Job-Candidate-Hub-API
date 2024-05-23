using Job_Candidate_Hub_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Scaffold CMD => Scaffold-DbContext 'Name=ConnectionStrings:CANDIDAT' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables CANDIDAT
builder.Services.AddDbContext<JobCandidateHubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CANDIDAT")));

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

app.UseCors();

app.Run();
