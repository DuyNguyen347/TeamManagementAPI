using Microsoft.EntityFrameworkCore;
using TeamManagementAPI.GenericRepository;
using TeamManagementAPI.Helper;
using TeamManagementAPI.Models;
using TeamManagementAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("MyDB")
));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<ITeamRepository,TeamRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

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

app.Use((context, next) =>
{
    context.Items["requestTime"] = DateTime.UtcNow.ToString("o");
    // Console.WriteLine(context.Request.Headers);
    return next();
});

app.Run();
