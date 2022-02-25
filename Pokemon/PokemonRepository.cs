using Newtonsoft.Json.Linq;
using Pokemon.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Pokemon
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemonServices pokemonServices;
        public PokemonRepository(IPokemonServices pokemonServices)
        {
            this.pokemonServices = pokemonServices;
        }
        /// <summary>
        /// method to fetch the pokemon info from third party API call 
        /// </summary>
        /// <param name="PokemonName"></param>
        /// <returns></returns>
        public PokeInfo GetPokemonInfo(string PokemonName)
        {
            PokeInfo pokeInfo = new PokeInfo();

            UrlInfo UrlResponse = pokemonServices.CallPokemonService(PokemonName);

            if (UrlResponse != null)
            {
                pokeInfo.Name = PokemonName;
                pokeInfo.Description = Regex.Replace(UrlResponse.flavor_text_entries[0].flavor_text, @"\t|\n|\r|\f", " ");
                pokeInfo.Habitat = UrlResponse.habitat.name;
                pokeInfo.IsLegendary = UrlResponse.is_legendary;
            }
            else
                pokeInfo = null;
            return pokeInfo;
        }

        /// <summary>
        /// method to fetch pokemon information with translated description
        /// </summary>
        /// <param name="PokemonName"></param>
        /// <returns></returns>
        public PokeInfo GetTranslatedInfo(string PokemonName)
        {
            PokeInfo pokeInfo = new PokeInfo();
            pokeInfo = GetPokemonInfo(PokemonName);

            if(pokeInfo != null)
            // call to translate method to fetch translated description
            pokeInfo.Description = Translate(pokeInfo);
            return pokeInfo;
        }

        /// <summary>
        /// method to translate the description of the pokemon with different third party translators
        /// </summary>
        /// <param name="pokeInfo"></param>
        /// <returns></returns>
        public string Translate(PokeInfo pokeInfo)
        {

            string translated = string.Empty;            

            if (pokeInfo.Habitat == "cave" || pokeInfo.IsLegendary)
                translated = pokemonServices.CallYodaTranslatorService(pokeInfo.Description);
            else
                translated = pokemonServices.CallShakesPeareTranslatorService(pokeInfo.Description);

            return translated;
        }


    }
}
