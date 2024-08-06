using Axiom.Anamnese.Web.Models.Dto;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDTO, bool withBearer = true);
    }
}