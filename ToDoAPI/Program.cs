using Microsoft.EntityFrameworkCore;
using ToDoAPI.DAL.DbContexts;
using ToDoAPI.DAL.Repositories.Implementation;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Services.Implementation;
using ToDoAPI.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer("name=DefaultConnection");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
