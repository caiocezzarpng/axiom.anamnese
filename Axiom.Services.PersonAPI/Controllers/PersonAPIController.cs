using AutoMapper;
using Axiom.Services.PersonAPI.Data;
using Axiom.Services.PersonAPI.Models;
using Axiom.Services.PersonAPI.Models.Dto;
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
        private ResponseDto _response;
        private IMapper _mapper;

        public PersonAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                var objList = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).ToList();
                _response.Result = _mapper.Map<IEnumerable<PersonDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id:long}")]
        public ResponseDto Get(long id)
        {
            try
            {
                var obj = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).FirstOrDefault(u => u.PersonId == id);
                _response.Result = _mapper.Map<PersonDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost("GetPersonsByName")]
        public ResponseDto GetPersonsByName([FromBody] string name)
        {
            try
            {
                var objList = _db.Persons.Include(p => p.PersonDetails).Include(p => p.HealthDetails).Where(u => u.Name.Contains(name)).ToList();
                _response.Result = _mapper.Map<IEnumerable<PersonDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] PersonDto personDTO)
        {
            try
            {
                var person = _mapper.Map<Person>(personDTO);
                _db.Persons.Add(person);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PersonDto>(person);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] PersonDto personDTO)
        {
            try
            {
                Person obj = _mapper.Map<Person>(personDTO);
                _db.Persons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PersonDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete("{id:long}")]
        public ResponseDto Delete(long id)
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
