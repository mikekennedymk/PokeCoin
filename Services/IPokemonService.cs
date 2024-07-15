using PokéCoin.Models;

namespace PokéCoin.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResult> GetPokemons();
        //Task<Usuarios> GetPokemon(int id);
        Task<PokemonDetail> GetPokemonByName(string nome);

    }
}
