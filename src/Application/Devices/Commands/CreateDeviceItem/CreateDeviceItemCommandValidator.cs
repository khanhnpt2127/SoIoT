using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SoIoT.Application.Devices.Commands.CreateDeviceItem
{
    public class CreateDeviceItemCommandValidator : AbstractValidator<CreateDeviceItemCommand>
    {
        public CreateDeviceItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();

        }
    }
}
