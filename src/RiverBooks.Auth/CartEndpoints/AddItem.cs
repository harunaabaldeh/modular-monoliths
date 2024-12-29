using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using RiverBooks.Auth.UseCases;

namespace RiverBooks.Auth.CartEndpoints;

internal class AddItem : Endpoint<AddCardItemRequest>
{
    private readonly IMediator _mediator;
    public AddItem(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Post("/cart");
        Claims("EmailAddress");
    }

    public override async Task HandleAsync(AddCardItemRequest request, CancellationToken ct)
    {
        var emailAddress = User.FindFirstValue("EmailAddress");
        
        var command = new AddItemToCartCommand(request.BookId, request.Quantity, emailAddress!);
        
        var result = await _mediator.Send(command, ct);

        if (result.Status == ResultStatus.Unauthorized)
        {
            await SendUnauthorizedAsync(ct);
        }
        else
        {
            await SendOkAsync(ct);
        }
    }
}