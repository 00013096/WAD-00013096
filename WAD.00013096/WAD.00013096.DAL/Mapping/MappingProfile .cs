using AutoMapper;
using WAD._00013096.DTOs;
using WAD._00013096.Models;

namespace WAD._00013096.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Estate, EstateDto>();

            CreateMap<PersonDto, Person>();
            CreateMap<EstateDto, Estate>();
        }
    }
}
