using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Profesores
{
    public class Profesores
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id_profesor { get; set; }

        public string? Nombre_profesor { get; set; }

        public string? Apellidos_profesor { get; set; }

        public bool Is_activo { get; set; }


    }
}
