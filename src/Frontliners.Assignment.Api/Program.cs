using Frontliners.Assignment.Api.Middleware.Exceptions;
using Frontliners.Assignment.Application.Extensions;
using Frontliners.Assignment.Domain.Settings;
using Frontliners.Assignment.Infrastructure.Persistence;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<FrontlinersAssignmentDatabaseSettings>(builder.Configuration.GetSection("FrontlinersAssignmentDatabase"));
builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
builder.Services.RegisterApplicationServices();
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

app.UseExceptionHandlerMiddleware();

app.MapControllers();

app.Run();
