using Axiom.Anamnese.Web.Models.DTOs;
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

        public async Task<ResponseDTO?> GetAllPersonsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.PersonAPIBase + "/api/person"
            });
        }
    }
}
