using PR_ERP_WebAPI.Domain.DTO.Order;
using PR_ERP_WebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_ERP_WebAPI.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        Task<OrderDTO> CreateAsync(CreateOrderDTO createOrderDTO);
        Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO);
        Task<OrderDTO> DeleteAsync(int id);
    }
}
