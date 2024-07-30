using Axiom.Anamnese.Web.Models.DTOs;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IPersonService
    {
        Task<ResponseDTO?> GetAllPersonsAsync();
    }
}
