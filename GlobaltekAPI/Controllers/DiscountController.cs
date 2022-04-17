using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices discountServices;

        public DiscountController(IDiscountServices discountServices)
        {
            this.discountServices = discountServices;
        }

        // GET: api/<DiscountController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await discountServices.GetAllDiscounts();
            if (response.Any()) return Ok(response);
            return NotFound(response);
        }

    }
}
