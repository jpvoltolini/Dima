using System.Reflection.Metadata.Ecma335;

namespace Dima.Core.Requests;

public abstract class PagedRequest : Request
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber; // paginação
    public int PageSize { get; set; } = Configuration.DefaultPageSize;  // registros por pagina
}