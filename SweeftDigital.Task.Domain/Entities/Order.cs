using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int AgentId { get; set; }
        public bool IsApproved { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public void ApplayTotalPrice()
        {
            TotalPrice = OrderLines.Sum(ol => ol.TotalPrice);
        }
    }

}
