using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint :IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapGet("/{id}", HandleAsync)
            .WithName("Transaction: Get by id")
            .WithSummary("Recupera uma transação")
            .WithDescription("Recupera a transação selecionada.")
            .WithOrder(4)
            .Produces<Response<Transaction?>>();




    private static async Task<IResult> HandleAsync(
        [FromServices] ITransactionHandler handler, 
        [FromRoute] long id)
    {
        var request = new GetTransactionByIdRequest
        {
            Id = id,
            UserId = "Teste"
        };

        var result = await handler.GetTransactionByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}