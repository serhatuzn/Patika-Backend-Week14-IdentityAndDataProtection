using System.ComponentModel;
using Identity_and_Data_Protection.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Identity_and_Data_Protection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registermodel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registermodel.Email,
                    Email = registermodel.Email
                };

                var result = await _userManager.CreateAsync(user, registermodel.Password); // kullanıcı oluşturulur

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false); // eğer kullanıcı oluşturulduysa oturum açar ve kullanıcıyı sisteme dahil eder
                    return Ok( new { messasge = "Kullanıcı Oluşturuldu" });
                }
                else 
                {
                    return BadRequest(new { errors = result.Errors.Select(e => e.Description) }); // hata mesajlarını döndürür
                }
            }
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(s => s.ErrorMessage) });
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Giriş Başarılı" });
                }

                return BadRequest(new { errors = "Kuulanıcı adı veya şifre hatalı." });
            }

            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
        }
    }
}
