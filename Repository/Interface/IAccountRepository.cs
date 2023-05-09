using Microsoft.AspNetCore.Identity;
using ThienAspWebApi.ViewModels;

namespace ThienAspWebApi.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterAsync(RegisterModel registerModel);
        Task<string> LoginAsync(LoginModel loginModel);

    }
}
