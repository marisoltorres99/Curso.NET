using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDTO>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
