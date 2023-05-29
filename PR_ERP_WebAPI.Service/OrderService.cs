using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PR_ERP_WebAPI.Domain.Data;
using PR_ERP_WebAPI.Domain.DTO.Order;
using PR_ERP_WebAPI.Domain.Entity;
using PR_ERP_WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_ERP_WebAPI.Service
{
    public class OrderService : IOrderRepository
    {
        private readonly PRERP_APIDbContext context;
        private readonly IMapper mapper;

        public OrderService(PRERP_APIDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> CreateAsync(CreateOrderDTO createOrderDTO)
        {
            var mappedOrder = mapper.Map<Order>(createOrderDTO);

            if (mappedOrder == null)
            {
                throw new Exception("Order Not Found");
            }

            mappedOrder.TotalPrice = (mappedOrder.UnitPrice * mappedOrder.Quantity) - Convert.ToDecimal(mappedOrder.Discount);
            var submittedOrder = await context.Orders.AddAsync(mappedOrder);
            await context.SaveChangesAsync();

            var orderDTO = mapper.Map<OrderDTO>(submittedOrder.Entity);

            return orderDTO;
        }

        public async Task<OrderDTO> DeleteAsync(int id)
        {
            var findOrderById = await context.Orders.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

            if (findOrderById == null)
            {
                throw new Exception("Order Not Found");
            }

            context.Remove(findOrderById);
            await context.SaveChangesAsync();

            var orderDTO = mapper.Map<OrderDTO>(findOrderById);

            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var getAll = await context.Orders.AsNoTracking().Where(x => x.IsActive == true).ToListAsync();

            if (getAll == null)
            {
                throw new Exception("Order Not Found");
            }

            var mappedAllOrder = mapper.Map<IEnumerable<OrderDTO>>(getAll);

            return mappedAllOrder;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var findOrderById = await context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

            if (findOrderById == null)
            {
                throw new Exception("Order Not Found");
            }

            var mappedOrderDTO = mapper.Map<OrderDTO>(findOrderById);

            return mappedOrderDTO;
        }

        public async Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO)
        {
            var findOrderById = await context.Orders.FirstOrDefaultAsync(x => x.Id == updateOrderDTO.Id && x.IsActive == true);

            if (findOrderById == null)
            {
                throw new Exception("Order Not Found");
            }

            var mappedOrder = mapper.Map<Order>(updateOrderDTO);

            if (mappedOrder == null)
            {
                throw new Exception("Order Not Found");
            }
            mappedOrder.TotalPrice = (mappedOrder.UnitPrice * mappedOrder.Quantity) - Convert.ToDecimal(mappedOrder.Discount);
            context.Entry(findOrderById).CurrentValues.SetValues(mappedOrder);
            await context.SaveChangesAsync();

            var getOrderById = findOrderById;

            var orderDTO = mapper.Map<OrderDTO>(getOrderById);

            return orderDTO;
        }
    }
}
