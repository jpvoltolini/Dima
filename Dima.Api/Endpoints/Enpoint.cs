﻿using Dima.Api.Comum.Api;
using Dima.Api.Endpoints.Categories;
using Dima.Api.Endpoints.Transactions;
using Dima.Core.Requests.Categories;

namespace Dima.Api.Endpoints
{
    public static class Enpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("v1/categories")
               .WithTags("Categories")
               .MapEndpoint<CreateCategoryEndpoint>()
               .MapEndpoint<UpdateCategoryEndpoint>()
               .MapEndpoint<DeleteCategoryEndpoint>()
               .MapEndpoint<GetCategoryByIdEndpoint>()
               .MapEndpoint<GetAllCategoriesEndpoint>();
            
            endpoints.MapGroup("v1/transactions")
                .WithTags("Transactions")
                .MapEndpoint<CreateTransactionEndpoint>()
                .MapEndpoint<UpdateTransactionEndpoint>()
                .MapEndpoint<DeleteTransactionEndpoint>()
                .MapEndpoint<GetTransactionByIdEndpoint>()
                .MapEndpoint<GetTransactionsByPeriodEndpoint>();
            
            
        }


        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
