using EstudoApiNetCore.Models;
using EstudoApiNetCore.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
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

        public async Task<DeleteResult> Excluir(string id)
        {
            var repository = new UsuarioRepository();
            DeleteResult resultadoExclusao = await repository.Excluir(id);

            return resultadoExclusao;
        }

        public async Task<IEnumerable<UsuarioModel>> ListarUsuarios()
        {
            var repository = new UsuarioRepository();
            IAsyncCursor<UsuarioModel> usuarios = await repository.ListarUsuarios();

            return usuarios.ToEnumerable();
        }

        public async Task<UsuarioModel> BuscarUsuario(string id)
        {
            var repository = new UsuarioRepository();
            IAsyncCursor<UsuarioModel> usuarios = await repository.BuscarUsuario(id);

            return usuarios.FirstOrDefault();
        }
    }
}
