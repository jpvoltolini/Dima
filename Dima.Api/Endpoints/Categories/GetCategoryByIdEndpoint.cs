using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)

           => app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get by id")
            .WithSummary("Recupera uma categoria")
            .WithDescription("Recupera a categoria selecionada.")
            .WithOrder(4)
            .Produces<Response<Category?>>();




        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            [FromServices] ICategoryHandler handler, 
            [FromRoute ] long id)
        {
            var request = new GetCategoryByIdRequest
            {
                Id = id,
                UserId = user.Identity?.Name ?? string.Empty
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess
                    ? TypedResults.Ok(result.Data)
                    : TypedResults.BadRequest(result.Data);
        }
    }
}
