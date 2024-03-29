using AutoMapper;
using firstAPI.Data.Dtos;
using firstAPI.Models;
namespace firstAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, CreateFilmeDto>();
        }
    }
}