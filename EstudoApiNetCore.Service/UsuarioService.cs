using EstudoApiNetCore.Models;
using EstudoApiNetCore.Repository;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace EstudoApiNetCore.Service
{
    public class UsuarioService
    {
        public async Task<UsuarioModel> Salvar(UsuarioModel usuario)
        {
            var repository = new UsuarioRepository();
            UsuarioModel usuarioSalvo = await repository.Salvar(usuario);

            return usuarioSalvo;
        }

        public async Task<UpdateResult> Atualizar(string id, UsuarioModel usuario)
        {
            var repository = new UsuarioRepository();
            UpdateResult resultadoUpdate = await repository.Atualizar(id, usuario);

            return resultadoUpdate;
        }
    }
}
