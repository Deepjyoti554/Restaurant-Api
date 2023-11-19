using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.StaffModel;
using RestaurantApi.Services.CustomerService;
using RestaurantApi.Services.StaffService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService staffService;

        public StaffController(IStaffService staffService) {  
            this.staffService = staffService;
        }    

        // GET: api/<StaffController>
        [HttpGet]
        public ActionResult<List<Staff>> Get()
        {
            return staffService.Get();
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public ActionResult<Staff> Get(string id)
        {
            var staff = staffService.Get(id);

            if (staff == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            return staff;
        }

        // POST api/<StaffController>
        [HttpPost]
        public ActionResult<Staff> Post([FromBody] Staff staff)
        {
            staff.Id = ObjectId.GenerateNewId().ToString();
            staff.Customers.Id = ObjectId.GenerateNewId().ToString();
            staffService.Create(staff);
            return CreatedAtAction(nameof(Get), new { id = staff.Id }, staff);
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Staff staff)
        {
            var existingStaff = staffService.Get(id);
            if (existingStaff == null)
            {
                return NotFound($"Student id: {id} not found");
            }
            staffService.Update(id, staff);
            return NoContent();
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var order = staffService.Get(id);

            if (order == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            staffService.Remove(order.Id);
            return Ok($"Student with id {id} deleted");
        }
    }
}
