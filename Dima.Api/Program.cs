using Dima.Api.Categories;
using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection1");

builder.Services.AddDbContext<AppDbContext>(
    x => { x.UseSqlServer(cnnStr); });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
    x.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


    builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
    builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.Run();