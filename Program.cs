using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
var connecionString = builder.Configuration.GetConnectionString("ConString");
builder.Services.AddDbContext<TaskAppContext>(
    options =>
    {
        options
        .UseSqlServer(connecionString);

    });

builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
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

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
