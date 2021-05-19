using FluentValidation;
using SweeftDigital.Task.API.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Validators.Products
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(request => request.Product)
                .NotEmpty()
                .NotNull()
                .SetValidator(new ProductDTOValidator());
        }
    }
}
