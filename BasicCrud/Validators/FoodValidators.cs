using BasicCrud.Models;
using FluentValidation;

namespace BasicCrud.Validators;

public class FoodValidator : AbstractValidator<Food>
{
    public FoodValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Food name is required.")
            .MaximumLength(100)
            .WithMessage("Food name cannot exceed 100 characters.");

       RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .WithMessage("RestaurantId is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");
    }
}