using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SistemaDeGestionEscolar.Models
{
    public class Calificaciones
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_calificacion { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_materia { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_alumno { get; set; }
        public double? Calificacion { get; set; }

        public bool Is_activo { get; set; }
    }
}
