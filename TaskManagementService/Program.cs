using TaskManagementService.Repository;
using TaskManagementService.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
