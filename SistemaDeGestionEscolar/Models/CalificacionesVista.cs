using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SistemaDeGestionEscolar.Models
{
    public class CalificacionesVista
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_calificacion { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_materia { get; set; }

        public object? Materia { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_alumno { get; set; }

        public object? Alumno { get; set; }

        public double? Calificacion { get; set; }

        public bool Is_activo { get; set; }
    }
}
