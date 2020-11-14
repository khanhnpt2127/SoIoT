using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Application.Common.Interfaces;

namespace SoIoT.Infrastructure.Services
{
    public class RandomService : IRandomService
    {
        private static readonly Random _random = new Random();

        public double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = _random.NextDouble(); 
            return minValue + (next * (maxValue - minValue));
        }
    }
}
