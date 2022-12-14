using Application.Services;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Infra.Repositories;
using Infra.Data;
using AutoMapper;
using Domain.Entities;
using Domain.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<User, GetUserDto>();
    cfg.CreateMap<GetUserDto, User>();
    cfg.CreateMap<User, FoundUserDto>();
    cfg.CreateMap<FoundUserDto, User>();
});

var mapper = config.CreateMapper();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
