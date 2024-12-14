using FluentValidation;
using MicroVikRegistry.WebApi.Database;
using MicroVikRegistry.WebApi.Endpoints;
using MicroVikRegistry.WebApi.Helpers;
using MicroVikRegistry.WebApi.Nodes.Infrastructure;
using System.Text.Json.Serialization;

namespace MicroVikRegistry.WebApi.Nodes
{
    public static class CreateNode
    {
        public record Request(
            [property: JsonPropertyName("url")] string Url,
            [property: JsonPropertyName("location")] string Location,
            [property: JsonPropertyName("wallet")] string Wallet);
        public record Response(
            [property: JsonPropertyName("congrats")] string Congrats);
        public const string Tag = "Nodes";

        public sealed class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(r => r.Url).NotEmpty().NotNull().MaximumLength(150).Matches(Regexs.Url);
                RuleFor(r => r.Location).MaximumLength(100);
            }
        }
        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPost("api/nodes", Handler).WithTags(Tag);
            }
        }
        public static async Task<IResult> Handler(Request request, ApplicationContext db, INodeRepository nodeRepository)
        {
            Node node = new Node
            {
                Id = Guid.NewGuid(),
                IsOffical = false,
                StartedAt = DateTime.UtcNow,
                Url = request.Url,
                Location = request.Location,
                Wallet = request.Wallet,
            };
            await nodeRepository.InsertAsync(node, db);
            return Results.Ok(new Response("Congratulations"));
        }
    }
}
