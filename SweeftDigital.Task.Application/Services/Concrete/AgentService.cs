using SweeftDigital.Task.Application.Services.Abstract;
using SweeftDigital.Task.Application.Services.DataModels;
using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.Concrete
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<int> AddAgent(AgentDTO agentDTO)
        {
            var agent = new Agent
            {
                FirstName = agentDTO.FirstName,
                LastName = agentDTO.LastName,
                ParentId = agentDTO.ParentId,
                PersonalNumber = agentDTO.PersonalNumber
            };

            await _agentRepository.AddAsync(agent);
            await _agentRepository.SaveChangesAsync();

            return agent.Id;
        }

        public async System.Threading.Tasks.Task RemoveAgentAsync(int agentId)
        {
            var agent = await _agentRepository.FindByIdAsync(agentId);

            while(agent != null)
            {
                agent.DateDeleted = DateTime.UtcNow;

                _agentRepository.Update(agent);

                agent = agent.Child;
            }
            
            await _agentRepository.SaveChangesAsync();

        }
    }
}
