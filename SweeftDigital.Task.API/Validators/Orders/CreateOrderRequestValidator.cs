using FluentValidation;
using SweeftDigital.Task.API.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Orders
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(request => request.Order)
                .NotEmpty()
                .NotNull()
                .SetValidator(new OrderDTOValidator());
        }
    }
}
