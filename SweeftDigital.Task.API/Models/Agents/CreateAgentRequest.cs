using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Models.Agents
{
    public class CreateAgentRequest
    {
        public AgentDTO Agent { get; set; }
    }
}
