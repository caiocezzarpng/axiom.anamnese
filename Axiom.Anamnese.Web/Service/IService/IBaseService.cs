using Axiom.Anamnese.Web.Models.DTOs;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBearer = true);
    }
}