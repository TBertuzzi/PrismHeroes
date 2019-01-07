using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrismHeroes.Models.MarvelHeroesCN.Models;

namespace PrismHeroes.Services
{
    public interface IMarvelApiService
    {
        Task<List<Personagem>> GetPersonagensAsync();
    }
}
