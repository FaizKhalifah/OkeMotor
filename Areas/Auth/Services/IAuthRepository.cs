using OkeMotor.Areas.Auth.Model;
using OkeMotor.Areas.Auth.ViewModels;

namespace OkeMotor.Areas.Auth.Services
{
    public interface IAuthRepository
    {
        Task<bool>RegisterAsync(RegisterViewModel viewModel);
        Task<bool>LoginAsync(LoginViewModel viewModel);

        Task LogoutAsync();
    }
}
