using Microsoft.EntityFrameworkCore;
using PokéCoin.Context;
using PokéCoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokéCoin.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly AppDbContext _context;

        public UsuariosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            try
            {
                return await _context.Usuarios.Where(u => u.RemovidoEm == null).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the list of users.", ex);
            }
        }

        public async Task<Usuarios> GetUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                return usuario;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                throw new Exception($"An error occurred while getting the user with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Usuarios>> GetUsuariosByNome(string nome)
        {
            try
            {
                IEnumerable<Usuarios> usuarios;
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    usuarios = await _context.Usuarios.Where(n => n.Nome.Contains(nome)).ToListAsync();
                }
                else
                {
                    usuarios = await GetUsuarios();
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting users with name containing '{nome}'.", ex);
            }
        }

        public async Task CreateUsuario(Usuarios usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the user.", ex);
            }
        }

        public async Task UpdateUsuario(Usuarios usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user.", ex);
            }
        }

        public async Task DeleteUsuario(Usuarios usuario)
        {
            try
            {
                usuario.RemovidoEm = DateTime.UtcNow;
                _context.Usuarios.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the user.", ex);
            }
        }
    }
}
