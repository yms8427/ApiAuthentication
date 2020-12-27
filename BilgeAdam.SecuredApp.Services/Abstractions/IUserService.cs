using BilgeAdam.SecuredApp.Services.Contracts;

namespace BilgeAdam.SecuredApp.Services.Abstractions
{
    public interface IUserService
    {
        bool Register(RegisterDto data);

        UserInfoDto Login(string userName, string password);
    }
}