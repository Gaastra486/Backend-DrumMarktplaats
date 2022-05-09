using Microsoft.AspNetCore.Mvc;
using AccountService.Models;
using AccountService.Microservice.Context;
using AccountService.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using AccountService.Microservice.DTOs;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

//Configure Services
//builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountService", Version = "V1" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

DataSeeder.PrepPopulation(app);
//Configure

/*if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);*/

/*void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}*/

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/user/login/{id}", ([FromServices] IUserDAL db, [FromServices] IMapper mapper,  int id) =>
{
    var userItem = db.GetUserById(id);

    return mapper.Map<UserReadDTO>(userItem);
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, [FromServices] IMapper mapper, int id) =>
{
    var userItem = db.DeleteUserById(id);

    mapper.Map<UserReadDTO>(userItem);
});

app.MapGet("/user/all", ([FromServices] IUserDAL db, [FromServices] IMapper mapper) =>
{
    var userItem = db.GetUsers();

    return mapper.Map<IEnumerable<UserReadDTO>>(userItem);
});

app.MapPut("/user/update/{id}", ([FromServices] IUserDAL db, [FromServices] IMapper mapper, UserUpdateDTO user) =>
{

    db.UpdateUser(mapper.Map<UserModel>(user));
});

app.MapPost("/user/add", ([FromServices] IUserDAL db, [FromServices] IMapper mapper, UserCreateDTO user) =>
{
    db.AddUser(mapper.Map<UserModel>(user));
});

app.Run();

public partial class Program { }
