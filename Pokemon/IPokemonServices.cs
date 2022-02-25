using System.Net.Http;

namespace Pokemon
{
    public interface IPokemonServices
    {
        public UrlInfo CallPokemonService(string requestURI);

        public string CallShakesPeareTranslatorService(string requestURI);

        public string CallYodaTranslatorService(string requestURI);
    }
}
