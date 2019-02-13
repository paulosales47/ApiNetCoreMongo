using EstudoApiNetCore.Models;
using EstudoApiNetCore.Repository;
using System.Threading.Tasks;

namespace EstudoApiNetCore.Service
{
    public class UsuarioService
    {
        public async Task Salvar(UsuarioModel usuario)
        {
            var repository = new UsuarioRepository();
            await repository.Salvar(usuario);
        }

    }
}
