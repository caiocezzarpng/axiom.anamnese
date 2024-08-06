using Axiom.Anamnese.Web.Models.Dto;
using Axiom.Anamnese.Web.Service.IService;
using Axiom.Anamnese.Web.Utils;

namespace Axiom.Anamnese.Web.Service
{
    public class PersonService : IPersonService
    {
        private readonly IBaseService _baseService;

        public PersonService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreatePersonAsync(PersonDto person)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = person,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }

        public async Task<ResponseDto?> DeletePersonAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.PersonAPIBase + $"/api/person/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllPersonsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }

        public async Task<ResponseDto?> GetPersonByIdAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.PersonAPIBase + $"/api/person/{id}"
            });
        }

        public async Task<ResponseDto?> GetPersonsByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = name,
                Url = StaticDetails.PersonAPIBase + $"/api/person/GetPersonsByName"
            });
        }

        public async Task<ResponseDto?> UpdatePersonAsync(PersonDto person)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = person,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }
    }
}
