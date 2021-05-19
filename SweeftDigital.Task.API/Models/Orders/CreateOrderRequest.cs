using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Models.Orders
{
    public class CreateOrderRequest
    {
        public OrderDTO Order { get; set; }
    }
}
