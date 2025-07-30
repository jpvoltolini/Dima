using System;
using Dima.Api.Comum.Api;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/logout", HandleAsync)
        .RequireAuthorization();
    }

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        try
        {
            await signInManager.SignOutAsync();
            return Results.Ok(new { Message = "Logout realizado com sucesso." });
        }
        catch (Exception ex)
        {
            return Results.Problem($"Ocorreu um erro ao realizar o logout : {ex.Message}.", statusCode: 500);
        }
    }
}


