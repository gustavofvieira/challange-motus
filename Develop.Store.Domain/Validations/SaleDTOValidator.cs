using Develop.Store.Domain.DTO;
using FluentValidation;

namespace Develop.Store.Domain.Validations
{
    public class SaleDTOValidator : AbstractValidator<SaleDTO>
    {
        //public SaleDTOValidator()
        //{
        //    RuleFor(x => x.Products.)
        //        .NotNull()
        //        .GreaterThan(20)
        //        .WithMessage("Allowed only until twenty items");
        //}
    }
}
