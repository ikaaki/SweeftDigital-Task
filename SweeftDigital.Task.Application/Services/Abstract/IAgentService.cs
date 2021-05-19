using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.Abstract
{
    public interface IAgentService
    {
        Task<int> AddAgent(AgentDTO agentDTO);
        System.Threading.Tasks.Task RemoveAgentAsync(int agentId);
    }
}
