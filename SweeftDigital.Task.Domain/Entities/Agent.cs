using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Domain.Entities
{
    public class Agent : BaseEntity
    {
        public int? ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual Agent Parent { get; set; }
        public virtual Agent Child { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
