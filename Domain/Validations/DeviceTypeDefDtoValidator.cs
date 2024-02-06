using Domain.Dto;
using FluentValidation;
namespace Domain.Validations
{
    public class DeviceTypeDefRequestDtoValidator : AbstractValidator<DeviceTypeDefRequestDto>
    {
        public DeviceTypeDefRequestDtoValidator()
        {
            RuleFor(f => f.DeviceType).NotEmpty().NotNull().WithMessage("Cihaz Tipi alanı boş olamaz!!");
            RuleFor(f => f.DeviceTypeDesc).NotEmpty().NotNull().WithMessage("Cihaz Tipi Açıklama alanı boş olamaz !!");
        }
    }
}
