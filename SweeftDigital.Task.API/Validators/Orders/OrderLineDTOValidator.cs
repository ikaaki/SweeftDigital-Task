using FluentValidation;
using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Orders
{
    public class OrderLineDTOValidator : AbstractValidator<OrderLineDTO>
    {
        public OrderLineDTOValidator()
        {
            RuleFor(dto => dto.ProductId)
                .NotNull()
                .NotEmpty();

            RuleFor(dto => dto.Quantity)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
