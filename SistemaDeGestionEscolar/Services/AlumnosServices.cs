using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaDeGestionEscolar.Models;

namespace SistemaDeGestionEscolar.Services
{

    public class AlumnosServices
    {
        private readonly IMongoCollection<Alumnos> _alumnoCollection;

        public AlumnosServices(
            IOptions<SistemaDeGestionDatabaseSettings> SistemaDeGestionDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SistemaDeGestionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SistemaDeGestionDatabaseSettings.Value.DatabaseName);

            _alumnoCollection = mongoDatabase.GetCollection<Alumnos>(
                SistemaDeGestionDatabaseSettings.Value.AlumnosCollectionName);
        }


        public async Task<List<Alumnos>> GetAsync() =>
        await _alumnoCollection.Find(_ => true).ToListAsync();

        public async Task<Alumnos?> GetAsync(string id) =>
            await _alumnoCollection.Find(alumno => alumno.Id_alumno == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Alumnos newAlumn) =>
            await _alumnoCollection.InsertOneAsync(newAlumn);

        public async Task UpdateAsync(string id, Alumnos updatedAlumno) =>
            await _alumnoCollection.ReplaceOneAsync(alumno => alumno.Id_alumno == id, updatedAlumno);

        public async Task RemoveAsync(string id) =>
            await _alumnoCollection.DeleteOneAsync(alumno => alumno.Id_alumno == id);
    }
}
