using Dima.Api.Comum.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapGet("/", HandleAsync)
            .WithName("Transaction: Get by Period")
            .WithSummary("Recupera transações de uma data")
            .WithDescription("Monta uma lista com as transações de um determinado período.")
            .WithOrder(5)
            .Produces<PagedResponse<Category?>>();




    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        [FromServices] ITransactionHandler handler, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] DateTime? startDate = null, 
        [FromQuery] DateTime? endDate = null)
    {
        var request = new GetTransactionsByPeriodRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageSize = pageSize,
            PageNumber = pageNumber,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}