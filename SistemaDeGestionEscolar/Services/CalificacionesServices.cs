using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaDeGestionEscolar.Models;

namespace SistemaDeGestionEscolar.Services
{
    public class CalificacionesServices
    {
        private readonly IMongoCollection<Calificaciones> _calificacionesCollection;

        public CalificacionesServices(
            IOptions<SistemaDeGestionDatabaseSettings> SistemaDeGestionDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SistemaDeGestionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SistemaDeGestionDatabaseSettings.Value.DatabaseName);

            _calificacionesCollection = mongoDatabase.GetCollection<Calificaciones>(
                SistemaDeGestionDatabaseSettings.Value.CalificacionesCollectionName);
        }

        public async Task<List<Calificaciones>> GetAsync() =>
        await _calificacionesCollection.Find(_ => true).ToListAsync();

        public async Task<Calificaciones?> GetAsync(string id) =>
            await _calificacionesCollection.Find(calificaciones => calificaciones.Id_calificacion == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Calificaciones newCalificacion) =>
            await _calificacionesCollection.InsertOneAsync(newCalificacion);

        public async Task UpdateAsync(string id, Calificaciones updateCalificacion) =>
            await _calificacionesCollection.ReplaceOneAsync(calificaciones => calificaciones.Id_calificacion == id, updateCalificacion);


        public async Task RemoveAsync(string id) =>
            await _calificacionesCollection.DeleteOneAsync(calificaciones => calificaciones.Id_calificacion == id);
    }
}
