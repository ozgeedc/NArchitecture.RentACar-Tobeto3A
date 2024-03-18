using Persistence;
using Application;
using Core.CrossCutting.Exceptions.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
WebApplication.CreateBuilder(args).Services.AddPersistenceServices(WebApplication.CreateBuilder(args).Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleware();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
