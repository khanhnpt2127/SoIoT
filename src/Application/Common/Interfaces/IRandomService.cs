using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Application.Common.Interfaces
{
    public interface IRandomService
    {
        double RandomNumberBetween(double minValue, double maxValue);
    }
}
