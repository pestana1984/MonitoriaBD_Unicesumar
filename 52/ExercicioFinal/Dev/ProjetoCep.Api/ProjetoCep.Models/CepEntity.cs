using MongoDB.Bson.Serialization.Attributes;

namespace ProjetoCep.Models
{

    public class CepEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("cep")]
        public string Cep { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }
        [BsonElement("street")]
        public string Street { get; set; }
        [BsonElement("service")]
        public string Service { get; set; }

    }
}
