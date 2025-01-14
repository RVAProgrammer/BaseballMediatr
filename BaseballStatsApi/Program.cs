using BaseballStatsApi.Application.Behaviors;
using BaseballStatsApi.Application.Dtos;
using BaseballStatsApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connString = builder.Configuration.GetConnectionString("BaseballConnection");
builder.Services.AddDbContext<BaseballContext>(x => x.UseSqlServer(connString));
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<DraftPlayerDto>();
    config.AddOpenBehavior(typeof(TimerBehavior<,>));
});

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