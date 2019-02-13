using EstudoApiNetCore.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace EstudoApiNetCore.Repository
{
    public class UsuarioRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<UsuarioModel> _collection;


        public UsuarioRepository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("estudoNetCore");
            _collection = _database.GetCollection<UsuarioModel>("usuarios");
        }


        public async Task<UsuarioModel> Salvar(UsuarioModel usuario)
        {
            usuario.DtAtualizacao = DateTime.Now;

            await _collection.InsertOneAsync(usuario);

            return usuario;
        }

        public async Task<UpdateResult> Atualizar(string id, UsuarioModel usuario)
        {
            var filter = Builders<UsuarioModel>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<UsuarioModel>.Update
                .Set("PrimeiroNome", usuario.PrimeiroNome)
                .Set("UltimoNome", usuario.UltimoNome)
                .Set("Email", usuario.Email)
                .Set("Endereco", usuario.Endereco)
                .Set("Numero", usuario.Numero)
                .Set("Telefone", usuario.Telefone)
                .Set("DtAtualizacao", DateTime.Now);


            return await _collection.UpdateOneAsync(filter, update);
        }
    }
}
