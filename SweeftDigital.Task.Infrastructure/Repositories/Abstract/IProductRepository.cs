using SweeftDigital.Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        System.Threading.Tasks.Task DecreaseStockAsync(int productId, decimal quantity);

        Task<bool> CheckStockAsync(int productId, decimal quantity);
    }
}
