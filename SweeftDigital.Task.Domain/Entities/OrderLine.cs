using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Domain.Entities
{
    public class OrderLine : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
