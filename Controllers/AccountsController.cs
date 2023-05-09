using Microsoft.AspNetCore.Mvc;
using ThienAspWebApi.Repository.Interface;
using ThienAspWebApi.ViewModels;

namespace ThienAspWebApi.Controllers
{
    [Route("/api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody]RegisterModel registerModel)
        {
            var result = await _accountRepo.RegisterAsync(registerModel);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return Ok(result.Succeeded);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            var result = await _accountRepo.LoginAsync(loginModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
