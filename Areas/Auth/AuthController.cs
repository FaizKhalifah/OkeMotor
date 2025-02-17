using Microsoft.AspNetCore.Mvc;
using OkeMotor.Areas.Auth.Services;
using OkeMotor.Areas.Auth.ViewModels;

namespace OkeMotor.Areas.Auth
{
    [Area("Auth")]
    [Route("Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            authRepository = _authRepository;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var response = await _authRepository.RegisterAsync(model);
            if (response) return RedirectToAction("Login");

            ModelState.AddModelError("", "Registration failed.");
            return View(model);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authRepository.LoginAsync(model);
            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
