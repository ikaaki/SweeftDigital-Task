using FluentValidation;
using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Agents
{
    public class AgentDTOValidator : AbstractValidator<AgentDTO>
    {
        public AgentDTOValidator()
        {
            RuleFor(dto => dto.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(dto => dto.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(dto => dto.PersonalNumber)
                .NotNull()
                .NotEmpty()
                .MaximumLength(11)
                .Matches(new Regex("^\\d{11}$"))
                .WithMessage("Invalid format");
        }
    }
}
