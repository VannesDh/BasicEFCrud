using BasicCrud.Models;
using FluentValidation;

namespace BasicCrud.Validators;

public class FoodDTOValidator : AbstractValidator<Food>
{
    public FoodDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Restaurant name is required.")
            .MaximumLength(100)
            .WithMessage("Restaurant name cannot exceed 100 characters.");

        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .WithMessage("RestaurantId is required.")
            .GreaterThan(0)
            .WithMessage("RestaurantId must be greater than 0.");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}