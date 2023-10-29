using PokéCoin.Models;

namespace PokéCoin.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios> GetUsuario(int id);
        Task<IEnumerable<Usuarios>> GetUsuariosByNome(string nome);
        Task CreateUsuario(Usuarios usuario);
        Task UpdateUsuario(Usuarios usuario);
        Task DeleteUsuario(Usuarios usuario);

    }
}
