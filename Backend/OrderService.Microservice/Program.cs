using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderService.Microservice;
using OrderService.Microservice.Context;
using OrderService.Microservice.Data;
using OrderService.Microservice.DTOs;
using OrderService.Microservice.Model;
using SharedLibrary;
using Bid = OrderService.Microservice.Model.Bid;

var builder = WebApplication.CreateBuilder(args);

RabbitMQSettings rMQSettings = new RabbitMQSettings();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderService", Version = "V1" });
});

builder.Host.ConfigureServices(s =>
{
    s.AddDbContext<OrderDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
    s.AddScoped<IBidDAL, BidDAL>();
    s.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
});
builder.Services.AddMassTransit(config => {
    // Add Consumer which reads the sent message;
    config.AddConsumer<BidConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + rMQSettings.Username + ":" + rMQSettings.Password + "@" + rMQSettings.IPAddress);
        // Add endpoint which will recieve messages from the [model] queue, these messages will be returned in via Consumer class;
        // In here you will be able to change settings, like setting the queue messageretry interval and more;
        cfg.ReceiveEndpoint(rMQSettings.QueueName, c =>
        {
            c.ConfigureConsumer<BidConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DataSeeder.PrepPopulation(app);

app.MapPost("/bid/add", ([FromServicesAttribute] IBidDAL db, [FromServicesAttribute] IMapper mapper, BidCreateDTO bid) =>
{
    db.AddBid(mapper.Map<Bid>(bid));
});

app.MapGet("/bid/getbyproduct/{id}", ([FromServices] IBidDAL db, [FromServices] IMapper mapper, int id) =>
{
    var bidItem = db.GetBidsByProductId(id);

    return mapper.Map<List<BidReadDTO>>(bidItem);
});

app.MapGet("/bid/all", ([FromServices] IBidDAL db, [FromServices] IMapper mapper) => 
{
    var bidItem = db.GetBids();

    return mapper.Map<List<BidReadDTO>>(bidItem);
});

app.Run();
