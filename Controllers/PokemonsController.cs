using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokéCoin.Models;
using PokéCoin.Services;
using System.Collections.Generic;

namespace PokéCoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private IPokemonService _pokemonService;
        public PokemonsController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<PokemonListResult> GetPokemons()
        {
            try
            {
                // Lógica para obter e retornar os Pokémon
                var pokemons = await _pokemonService.GetPokemons(); 

                // Retornar os Pokémon obtidos
                return pokemons;
            }
            catch (Exception ex)
            {
                // Tratar exceções ou lançar novamente
                throw new Exception("Erro ao obter os Pokémon", ex);
            }
        }

        [HttpGet("PokemonByName/{name}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PokemonDetail>> GetPokemonByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("O parâmetro 'nome' não pode estar vazio.");
                }

                var pokemon = await _pokemonService.GetPokemonByName(name);

                if (pokemon == null)
                {
                    return NotFound($"Não existe Pokémon com o nome \"{name}\" cadastrado no sistema.");
                }

                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retornar Pokémon: {ex.Message}");
            }
        }
        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        //public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        //{

        //    try
        //    {
        //        var usuario = await _usuariosService.GetUsuario(id);
        //        if (usuario == null)
        //        {
        //            return NotFound("Não existe usuário com o ID " + id + " cadastrado em sistema.");
        //        }
        //        return Ok(usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "erro ao retornar Usuário.");
        //    }

        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(Usuarios usuario)
        //{

        //    try
        //    {
        //        await _usuariosService.CreateUsuario(usuario);
        //        return CreatedAtRoute(nameof(GetUsuario), new { id = usuario.ID }, usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar o usuário.");
        //    }

        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> Edit(int id, [FromBody] Usuarios usuario)
        //{
        //    try
        //    {
        //        if (usuario.ID == id)
        //        {
        //            await _usuariosService.UpdateUsuario(usuario);
        //            return Ok(new { mensagem = $"Usuário {usuario.Nome} atualizado com sucesso!" });
        //        }
        //        else
        //        {
        //            return BadRequest("Dados não correspondem.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar o usuário.");
        //    }
        //}

        //[HttpDelete("{id:int}")]

        //public async Task<ActionResult> Delete(int id)
        //{

        //    try
        //    {

        //        var usuario = await _usuariosService.GetUsuario(id);
        //        if (usuario != null)
        //        {
        //            await _usuariosService.DeleteUsuario(usuario);
        //            return Ok(new { mensagem = $"Usuário {usuario.Nome} removido com sucesso!" });
        //        }
        //        else
        //        {
        //            return NotFound("Usuário não encontrado.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao apagar o usuário.");
        //    }

        //}
    }
}
