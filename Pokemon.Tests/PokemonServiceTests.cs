using Moq;
using Pokemon.Models;
using System;
using Xunit;
namespace Pokemon.Tests
{
    public class PokemonServiceTests
    {

        private readonly PokemonRepository _repository;
        private readonly Mock<IPokemonServices> _pokemonservicemock = new Mock<IPokemonServices>();
       
        public PokemonServiceTests()
        {
            _repository = new PokemonRepository(_pokemonservicemock.Object);

        }
        [Fact]
        public void CallPokemonService_ShouldReturnPokemonInfo_WhenExists()
        {
            //Arrange
            string name = "charmeleon";
            string description = "When it swings its burning tail, it elevates the temperature to unbearably high levels.";

            var urlinfo = new UrlInfo()
            {
                flavor_text_entries = new flavortextentries[] { new flavortextentries { flavor_text = description } },
                habitat = new habitat() { name = "mountain" },
                is_legendary = false,
                Name = name
            };

            _pokemonservicemock.Setup(x => x.CallPokemonService(name)).Returns(urlinfo);

            //Act
            var pokemoninfo = _repository.GetPokemonInfo(name);

            //Assert
            Assert.Equal(expected: name, actual: pokemoninfo.Name);
            Assert.Equal(expected: description, actual: pokemoninfo.Description);

        }

        [Fact]
        public void CallPokemonService_ShouldReturnNothingPokemonInfo_WhenDoesNotExists()
        {
            //Arrange
            string name = "charmeleon";
            _pokemonservicemock.Setup(x => x.CallPokemonService(It.IsAny<string>())).Returns(() => null);

            //Act

            var pokemoninfo = _repository.GetPokemonInfo(name);

            //Assert

            Assert.Null(pokemoninfo);
        }

        [Fact]
        public void CallShakesPeareTranslatorService_ShouldReturnTranslated_WhenExists()
        {
            //Arrange
            string name = "charizard";
            string description = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.";
            var pokeinfo = new PokeInfo()
            {
                Name = name,
                Description = description,
                IsLegendary = false,
                Habitat = "mountain",
            };
           

            string translated = "Spits fire yond is hot enow to melt boulders. Known to cause forest fires unintentionally.";

            _pokemonservicemock.Setup(x => x.CallShakesPeareTranslatorService(description)).Returns(translated);
            
            ////Act
            string result = _repository.Translate(pokeinfo);

            ////Assert
            Assert.Equal(expected: translated, actual: result);
           
        }

        [Fact]
        public void CallYodaTranslatorService_ShouldReturnTranslated_WhenExists()
        {
            //Arrange
            string name = "charizard";
            string description = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.";
            var pokeinfo = new PokeInfo()
            {
                Name = name,
                Description = description,
                IsLegendary = true,
                Habitat = "mountain",
            };


            string translated = "Fire that is hot enough to melt boulders,  spits.Unintentionally,  known to cause forest fires.";

            _pokemonservicemock.Setup(x => x.CallYodaTranslatorService(description)).Returns(translated);

            ////Act
            string result = _repository.Translate(pokeinfo);

            ////Assert
            Assert.Equal(expected: translated, actual: result);
            
        }
    }
}
