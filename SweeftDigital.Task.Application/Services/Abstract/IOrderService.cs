using SweeftDigital.Task.Application.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.Abstract
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(OrderDTO orderDTO);

        System.Threading.Tasks.Task ApproveOrderAsync(int orderId);
    }
}
