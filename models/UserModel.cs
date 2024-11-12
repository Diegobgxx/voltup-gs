using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(Title = "Id", Description = "Identificador único do usuário")]
        public string Id { get; set; }

        [BsonElement("nome")]
        [SwaggerSchema(Title = "Nome", Description = "Nome completo do usuário")]
        public string Nome { get; set; }

        [BsonElement("email")]
        [SwaggerSchema(Title = "Email", Description = "Endereço de email do usuário")]
        public string Email { get; set; }

        [BsonElement("senha")]
        [SwaggerSchema(Title = "Senha", Description = "Senha criptografada do usuário")]
        public string Senha { get; set; }

        [BsonElement("data_cadastro")]
        [SwaggerSchema(Title = "Data de Cadastro", Description = "Data de cadastro do usuário")]
        public DateTime DataCadastro { get; set; }
    }
}