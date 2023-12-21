using Domain.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class PortPropsSetRequestValidator : AbstractValidator<PortPropsSetRequestDto>
    {
        public PortPropsSetRequestValidator()
        {
            RuleFor(f => f.PortKey).NotEmpty().WithMessage("PorKey alanı boş olamaz!!");
            RuleFor(f => f.PortNumber).NotEmpty().WithMessage("PortNumber alanı boş olamaz !!");
        }
    }
}
