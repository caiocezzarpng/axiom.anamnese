using Axiom.Anamnese.Web.Models.DTOs;
using Axiom.Anamnese.Web.Service.IService;
using Axiom.Services.PersonAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Axiom.Anamnese.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> PersonIndex()
        {
            List<PersonDTO>? list = new();
            ResponseDTO? response = await _personService.GetAllPersonsAsync();

            if (response != null && response.Success)
            {
                list = JsonConvert.DeserializeObject<List<PersonDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
    }
}