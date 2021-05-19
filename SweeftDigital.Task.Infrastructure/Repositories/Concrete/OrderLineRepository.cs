﻿using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure.Repositories.Concrete
{
    public class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(SweeftDigitalTaskDbContext context) : base(context)
        {
        }
    }
}
