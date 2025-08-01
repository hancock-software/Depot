namespace Depot.Auth.Endpoints;

using System.Reactive.Threading.Tasks;
using Extensions;
using Features.Users.ChangePassword;
using Features.Users.Me;
using Mestra.Abstractions;
using Microsoft.AspNetCore.Mvc;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var api = routes.MapGroup("/user").WithTags("User");

        api.MapGet("/me", MeAsync)
            .WithDescription("");

        api.MapPatch("/password", ChangePasswordAsync)
            .WithDescription("Change password");

        api.MapGet("/tenants", GetTenantsAsync)
            .WithDescription("Gets the tenants list");

        api.MapPatch("/tenants/active", SetTenantAsync)
            .WithDescription("Set the active tenant.");

        api.MapGet("/organisations", GetOrganisationsAsync)
            .WithDescription("Get organisations user belongs to");

        return api;
    }

    private static Task<IResult> MeAsync([FromServices] IMediator mediator, HttpContext context)
    {
        return mediator.Send(new MeQuery()).ToTask(context.RequestAborted).ToOkAsync();
    }

    private static Task<IResult> ChangePasswordAsync([FromServices] IMediator mediator, HttpContext context)
    {
        return mediator.Send(new ChangePasswordCommand()).ToTask(context.RequestAborted).ToOkAsync();
    }

    private async static Task<IResult> GetTenantsAsync([FromServices] IMediator mediator, HttpContext context)
    {
        return Results.NotFound();
    }

    private async static Task<IResult> SetTenantAsync([FromServices] IMediator mediator, HttpContext context)
    {
        return Results.NotFound();
    }


    private async static Task<IResult> GetOrganisationsAsync([FromServices] IMediator mediator, HttpContext context)
    {
        return Results.NotFound();
    }
}