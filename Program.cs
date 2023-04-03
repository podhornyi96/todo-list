using Microsoft.EntityFrameworkCore;
using TodoListService.Common.Database;
using TodoListService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var corsPolicyName = "customCorsPolicyName";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200");
        });
});

builder.Services.AddControllers();

var dbConnectionString = builder.Configuration.GetConnectionString("DbContext");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(dbConnectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.SyncMigrations<ApplicationDbContext>();

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
