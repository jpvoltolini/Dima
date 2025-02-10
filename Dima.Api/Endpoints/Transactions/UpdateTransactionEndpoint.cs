using Dima.Api.Comum.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Transactions: Update")
            .WithSummary("Atualiza uma transação")
            .WithDescription("Atualiza e salva a transação desejada.")
            .WithOrder(2)
            .Produces<Response<Transaction?>>();  

    private static async Task<IResult> HandleAsync(
        [FromServices] ITransactionHandler handler,
        [FromBody] UpdateTransactionRequest request,
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

