using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                .Include(o => o.Customer)
                .ToListAsync();

            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var order = await _context.Orders
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                .Include(o => o.Customer)
                .SingleOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            FixOrder(order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(string id, Order order)
        {
            if (id != order.OrderId)
                return BadRequest();

            FixOrder(order);

            // 删除旧订单及其明细
            var existing = await _context.Orders
                .Include(o => o.Details)
                .SingleOrDefaultAsync(o => o.OrderId == id);
            if (existing != null)
            {
                _context.OrderDetails.RemoveRange(existing.Details);
                _context.Orders.Remove(existing);
            }

            // 添加新订单
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var order = await _context.Orders
                .Include(o => o.Details)
                .SingleOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            _context.OrderDetails.RemoveRange(order.Details);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 避免级联插入/更新 Customer 和 Product
        private void FixOrder(Order order)
        {
            order.CustomerId = order.Customer.Id;
            order.Customer = null;
            foreach (var d in order.Details)
            {
                d.ProductId = d.Product.Id;
                d.Product = null;
            }
        }
    }
}
