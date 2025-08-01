﻿using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)

           => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma categoria")
            .WithOrder(1)
            .Produces<Response<Category?>>();
        

        
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            [FromServices] ICategoryHandler handler,
            [FromBody] CreateCategoryRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSuccess 
                    ? TypedResults.Created($"/{result.Data?.Id}", result.Data) 
                    : TypedResults.BadRequest(result.Data);
        }
    }
}
