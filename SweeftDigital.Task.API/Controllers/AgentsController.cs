using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Task.API.Models.Agents;
using SweeftDigital.Task.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentsController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAgentRequest request)
        {
            var id = await _agentService.AddAgent(request.Agent);

            return Ok(new
            {
                Data = id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _agentService.RemoveAgentAsync(id);

            return Ok();
        }
    }
}
