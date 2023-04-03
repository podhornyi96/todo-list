using Microsoft.EntityFrameworkCore;
using TodoListService.Common.Automapper;
using TodoListService.Common.Database;
using TodoListService.Persistence;
using TodoListService.Services;
using TodoListService.Services.TodoListService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var corsPolicyName = "customCorsPolicyName";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        builder =>
        {
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
            builder.WithOrigins("http://localhost:4200");
        });
});

builder.Services.AddControllers();

var dbConnectionString = builder.Configuration.GetConnectionString("DbContext");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(dbConnectionString));
    
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "TodoListInstance";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ITodoListService, TodoListService.Services.TodoListService.TodoListService>();

var app = builder.Build();

app.SyncMigrations<ApplicationDbContext>();
app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
