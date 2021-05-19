using FluentValidation;
using SweeftDigital.Task.API.Models.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Agents
{
    public class CreateAgentRequestValidator : AbstractValidator<CreateAgentRequest>
    {
        public CreateAgentRequestValidator()
        {
            RuleFor(request => request.Agent)
                .NotEmpty()
                .NotNull()
                .SetValidator(new AgentDTOValidator());
        }
    }
}
