using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace models
{
    public class VehicleModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(Title = "Id", Description = "Identificador único do veículo")]
        public string Id { get; set; }

        [BsonElement("modelo")]
        [SwaggerSchema(Title = "Modelo", Description = "Modelo do veículo")]
        public string Modelo { get; set; }

        [BsonElement("marca")]
        [SwaggerSchema(Title = "Marca", Description = "Marca do veículo")]
        public string Marca { get; set; }

        [BsonElement("autonomia")]
        [SwaggerSchema(Title = "Autonomia", Description = "Autonomia estimada do veículo em km")]
        public double Autonomia { get; set; }

        [BsonElement("usuario_id")]
        [SwaggerSchema(Title = "Usuário ID", Description = "Identificador do usuário proprietário do veículo")]
        public string UsuarioId { get; set; }
    }
}