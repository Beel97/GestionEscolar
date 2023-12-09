using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaDeGestionEscolar.Models;

namespace SistemaDeGestionEscolar.Services
{
    public class ProfesorServices
    {
        private readonly IMongoCollection<Profesores.Profesores> _profesorCollection;

        public ProfesorServices(
            IOptions<SistemaDeGestionDatabaseSettings> SistemaDeGestionDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SistemaDeGestionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SistemaDeGestionDatabaseSettings.Value.DatabaseName);

            _profesorCollection = mongoDatabase.GetCollection<Profesores.Profesores>(
                SistemaDeGestionDatabaseSettings.Value.ProfesoresCollectionName);
        }

        public async Task<List<Profesores.Profesores>> GetAsync() =>
        await _profesorCollection.Find(_ => true).ToListAsync();

        public async Task<Profesores.Profesores?> GetAsync(string id) =>
            await _profesorCollection.Find(profesor => profesor.Id_profesor == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Profesores.Profesores newProfesor) =>
            await _profesorCollection.InsertOneAsync(newProfesor);

        public async Task UpdateAsync(string id, Profesores.Profesores updatedProfesor) =>
            await _profesorCollection.ReplaceOneAsync(profesor => profesor.Id_profesor == id, updatedProfesor);


        public async Task RemoveAsync(string id) =>
            await _profesorCollection.DeleteOneAsync(profesor => profesor.Id_profesor == id);
    }
}
