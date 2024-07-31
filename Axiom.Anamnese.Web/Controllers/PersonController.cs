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
                return RedirectToAction("Index", "Home");
            }

            return View(list);
        }

        public async Task<IActionResult> PersonSearch(string name)
        {
            List<PersonDTO>? list = new();
            ResponseDTO? response;

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
                list = JsonConvert.DeserializeObject<List<PersonDTO>>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> PersonCreate(PersonDTO model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? response = await _personService.CreatePersonAsync(model);

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
            ResponseDTO? response = await _personService.GetPersonByIdAsync(personId);

            if (response != null && response.Success)
            {
                PersonDTO? person = JsonConvert.DeserializeObject<PersonDTO>(Convert.ToString(response.Result));
                return View(person);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PersonEdit(PersonDTO person)
        {
            ResponseDTO? response = await _personService.UpdatePersonAsync(person);

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
            ResponseDTO? response = await _personService.GetPersonByIdAsync(personId);

            if (response != null && response.Success)
            {
                PersonDTO? person = JsonConvert.DeserializeObject<PersonDTO>(Convert.ToString(response.Result));
                return View(person);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PersonDelete(PersonDTO person)
        {
            ResponseDTO? response = await _personService.DeletePersonAsync(person.PersonId);

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