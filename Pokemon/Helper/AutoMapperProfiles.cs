
using Pokemon.DTO;
using Pokemon.Models;
using AutoMapper;
namespace Pokemon.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PokeInfo, PokemonDTO>();
        }
    }
}
