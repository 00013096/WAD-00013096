using AutoMapper;
using WAD._00013096.DTOs;
using WAD._00013096.Models;

namespace WAD._00013096.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Seller, SellerDto>();
            CreateMap<Estate, EstateDto>();

            CreateMap<SellerDto, Seller>();
            CreateMap<EstateDto, Estate>();
        }
    }
}
