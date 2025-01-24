using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)

           => app.MapPost("/{id}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Excluir uma categoria")
            .WithDescription("Exclui a categoria Selecionada.")
            .WithOrder(3)
            .Produces<Response<Category?>>();




        private static async Task<IResult> HandleAsync(ICategoryHandler handler, DeleteCategoryRequest request, long id)
        {
            request.Id = id;
            request.UserId = "";

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess
                    ? TypedResults.Ok(result.Data)
                    : TypedResults.BadRequest(result.Data);
        }
    }
}
