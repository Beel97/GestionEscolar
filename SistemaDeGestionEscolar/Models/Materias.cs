using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SistemaDeGestionEscolar.Models
{
    public class Materias
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_materia { get; set; }

        public string? Nombre_materia { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_profesor { get; set; }
      

        public bool Is_activo { get; set; }
    }
}
