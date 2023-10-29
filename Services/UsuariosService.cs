using Microsoft.EntityFrameworkCore;
using PokéCoin.Context;
using PokéCoin.Models;

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
            return await _context.Usuarios.ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Usuarios> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            return usuario;
        }
        public async Task<IEnumerable<Usuarios>> GetUsuariosByNome(string nome)
        {
            IEnumerable<Usuarios> usuarios;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                usuarios = await _context.Usuarios.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else { 
            
                usuarios = await GetUsuarios();
            }

            return usuarios;
        }
        public async Task CreateUsuario(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateUsuario(Usuarios usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUsuario(Usuarios usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
