using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SoIoT.Application.DeviceLogs.Queries;
using SoIoT.Application.Devices.Commands.CreateDeviceItem;
using SoIoT.Application.Devices.Queries.GetDevices;
using SoIoT.Application.DeviceSingleLogs.Queries;
using SoIoT.Application.DeviceThingDesc.Queries;
using SoIoT.Application.TodoItems.Commands.CreateTodoItem;
using SoIoT.Domain.Entities;
using SoIoT.Domain.Entities.RequestBody;

namespace SoIoT.WebUI.Controllers
{
    
    public class DevicesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateDeviceItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<DevicesVm>> Get()
        {
            return await Mediator.Send(new GetDevicesQuery());
        }


        [HttpGet("AllLog/{sensorId}")]
        public async Task<ActionResult<DeviceLogsVm>> GetDeviceLog(string sensorId)
        {
            return await Mediator.Send(new GetDeviceLogQuery { SensorId = sensorId });
        }


        [HttpGet("{sensorId}")]
        public async Task<ActionResult<DeviceSingleLogsVm>> GetSingleDeviceLog(string sensorId)
        {
            return await Mediator.Send(new GetSingleDeviceLogQuery { SensorId = sensorId });
        }


        [HttpGet("{sensorId}/thingdesc")]
        public async Task<ActionResult> GetDeviceThingsDesc(string sensorId)
        {
            var res = await Mediator.Send(new GetDeviceThingsDescQuery {DeviceId = sensorId});
            
            return Content(res.ThingsDesc.Value, "application/json");
        } 

        [HttpPut("{sensorId}/lights/{lightId}/state")]
        public async Task<ActionResult<string>> ChangeHueWhiteLampState (string sensorId, string lightId, [FromBody] HueWhiteLamp content)
        {
            //TODO: validate a data

            // TODO: call to change state


            return "ok";
        } 
        




    }
}
