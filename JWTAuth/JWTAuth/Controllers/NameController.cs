using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "naimesh", "jaith" };
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id) 
        {
            return "value";
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token=_jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token==null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        // POST api/<NameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }

}
