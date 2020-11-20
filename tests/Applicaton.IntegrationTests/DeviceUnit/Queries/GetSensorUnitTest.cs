using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SoIoT.Application.DeviceUnit.Command;
using SoIoT.Application.DeviceUnit.Queries;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.IntegrationTests.DeviceUnit.Queries
{
    using static Testing;
    public class GetSensorUnitTest : TestBase
    {
        [Test]
        public async Task ShouldGetAndCreateDeviceUnitItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var getDeviceUnitQuery = new GetDeviceUnitQuery()
            {
                DeviceUnitName = "Celcius",
                DeviceUnitString = "C"
            };

            var deviceUnit = await SendAsync(getDeviceUnitQuery);
            var item = await FindAsync<SensorUnit>(deviceUnit.Id);

            item.Name.Should().NotBeNullOrEmpty();
            item.Name.Should().Be("Celcius");

            var deviceUnit2 = await SendAsync(getDeviceUnitQuery);
            deviceUnit2.Id.Should().Be(item.Id); 
        }
    }
}
