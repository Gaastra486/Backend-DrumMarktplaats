using Microsoft.AspNetCore.Mvc;
using AccountService.Models;
using AccountService.Microservice.Context;
using AccountService.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using AccountService.Microservice.DTOs;
using AccountService.Microservice;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

//Configure Services
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountService", Version = "V1" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();



//Configure
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    DataSeeder.PrepPopulation(app);


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/user/login/", ([FromServices] IUserDAL db, [FromServices] IMapper mapper,  string username, string password) =>
{
    //var userItem = db.GetUserById(id);
    var userItem = db.GetUserByUsername(username);
    UserReadDTO user = mapper.Map<UserReadDTO>(userItem);
    if (user.Password == SecureString.ComputeStringToSha256Hash(password))
    {
        return user;
    }
    else
    {
        return null;
    }
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, [FromServices] IMapper mapper, int id) =>
{
    var userItem = db.DeleteUserById(id);
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
    user.Password = SecureString.ComputeStringToSha256Hash(user.Password);
    Console.WriteLine(user.Password);
    db.AddUser(mapper.Map<UserModel>(user));
});



app.Run();

public partial class UserProgram { }
