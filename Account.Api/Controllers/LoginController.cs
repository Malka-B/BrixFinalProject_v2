using Account.Service.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Account.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("login")]
        public async Task<ActionResult<Guid>> LoginAsync([FromQuery] string email, string password)
        {
            Guid accountId = await _loginService.LoginAsync(email, password);
            if (accountId != default(Guid))
            {
                return Ok(accountId);
            }
            return Unauthorized();
        }
    }
}
