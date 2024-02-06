using Domain.Dto;
using FluentValidation;
namespace Domain.Validations
{
    public class DevicePortDefRequestDtoValidator : AbstractValidator<DevicePortDefRequestDto>
    {
        public DevicePortDefRequestDtoValidator()
        {
            //RuleFor(f => f.PortCode).NotEmpty().NotNull().WithMessage("Code alanı boş olamaz!!");
            //RuleFor(f => f.PortNumber).NotEmpty().NotNull().WithMessage("Port No alanı boş olamaz !!");
            //RuleFor(f => f.PortDesc).NotEmpty().NotNull().WithMessage("Port Açıklama alanı boş olamaz !!");
        }
    }
}
