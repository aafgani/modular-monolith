using System;
using Application.Dtos;
using FluentValidation;

namespace Application.Behavior.Validation;

public class CreateActorValidator : AbstractValidator<CreateActorDto>
{
    public CreateActorValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Age).GreaterThanOrEqualTo(18);
    }
}
