using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Services.CustomerService;
using RestaurantApi.Services.OrderService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService) {
            this.customerService = customerService;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerService.Get();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Customer customer)
        {
            customer.Id = ObjectId.GenerateNewId().ToString();
            customerService.Create(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Customer customer)
        {
            var existingCustomer = customerService.Get(id);
            if (existingCustomer == null)
            {
                return NotFound($"Student id: {id} not found");
            }
            customerService.Update(id, customer);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var order = customerService.Get(id);

            if (order == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            customerService.Remove(order.CustomerId);
            return Ok($"Student with id {id} deleted");
        }
    }
}
