using Dima.Api.Comum.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)

           => app.MapPost("", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Recupera todas as categorias")
            .WithDescription("Monta uma lista com todas as categorias.")
            .WithOrder(5)
            .Produces<PagedResponse<Category?>>();




        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler, 
            GetAllCategoriesRequest request, 
            [FromQuery] int pageSize = Configuration.DefaultPageSize,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber)
        {
            request.UserId = "";
            request.PageSize = pageSize;
            request.PageNumber = pageNumber;

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                    ? TypedResults.Ok(result.Data)
                    : TypedResults.BadRequest(result.Data);
        }
    }
}
