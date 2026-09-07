using BasicCrud.Models;
using FluentValidation;

namespace BasicCrud.Validators;

public class RestaurantValidator : AbstractValidator<Restaurant>
{
    public RestaurantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Restaurant name is required.")
            .MaximumLength(100)
            .WithMessage("Restaurant name cannot exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location is required.");

        RuleFor(x => x.Star)
            .InclusiveBetween(1, 5)
            .WithMessage("Star rating must be between 1 and 5.");

        RuleFor(x => x.RestaurantType)
            .IsInEnum()
            .WithMessage("Invalid restaurant type.");
    }
}