using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SoIoT.Application.Devices.Queries.GetDevices;

namespace SoIoT.Application.IntegrationTests.Devices.Queries
{

    using static Testing;
    public class GetDevicesTest : TestBase
    {
        [Test]
        public async Task ShouldNotReturnNull()
        {
            var query = new GetDevicesQuery();
            var result = await SendAsync(query);
            result.Lists.Should().NotBeNull();
        }


    }
}
