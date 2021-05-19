using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.DataModels
{
    public class OrderDTO
    {
        public int AgentId { get; set; }
        public List<OrderLineDTO> OrderLines{ get; set; }
    }
}
