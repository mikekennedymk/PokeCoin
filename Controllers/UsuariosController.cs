using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokéCoin.Models;
using PokéCoin.Services;
using System.Collections.Generic;

namespace PokéCoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosService _usuariosService;
        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IAsyncEnumerable<Usuarios>>> GetUsuarios()
        {

            try
            {
                var usuarios = await _usuariosService.GetUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "erro ao retornar Usuários.");
            }

        }

        [HttpGet("UsuarioByName")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IAsyncEnumerable<Usuarios>>> GetUsuariosByName([FromQuery] string nome)
        {

            try
            {
                var usuarios = await _usuariosService.GetUsuariosByNome(nome);
                if (usuarios.Count() == 0)
                {
                    return NotFound("Não existem usuários com o nome \"" + nome + "\" cadastrados em sistema.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "erro ao retornar Usuários.");
            }

        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {

            try
            {
                var usuario = await _usuariosService.GetUsuario(id);
                if (usuario == null)
                {
                    return NotFound("Não existe usuário com o ID " + id + " cadastrado em sistema.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "erro ao retornar Usuário.");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Create(Usuarios usuario)
        {

            try
            {
                await _usuariosService.CreateUsuario(usuario);
                return CreatedAtRoute(nameof(GetUsuario), new { id = usuario.ID }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar o usuário.");
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Edit(int id, [FromBody] Usuarios usuario)
        {

            try
            {
                if (usuario.ID == id)
                {
                    await _usuariosService.UpdateUsuario(usuario);
                    return Ok("Usuário " + usuario.Nome + " atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados não correspondem.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar o usuário.");
            }

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            try
            {

                var usuario = await _usuariosService.GetUsuario(id);
                if (usuario != null)
                {
                    await _usuariosService.DeleteUsuario(usuario);
                    return Ok("Usuário apagado com sucesso!");
                }
                else
                {
                    return NotFound("Usuário não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao apagar o usuário.");
            }

        }
    }
}
