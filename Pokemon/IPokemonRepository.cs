using Pokemon.Models;

namespace Pokemon
{
    public interface IPokemonRepository
    {
       PokeInfo GetPokemonInfo(string PokemonName);
        PokeInfo GetTranslatedInfo(string PokemonName);
    }
}
