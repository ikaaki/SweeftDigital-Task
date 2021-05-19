using FluentValidation;
using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Orders
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(dto => dto.AgentId)
                .NotNull()
                .NotEmpty();

            RuleFor(dto => dto.OrderLines)
                .NotNull()
                .NotEmpty();

            RuleForEach(dto => dto.OrderLines)
                .SetValidator(new OrderLineDTOValidator());
        }
    }
}
