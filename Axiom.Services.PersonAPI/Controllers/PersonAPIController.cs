using AutoMapper;
using Axiom.Services.PersonAPI.Data;
using Axiom.Services.PersonAPI.Models;
using Axiom.Services.PersonAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Axiom.Services.PersonAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
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

        [HttpPut("{id:long}")]
        public ResponseDTO Put(long id, [FromBody] PersonDTO personDTO)
        {
            try
            {
                var objFromDb = _db.Persons.Include(p => p.PersonDetails).FirstOrDefault(u => u.PersonId == id);
                if (objFromDb != null)
                {
                    _mapper.Map(personDTO, objFromDb);
                    _db.SaveChanges();

                    _response.Result = _mapper.Map<PersonDTO>(objFromDb);
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Person not found.";
                }
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

                    _response.Message = "Person has been deleted!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Person not found.";
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
