# Pokemon
Application using pokemon API

This is a Rest API which returns pokemon information.
To run the API below softwares will be required
postman

to view and run the code visual studio with below microsoft extensions will be required
1.automapper
2.Newtonsoft.Json
3.dependency injection
4.AutoMapper.Extensions.Microsoft.DependencyInjection

API has two endpoints 
1. returns basic pokemon information
 e.g. http/get/pokemon?name=charizard

below response will be received 
{
    "name": "charizard",
    "description": "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.",
    "habitat": "mountain",
    "isLegendary": false
}

2. translated pokemon description
e.g. http/get/pokemon/translated?name=venusaur

below response will be received 
  "name": "venusaur",
    "description": "The plant blooms at which hour 't is absorbing solar energy. 't stays on the moveth to seek sunlight.",
    "habitat": "grassland",
    "isLegendary": false
    
    where description is translated based on habitat and isLegendary status of pokemon.
