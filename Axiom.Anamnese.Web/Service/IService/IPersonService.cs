using Axiom.Anamnese.Web.Models.Dto;

namespace Axiom.Anamnese.Web.Service.IService
{
    public interface IPersonService
    {
        Task<ResponseDto?> GetAllPersonsAsync();
        Task<ResponseDto?> GetPersonsByNameAsync(string name);
        Task<ResponseDto?> GetPersonByIdAsync(long id);
        Task<ResponseDto?> CreatePersonAsync(PersonDto person);
        Task<ResponseDto?> UpdatePersonAsync(PersonDto person);
        Task<ResponseDto?> DeletePersonAsync(long id);
    }
}