using Application.Services;
using Domain.Interfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.UtilsInterfaces;
using Domain.Interfaces.Services;
using Infra.Repositories;
using Infra.Data;
using AutoMapper;
using Domain.Entities;
using Domain.Dtos;
using Infra.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var config = new MapperConfiguration(cfg => {
    
    cfg.AddMaps("Domain");
});

var mapper = config.CreateMapper();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<INotebookService, NotebookService>();

// Repositories
builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<INotebookRepository, NotebookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IPasswordSaltRepository, PasswordSaltRepository>();

// Others
builder.Services.AddScoped<IHashPasswords, HashPasswords>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
