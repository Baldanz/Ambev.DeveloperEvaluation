﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;

public class GetCartValidator : AbstractValidator<GetCartCommand>
{
    /// <summary>
    /// Initializes validation rules for GetCartCommand
    /// </summary>
    public GetCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
