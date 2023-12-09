using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SistemaDeGestionEscolar.Models
{
    public class Alumnos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_alumno { get; set; }

        public string? Nombre_alumno { get; set; }

        public string? Apellidos_alumno { get; set; }
        
        public bool Is_activo { get; set; }
    }
}
