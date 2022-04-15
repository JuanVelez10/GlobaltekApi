using Api.Extensions;
using Api.References;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices personService;
        private readonly IConfiguration config;
        private ConfigExtensions configExtensions;

        public PersonController(IPersonServices personService, IConfiguration config)
        {
            this.personService = personService;
            this.config = config;
            this.configExtensions = new ConfigExtensions();
        }


        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Client")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // GET api/<AccountController>
        //Method to get a specific logged account
        [HttpGet]
        [Route("Logged")]
        [Authorize(Roles = "Admin,Client")]
        public IActionResult Logged()
        {
            string srtoken = string.Empty;

            configExtensions.TryRetrieveToken(Request, out srtoken);

            var person = configExtensions.GetToken(srtoken);
            if (person != null && !string.IsNullOrEmpty(person.Email)) person = personService.GetPersonForId(person.Id).Result;

            if (person != null && !string.IsNullOrEmpty(person.Email)) return Ok(person);
            return NotFound(null);
        }

        // POST api/<AccountController>
        //In this method an account is validated for login and a jwt token is generated
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            var response = await Task.Run(() =>
            {
                return personService.GetPersonLogin(loginRequest.Email, loginRequest.Password).Result;
            });

            if (response != null && response.Data != null)
            {
                response.Data.Token = configExtensions.Generate(config, response.Data.person);
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
