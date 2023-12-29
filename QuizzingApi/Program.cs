using Microsoft.EntityFrameworkCore;
using QuizzingApi;
using QuizzingApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomAuthentication", policy =>
        policy.Requirements.Add(new CustomAuthenticationRequirement()));
});

builder.Services.AddDbContext<JkoatuolContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("jkoatuolContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
