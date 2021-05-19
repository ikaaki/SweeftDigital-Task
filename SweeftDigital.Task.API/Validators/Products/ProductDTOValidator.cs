using FluentValidation;
using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Products
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(dto => dto.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
