using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Services.OrderService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService) {
            this.orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderService.Get();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = orderService.Get(id);
            if (order == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Order order)
        {
            var existigOrder = orderService.Get(id);
            if (existigOrder == null)
            {
                return NotFound($"Student id: {id} not found");
            }
            orderService.Update(id, order);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var order = orderService.Get(id);

            if (order == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            orderService.Remove(order.Id);
            return Ok($"Student with id {id} deleted");
        }
    }
}
