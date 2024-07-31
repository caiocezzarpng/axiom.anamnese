using Axiom.Anamnese.Web.Models.DTOs;
using Axiom.Services.PersonAPI.Models.DTOs;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IPersonService
    {
        Task<ResponseDTO?> GetAllPersonsAsync();
        Task<ResponseDTO?> GetPersonsByNameAsync(string name);
        Task<ResponseDTO?> GetPersonByIdAsync(long id);
        Task<ResponseDTO?> CreatePersonAsync(PersonDTO person);
        Task<ResponseDTO?> UpdatePersonAsync(PersonDTO person);
        Task<ResponseDTO?> DeletePersonAsync(long id);
    }
}