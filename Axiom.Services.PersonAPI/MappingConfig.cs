using AutoMapper;
using Axiom.Services.PersonAPI.Models;
using Axiom.Services.PersonAPI.Models.Dto;

namespace Axiom.Services.PersonAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDto, Person>().ReverseMap();
                config.CreateMap<PersonDetailsDto, PersonDetails>().ReverseMap();
                config.CreateMap<HealthDetailsDto, HealthDetails>().ReverseMap();
            });

            return MappingConfig;
        }
    }
}