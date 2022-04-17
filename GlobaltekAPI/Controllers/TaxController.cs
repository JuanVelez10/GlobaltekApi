using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxServices taxServices;

        public TaxController(ITaxServices taxServices)
        {
            this.taxServices = taxServices;
        }

        // GET: api/<TaxController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var response = await taxServices.GetAllTaxes();
            if (response.Any()) return Ok(response);
            return NotFound(response);
        }

    }
}
