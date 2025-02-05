using Develop.Store.Domain.DTO;
using FluentValidation;

namespace Develop.Store.Domain.Validations
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Quantities)
                .NotNull()
                .LessThan(20)
                .WithMessage("Allowed only until twenty items")
                .GreaterThan(1)
                .WithMessage("select at least one item");
        }
    }
}
