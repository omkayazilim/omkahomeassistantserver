using Domain.Dto;
using FluentValidation;

namespace Domain.Validations
{
    public class EspPortDefUpdateRequestDtoValidator : AbstractValidator<EspPortDefUpdateRequestDto>
    {
        public EspPortDefUpdateRequestDtoValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage("Kayıt Id alanı 0 olamaz!!");
            RuleFor(f => f.PortKey).NotEmpty().WithMessage("PorKey alanı boş olamaz!!");
            RuleFor(f => f.PortNumber).NotEmpty().WithMessage("PortNumber alanı boş olamaz !!");
            RuleFor(f => f.PortDesc).NotEmpty().WithMessage("PortDesc alanı boş olamaz !!");
        }
    }
}
