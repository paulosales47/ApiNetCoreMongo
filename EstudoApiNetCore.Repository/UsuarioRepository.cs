using EstudoApiNetCore.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace EstudoApiNetCore.Repository
{
    public class UsuarioRepository
    {
        public async Task Salvar(UsuarioModel usuario)
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("estudoNetCore");
            IMongoCollection<UsuarioModel> collection = database.GetCollection<UsuarioModel>("usuarios");

            await collection.InsertOneAsync(usuario);
        }
    }
}
