using AutoMapper;
using Axiom.Services.PersonAPI.Data;
using Axiom.Services.PersonAPI.Models;
using Axiom.Services.PersonAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Axiom.Services.PersonAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    [Authorize]
    public class PersonAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public PersonAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                var objList = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).ToList();
                _response.Result = _mapper.Map<IEnumerable<PersonDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id:long}")]
        public ResponseDTO Get(long id)
        {
            try
            {
                var obj = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).FirstOrDefault(u => u.PersonId == id);
                _response.Result = _mapper.Map<PersonDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost("GetPersonsByName")]
        public ResponseDTO GetPersonsByName([FromBody] string name)
        {
            try
            {
                var objList = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).Where(u => u.Name.Contains(name)).ToList();
                _response.Result = _mapper.Map<IEnumerable<PersonDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public ResponseDTO Post([FromBody] PersonDTO personDTO)
        {
            try
            {
                var person = _mapper.Map<Person>(personDTO);
                _db.Persons.Add(person);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PersonDTO>(person);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        public ResponseDTO Put([FromBody] PersonDTO personDTO)
        {
            try
            {
                Person obj = _mapper.Map<Person>(personDTO);
                _db.Persons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PersonDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete("{id:long}")]
        public ResponseDTO Delete(long id)
        {
            try
            {
                var obj = _db.Persons.FirstOrDefault(u => u.PersonId == id);
                if (obj != null)
                {
                    _db.Persons.Remove(obj);
                    _db.SaveChanges();

                    _response.Message = "Paciente excluido!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Paciente não encontrado";
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
