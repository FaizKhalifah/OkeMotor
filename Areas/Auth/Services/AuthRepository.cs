using Microsoft.AspNetCore.Identity;
using OkeMotor.Areas.Auth.ViewModels;
using OkeMotor.Models.Entities;

namespace OkeMotor.Areas.Auth.Services
{
    public class AuthRepository:IAuthRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) { 
            _signInManager = signInManager;
            _userManager = userManager; 
        }

        public async Task<bool> RegisterAsync(RegisterViewModel viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user,viewModel.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            await _userManager.AddToRoleAsync(user, "Pembeli");
            return true;
        }

        public async Task<string?> LoginAsync(LoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(user, 
                viewModel.Password, viewModel.RememberMe, false);
            if (!result.Succeeded)
            {
                return null;
            }
            return user.Email;
        }
    }
}
