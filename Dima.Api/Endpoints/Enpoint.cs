using Dima.Api.Comum.Api;
using Dima.Api.Endpoints.Categories;
using Dima.Core.Requests.Categories;

namespace Dima.Api.Endpoints
{
    public static class Enpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/v1/categories")
               .WithTags("Categories")
//               .RequireAuthorization()
               .MapEndpoint<CreateCategoryEndpoint>()
               .MapEndpoint<UpdateCategoryEndpoint>()
               .MapEndpoint<DeleteCategoryEndpoint>()
               .MapEndpoint<GetCategoryByIdEndpoint>()
               .MapEndpoint<GetAllCategoriesEndpoint>();
        }


        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
