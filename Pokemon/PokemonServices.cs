using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;

namespace Pokemon
{
    public class PokemonServices : IPokemonServices
    {
        private static readonly HttpClient PokemonClient;
        private static readonly HttpClient ShakespeareClient;
        private static readonly HttpClient YodaClient;
        private static readonly string PokemonAPI = "https://pokeapi.co/";
        private static readonly string ShakespeareAPI = "https://api.funtranslations.com/translate/shakespeare.json?text=";
        private static readonly string YodaAPI = "https://api.funtranslations.com/translate/yoda.json?text=";

        static PokemonServices()
        {
            PokemonClient = new HttpClient()
            {
                BaseAddress = new Uri(PokemonAPI)
            };

            ShakespeareClient = new HttpClient();
            YodaClient = new HttpClient();
        }

        public UrlInfo CallPokemonService(string requestURI)
        {
            UrlInfo UrlResponse = new UrlInfo();
            HttpResponseMessage res = PokemonClient.GetAsync("/api/v2/pokemon-species/" + requestURI).Result;
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;

                /// to deserialize the result
                if (!string.IsNullOrEmpty(result))
                {

                    UrlResponse = JsonSerializer.Deserialize<UrlInfo>(result);
                }
            }
            else
                UrlResponse = null;


            return UrlResponse;
        }

        public string CallShakesPeareTranslatorService(string requestURI)
        {
            string shakespearetext = string.Empty;
            string translated = string.Empty;

            HttpResponseMessage httpResponseMessage = ShakespeareClient.GetAsync(ShakespeareAPI + requestURI).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                translated = httpResponseMessage.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(translated))
                {
                    string obj = Newtonsoft.Json.JsonConvert.DeserializeObject(translated).ToString();

                    JToken token = JObject.Parse(obj);

                    shakespearetext = token["contents"]["translated"].ToString();
                }
            }
            return shakespearetext;
        }

        public string CallYodaTranslatorService(string requestURI)
        {
            string translated = string.Empty;
            string YodaText = string.Empty;


            HttpResponseMessage httpResponseMessage = YodaClient.GetAsync(YodaAPI + requestURI).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                translated = httpResponseMessage.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(translated))
                {
                    string obj = Newtonsoft.Json.JsonConvert.DeserializeObject(translated).ToString();

                    JToken token = JObject.Parse(obj);

                    YodaText = token["contents"]["translated"].ToString();
                }
            }
            return YodaText;
        }
    }
}
