using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.ManagerModel;
using RestaurantApi.Services.CustomerService;
using RestaurantApi.Services.ManagerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService managerService;

        public ManagerController(IManagerService managerService) {
            this.managerService = managerService;
        }


        // GET: api/<ManagerController>
        [HttpGet]
        public ActionResult<List<Manager>> Get()
        {
            return managerService.Get();
        }

        // GET api/<ManagerController>/5
        [HttpGet("{id}")]
        public ActionResult<Manager> Get(string id)
        {
            var manager = managerService.Get(id);

            if (manager == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            return manager;
        }

        // POST api/<ManagerController>
        [HttpPost]
        public ActionResult<Manager> Post([FromBody] Manager manager)
        {
            manager.Id = ObjectId.GenerateNewId().ToString();
            managerService.Create(manager);
            return CreatedAtAction(nameof(Get), new { id = manager.Id }, manager);
        }

        // PUT api/<ManagerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Manager manager)
        {
            var existingManager = managerService.Get(id);
            if (existingManager == null)
            {
                return NotFound($"Student id: {id} not found");
            }
            managerService.Update(id, manager);
            return NoContent();
        }

        // DELETE api/<ManagerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var manager = managerService.Get(id);

            if (manager == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            managerService.Remove(manager.Id);
            return Ok($"Student with id {id} deleted");
        }
    }
}
