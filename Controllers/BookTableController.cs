using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Services.BookTableService;
using RestaurantApi.Services.OrderService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTableController : ControllerBase
    {
        private readonly IBookTableService bookTableService;

        public BookTableController(IBookTableService bookTableService) {
            this.bookTableService = bookTableService;
        }


        // GET: api/<BookTableController>
        [HttpGet]
        public ActionResult<List<BookTable>> Get()
        {
            return bookTableService.Get();
        }

        // GET api/<BookTableController>/5
        [HttpGet("{id}")]
        public ActionResult<BookTable> Get(string id)
        {
            var table = bookTableService.Get(id);
            if (table == null)
            {
                return NotFound($"Student id: {id} not found");
    }

            return table;
        }

        // POST api/<BookTableController>
        [HttpPost]
        public ActionResult<BookTable> Post([FromBody] BookTable table)
        {
            bookTableService.Create(table);
            return CreatedAtAction(nameof(Get), new { id = table.Id }, table);
        }

        // PUT api/<BookTableController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] BookTable table)
        {
            var existigTable = bookTableService.Get(id);
            if (existigTable == null)
            {
                return NotFound($"Student id: {id} not found");
            }
            bookTableService.Update(id, table);
            return NoContent();
        }

        // DELETE api/<BookTableController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var table = bookTableService.Get(id);

            if (table == null)
            {
                return NotFound($"Student id: {id} not found");
            }

            bookTableService.Remove(table.Id);
            return Ok($"Student with id {id} deleted");
        }
    }
}
