using AutoMapper;
using Axiom.Services.PersonAPI.Models;
using Axiom.Services.PersonAPI.Models.DTOs;

namespace Axiom.Services.PersonAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDTO, Person>().ReverseMap();
                config.CreateMap<PersonDetailsDTO, PersonDetails>().ReverseMap();
                config.CreateMap<HealthDetailsDTO, HealthDetails>().ReverseMap();
            });

            return MappingConfig;
        }
    }
}