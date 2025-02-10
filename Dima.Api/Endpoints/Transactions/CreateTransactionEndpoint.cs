using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint: IEndpoint
{
    
    
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPost("/", HandleAsync)
            .WithName("Transactions: Create")
            .WithSummary("Cria uma transação")
            .WithOrder(1)
            .Produces<Response<Transaction?>>();
        

        
    private static async Task<IResult> HandleAsync(
       [FromServices] ITransactionHandler handler, 
        [FromBody] CreateTransactionRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Created($"/{result.Data?.Id}", result.Data) 
            : TypedResults.BadRequest(result.Data);
    }
}