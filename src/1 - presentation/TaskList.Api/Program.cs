using TaskList.Api;
using TaskList.Business.Abstractions.IoC;
using TaskList.Data.Abstractions.IoC;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .ConfigureRouteAndSwagger()
    .AddDatabase()
    .AddBusiness();

var app = builder
    .Build()
    .ConfigureMigrations()
    .ConfigureMiddlewares();

await app.RunAsync();
