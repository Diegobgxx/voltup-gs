using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;


namespace models
{
    public class ChargingStationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(Title = "Id", Description = "Identificação da Estação")]
        public string Id { get; set; }

        [BsonElement("nome")]
        [SwaggerSchema(Title = "Nome", Description = "Nome da Estação")]
        public string Nome { get; set; }

        [BsonElement("endereco")]
        [SwaggerSchema(Title = "Endereço", Description = "Endereço da Estação")]
        public string Endereco { get; set; }

        [BsonElement("latitude")]
        [SwaggerSchema(Title = "Latitude", Description = "Latitude da Estação")]
        public double Latitude { get; set; }

        [BsonElement("longitude")]
        [SwaggerSchema(Title = "Longitude", Description = "Longitude da Estação")]
        public double Longitude { get; set; }

        [BsonElement("tipos_conectores")]
        [SwaggerSchema(Title = "Tipos de Conectores", Description = "Tipos de Conectores Aceitos na Estação")]
        public List<string> TiposConectores { get; set; }

        [BsonElement("potencia")]
        [SwaggerSchema(Title = "Potência", Description = "Potência em kW da Estação")]
        public double Potencia { get; set; }

        [BsonElement("operadora")]
        [SwaggerSchema(Title = "Operadora", Description = "Empresa responsável pela Estação")]
        public string Operadora { get; set; }
    }
}