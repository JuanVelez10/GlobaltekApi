using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillServices billService;

        public BillController(IBillServices billService)
        {
            this.billService = billService;
        }

        // GET: api/<BillController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bills = await Task.Run(() =>
            {
                return billService.GetAllBill().Result;
            });

            if (bills.Any()) return Ok(bills);
            return NotFound(bills);
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BillController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
