using Microsoft.AspNetCore.Identity;
using OkeMotor.Areas.Auth.Model;
using OkeMotor.Areas.Auth.ViewModels;
using OkeMotor.Models.Entities;
using OkeMotor.Utilites;

namespace OkeMotor.Areas.Auth.Services
{
    public class AuthRepository:IAuthRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) { 
            _signInManager = signInManager;
            _userManager = userManager; 
        }

        public async Task<bool> RegisterAsync(RegisterViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Password) || string.IsNullOrEmpty(viewModel.Role))
            {
                throw new ArgumentNullException(nameof(viewModel.Role), "Role cannot be null.");
            }

            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                Role=viewModel.Role,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user,viewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error.Description}");
                }
                return false;
            }
            //await _userManager.AddToRoleAsync(user, "Pembeli");
            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(LoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user, 
                viewModel.Password, viewModel.RememberMe, false);
            if (!result.Succeeded)
            {
                return false;
            }
            var token = JwtHelper.GenerateJwtToken(user, _config);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
