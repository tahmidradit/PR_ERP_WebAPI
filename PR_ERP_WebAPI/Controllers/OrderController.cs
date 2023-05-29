using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR_ERP_WebAPI.Domain.DTO.Order;
using PR_ERP_WebAPI.Repository;

namespace PR_ERP_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await orderRepository.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var getById = await orderRepository.GetByIdAsync(id);
            return Ok(getById);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDTO createOrderDTO)
        {
            var createOrder = await orderRepository.CreateAsync(createOrderDTO);
            return Ok(createOrder);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDTO updateOrderDTO)
        {
            var updateOrder = await orderRepository.UpdateAsync(updateOrderDTO);
            return Ok(updateOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var delete = await orderRepository.DeleteAsync(id);
            return Ok(delete);
        }
    }
}
