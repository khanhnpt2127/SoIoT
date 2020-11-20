using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SoIoT.Application.DeviceUnit.Command
{
    public class CreateDeviceUnitCommandValidator : AbstractValidator<CreateDeviceUnitCommand>
    {
        public CreateDeviceUnitCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name should not be empty");
        }
    }

}
