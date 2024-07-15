using Microsoft.EntityFrameworkCore;
using PokeApiNet;
using PokéCoin.Context;
using PokéCoin.Models;
using System.Net.Http;
using System.Text.Json;

namespace PokéCoin.Services
{

    public class PokemonService : IPokemonService
    {
        private readonly AppDbContext _context;
        PokeApiClient pokeClient = new PokeApiClient();
        private readonly HttpClient _httpClient;
        public PokemonService(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<PokemonListResult> GetPokemons()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=25");
                response.EnsureSuccessStatusCode(); // Lança uma exceção em caso de erro HTTP.

                string responseBody = await response.Content.ReadAsStringAsync();

                // Desserializar a resposta JSON para objetos C# usando System.Text.Json

                PokemonListResult pokemonListResult = JsonSerializer.Deserialize<PokemonListResult>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Caso as propriedades no JSON não estejam em camelCase
                });

                foreach (var pokemon in pokemonListResult.Results)
                {
                    // Obter detalhes do Pokémon, incluindo o sprite front_default
                    pokemon.Details = await GetPokemonDetails(pokemon.Url);
                }

                return pokemonListResult;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao fazer a requisição HTTP: {e.Message}");
                throw; // Lança a exceção para ser tratada em níveis superiores
            }
        }

        private async Task<PokemonDetail> GetPokemonDetails(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            PokemonDetail pokemonDetail = JsonSerializer.Deserialize<PokemonDetail>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Caso as propriedades no JSON não estejam em camelCase
            });

            return pokemonDetail;
        }

        //public async Task<Pokemon> GetPokemon(int id)
        //{
        //    try
        //    {
        //        var pokemon = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(id);
        //        return pokemon;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) here as needed
        //        throw new Exception($"An error occurred while getting the user with ID {id}.", ex);
        //    }
        //}

        public async Task<PokemonDetail> GetPokemonByName(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");

                response.EnsureSuccessStatusCode(); // Lança uma exceção em caso de erro HTTP.

                var responseBody = await response.Content.ReadAsStringAsync();

                var pokemonDetail = JsonSerializer.Deserialize<PokemonDetail>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Caso as propriedades no JSON não estejam em camelCase
                });

                return pokemonDetail;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao fazer a requisição HTTP: {e.Message}");
                throw; // Lança a exceção para ser tratada em níveis superiores
            }
        }
    }

}
