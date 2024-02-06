using Domain.Dto;
using FluentValidation;

namespace Domain.Validations
{
    public class DeviceDefRequestDtoValidator : AbstractValidator<DeviceDefRequestDto>
    {
        public DeviceDefRequestDtoValidator()
        {
            RuleFor(f => f.DeviceAdressUrl).NotEmpty().NotNull().WithMessage("AdressUrl alanı boş olamaz!!");
            RuleFor(f => f.DeviceName).NotEmpty().NotNull().WithMessage("Cihaz Adı alanı boş olamaz !!");
            RuleFor(f => f.DeviceCode).NotEmpty().NotNull().WithMessage("Cihaz Kodu alanı boş olamaz !!");
        }
    }  
    
   
}
