using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pokemon.DTO;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace Pokemon.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper mapper;
       
        public PokemonController(IPokemonRepository _pokemonRepository, IMapper mapper)
        {
            this._pokemonRepository = _pokemonRepository;
            this.mapper = mapper;

        }

        public ActionResult<PokemonDTO> Get(string name)
        {
            var pokemoninfo = _pokemonRepository.GetPokemonInfo(name);
            var pokemonDTO = mapper.Map<PokemonDTO>(pokemoninfo);
            return pokemonDTO;
        }



        [Route("translated")]
        public ActionResult<PokemonDTO> translated(string name)
        {
            var translatedinfo = _pokemonRepository.GetTranslatedInfo(name);
            var pokemonDTO = mapper.Map<PokemonDTO>(translatedinfo);
            return pokemonDTO;

        }
    }
}
