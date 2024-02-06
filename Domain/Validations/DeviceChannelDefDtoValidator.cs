using Domain.Dto;
using FluentValidation;

namespace Domain.Validations
{
    public class DeviceChannelDefDtoValidator : AbstractValidator<DeviceChannelDefRequestDto>
    {
        public DeviceChannelDefDtoValidator()
        {
            RuleFor(f => f.DeviceChannelNo).NotEmpty().NotNull().WithMessage("Kanal No alanı boş olamaz!!");
            RuleFor(f => f.DeviceChannelDesc).NotEmpty().NotNull().WithMessage("Cihaz Kanal Adı alanı boş olamaz !!");
            RuleFor(f => f.DeviceChannelCode).NotEmpty().NotNull().WithMessage("Cihaz Kanal Kodu alanı boş olamaz !!");
            RuleFor(f => f.DevicePortDefId).NotEmpty().NotNull().WithMessage("Cihaz Portu boş olamaz !!");
        }
    }
}
