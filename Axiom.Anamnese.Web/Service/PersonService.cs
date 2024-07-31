using Axiom.Anamnese.Web.Models.DTOs;
using Axiom.Anamnese.Web.Service.IService;
using Axiom.Anamnese.Web.Utils;
using Axiom.Services.PersonAPI.Models.DTOs;

namespace Axiom.Anamnese.Web.Service
{
    public class PersonService : IPersonService
    {
        private readonly IBaseService _baseService;

        public PersonService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreatePersonAsync(PersonDTO person)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = person,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }

        public async Task<ResponseDTO?> DeletePersonAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.PersonAPIBase + $"/api/person/{id}"
            });
        }

        public async Task<ResponseDTO?> GetAllPersonsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }

        public async Task<ResponseDTO?> GetPersonByIdAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.PersonAPIBase + $"/api/person/{id}"
            });
        }

        public async Task<ResponseDTO?> GetPersonsByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = name,
                Url = StaticDetails.PersonAPIBase + $"/api/person/GetPersonsByName"
            });
        }

        public async Task<ResponseDTO?> UpdatePersonAsync(PersonDTO person)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = person,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }
    }
}
