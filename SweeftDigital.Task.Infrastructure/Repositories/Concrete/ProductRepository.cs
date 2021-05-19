using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SweeftDigitalTaskDbContext context) : base(context)
        {
        }

        public async System.Threading.Tasks.Task DecreaseStockAsync(int productId, decimal quantity)
        {
            var product = await FindByIdAsync(productId);

            if (product == null)
            {
                throw new Exception($"Product not found: id={productId}");
            }

            if (!CheckStock(product, quantity))
            {
                throw new Exception($"Invalid stock update: id={productId}; quantity={quantity}");
            }

            product.Stock -= quantity;

            Update(product);
        }

        public bool CheckStock(Product product, decimal quantity)
        {
            return product?.Stock >= quantity;
        }

        public async Task<bool> CheckStockAsync(int productId, decimal quantity)
        {
            var product = await FindByIdAsync(productId);

            return CheckStock(product, quantity);
        }
    }
}
