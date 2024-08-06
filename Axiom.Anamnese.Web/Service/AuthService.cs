using Axiom.Anamnese.Web.Models.Dto;
using Axiom.Anamnese.Web.Service.IService;
using Axiom.Anamnese.Web.Utils;

namespace Axiom.Anamnese.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = registrationRequestDTO,
                Url = StaticDetails.AuthAPIBase + "/api/auth/AssignRole"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = loginRequestDTO,
                Url = StaticDetails.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = registrationRequestDTO,
                Url = StaticDetails.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}