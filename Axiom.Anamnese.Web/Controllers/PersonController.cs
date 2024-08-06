using Axiom.Anamnese.Web.Models.Dto;
using Axiom.Anamnese.Web.Service.IService;
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
            List<PersonDto>? list = new();
            ResponseDto? response = await _personService.GetAllPersonsAsync();

            if (response != null && response.Success)
            {
                list = JsonConvert.DeserializeObject<List<PersonDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
                return RedirectToAction("Index", "Home");
            }

            return View(list);
        }

        public async Task<IActionResult> PersonSearch(string name)
        {
            List<PersonDto>? list = new();
            ResponseDto? response;

            if (string.IsNullOrEmpty(name))
            {
                response = await _personService.GetAllPersonsAsync();
            }
            else
            {
                response = await _personService.GetPersonsByNameAsync(name);
            }

            if (response != null && response.Success)
            {
                list = JsonConvert.DeserializeObject<List<PersonDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return PartialView("_PersonList", list);
        }

        public async Task<IActionResult> PersonCreate()
        {
            return await Task.FromResult(View(nameof(PersonCreate)));
        }

        [HttpPost]
        public async Task<IActionResult> PersonCreate(PersonDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _personService.CreatePersonAsync(model);

                if (response != null && response.Success)
                {
                    TempData["success"] = "Paciente Criado!";
                    return RedirectToAction(nameof(PersonIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> PersonEdit(long personId)
        {
            ResponseDto? response = await _personService.GetPersonByIdAsync(personId);

            if (response != null && response.Success)
            {
                PersonDto? person = JsonConvert.DeserializeObject<PersonDto>(Convert.ToString(response.Result));
                return View(person);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PersonEdit(PersonDto person)
        {
            ResponseDto? response = await _personService.UpdatePersonAsync(person);

            if (response != null && response.Success)
            {
                TempData["success"] = "Alterações Salvas!";

                return RedirectToAction(nameof(PersonIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(person);
        }

        public async Task<IActionResult> PersonDelete(long personId)
        {
            ResponseDto? response = await _personService.GetPersonByIdAsync(personId);

            if (response != null && response.Success)
            {
                PersonDto? person = JsonConvert.DeserializeObject<PersonDto>(Convert.ToString(response.Result));
                return View(person);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PersonDelete(PersonDto person)
        {
            ResponseDto? response = await _personService.DeletePersonAsync(person.PersonId);

            if (response != null && response.Success)
            {
                TempData["success"] = "Paciente deletado!";

                return RedirectToAction(nameof(PersonIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(person);
        }
    }
}