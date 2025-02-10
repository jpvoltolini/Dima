using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Responses;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .WithName("Categories: Update")
                .WithSummary("Atualiza uma categoria")
                .WithDescription("Atualiza e salva a categoria desejada.")
                .WithOrder(2)
                .Produces<Response<Category?>>();  

        private static async Task<IResult> HandleAsync(
            [FromServices] ICategoryHandler handler,
            [FromBody] UpdateCategoryRequest request,
            [FromRoute] long id)
        {
            request.Id = id;
            request.UserId = "";
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
