using Axiom.Anamnese.Web.Models.Dto;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDTO);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDTO);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDTO);
    }
}