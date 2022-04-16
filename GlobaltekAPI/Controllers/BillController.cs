using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var bills = await billService.GetAllBillBasic();
            if (bills.Any()) return Ok(bills);
            return NotFound(bills);
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Client")]
        public async Task<IActionResult> Get(Guid? id)
        {
            var bill = await billService.GetBill(id);
            if (bill != null) return Ok(bill);
            return NotFound(bill);
        }

        // POST api/<BillController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
        }
    }
}
