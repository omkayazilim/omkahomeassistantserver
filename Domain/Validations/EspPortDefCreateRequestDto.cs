using Domain.Dto;
using FluentValidation;

namespace Domain.Validations
{
    public class EspPortDefCreateRequestDtoValidator : AbstractValidator<EspPortDefCreateRequestDto>
    {
        public EspPortDefCreateRequestDtoValidator()
        {
            RuleFor(f => f.PortKey).NotEmpty().NotNull().WithMessage("PorKey alanı boş olamaz!!");
            RuleFor(f => f.PortNumber).NotEmpty().NotNull().WithMessage("PortNumber alanı boş olamaz !!");
            RuleFor(f => f.PortDesc).NotEmpty().NotNull().WithMessage("PortDesc alanı boş olamaz !!");
        }
    }
}
