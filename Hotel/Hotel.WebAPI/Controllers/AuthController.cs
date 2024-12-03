using AutoMapper;
using Hotel.BL.Auth;
using Hotel.BL.Auth.Entities;
using Hotel.BL.User.Entities;
using Hotel.WebAPI.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Hotel.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;
        private readonly IMapper _mapper;

        public AuthController(IAuthProvider authProvider, IMapper mapper)
        {
            _authProvider = authProvider;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("login")] //.../auth/login
        public async Task<IActionResult> LoginUser([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                var tokens = await _authProvider.AuthorizeUser(email, password);

                return Ok(tokens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(string surname, string name, string patronymic, DateTime birthday,
            string phoneNumber, string imageUrl, string email, string password)
        {
            try
            {
                await _authProvider.RegisterUser(surname,name,patronymic,birthday,phoneNumber,imageUrl,email,password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
