using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RecipeSharing.Server.Models;

namespace RecipeSharing.Server.Controllers
{
    [Route("api/[AuthController]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser>? _userManager;
        private readonly SignInManager<ApplicationUser>? _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "ユーザーの登録に成功しました。" });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(new { message = "ログインに成功しました。" });
            }
            else
            {
                return Unauthorized(new {message = "ログインに失敗しました。"});
            }
        }
    }
}