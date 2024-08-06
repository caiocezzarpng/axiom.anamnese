using Axiom.Services.AuthAPI.Models.Dto;

namespace Axiom.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDTO);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO);

        Task<bool> AssignRole(string email, string roleName);
    }
}
