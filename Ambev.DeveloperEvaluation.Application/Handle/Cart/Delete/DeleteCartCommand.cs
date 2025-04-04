﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Delete;

public record DeleteCartCommand : IRequest<DeleteCartResponse>
{
    /// <summary>
    /// The unique identifier of the product to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteCartCommand
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    public DeleteCartCommand(Guid id)
    {
        Id = id;
    }
}
