using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IDataContext, DbBugBountyHunterContext>(s =>
{
    DbContextOptions<DbBugBountyHunterContext> options = new DbContextOptionsBuilder<DbBugBountyHunterContext>().UseSqlServer(configuration.GetConnectionString("Default")).Options;
    return new DbBugBountyHunterContext(options);
});
builder.Services.AddScoped<IUserRepository, UserService>();

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
