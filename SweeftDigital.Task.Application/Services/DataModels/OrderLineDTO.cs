using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.DataModels
{
    public class OrderLineDTO
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
