using Microsoft.EntityFrameworkCore;
using NeEkersenProject.Data.Contexts;
using NeEkersenProject.Interfaces;
using NeEkersenProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ActivityContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<IActivity, ActivityRepository>();
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
