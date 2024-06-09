using Microsoft.EntityFrameworkCore;
using Test2_Mock.Context;
using Test2_Mock.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adding the controllers
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Here I use error handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
//Mapping the controllers
app.MapControllers();

app.Run();

