using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SistemaDeGestionEscolar.Models;

namespace SistemaDeGestionEscolar.Services
{
    public class MateriaServices
    {
        private readonly IMongoCollection<Materias> _MateriasCollection;

        public MateriaServices(
            IOptions<SistemaDeGestionDatabaseSettings> SistemaDeGestionDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SistemaDeGestionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SistemaDeGestionDatabaseSettings.Value.DatabaseName);

            _MateriasCollection = mongoDatabase.GetCollection<Materias>(
                SistemaDeGestionDatabaseSettings.Value.MateriasCollectionName);

        }

        public async Task<List<Materias>> GetAsync() =>
        await _MateriasCollection.Find(_ => true).ToListAsync();

        public async Task<Materias?> GetAsync(string id) =>
            await _MateriasCollection.Find(materia => materia.Id_materia == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Materias newMateria) =>
            await _MateriasCollection.InsertOneAsync(newMateria);

        public async Task UpdateAsync(string id, Materias updateMateria) =>
            await _MateriasCollection.ReplaceOneAsync(materia => materia.Id_materia == id, updateMateria);


        public async Task RemoveAsync(string id) =>
            await _MateriasCollection.DeleteOneAsync(materia => materia.Id_materia == id);
    }
}
