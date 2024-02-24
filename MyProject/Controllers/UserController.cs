using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MyProject.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
                _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var res =await _userService.Register(model);
            return Ok(res);
        }
    }
}
