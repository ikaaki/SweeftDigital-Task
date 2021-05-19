using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Models.Products
{
    public class CreateProductRequest
    {
        public ProductDTO Product { get; set; }
    }
}
