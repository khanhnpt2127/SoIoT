using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoIoT.Application.ThingsDesc.Commands;
using SoIoT.Application.ThingsDesc.Queries;

namespace SoIoT.WebUI.Controllers
{
    public class ThingsDescController : ApiController 
    {
        [HttpGet()]
        public async Task<ActionResult<ThingsDescVm>> Get()
        {
            return await Mediator.Send(new GetThingsDescQuery());
        }


        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateThingsDescCommand command)
        {
            return await Mediator.Send(command);
        }


    }
}
