
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest? transaction);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest? transaction);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest? transaction);
    Task<Response<Transaction?>> GetTransactionByIdAsync(GetTransactionByIdRequest? transaction);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest? transaction);
}