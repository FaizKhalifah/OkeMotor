using OkeMotor.Areas.Auth.ViewModels;

namespace OkeMotor.Areas.Auth.Services
{
    public interface IAuthRepository
    {
        Task<bool>RegisterAsync(RegisterViewModel viewModel);
        Task<string?>LoginAsync(LoginViewModel viewModel);
    }
}
