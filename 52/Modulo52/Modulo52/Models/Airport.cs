using MongoDB.Bson.Serialization.Attributes;

namespace Modulo52.Models
{
    public class Airport
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        
        [BsonElement("iata")]
        public string Iata { get; set; }
        
        [BsonElement("time_zone_id")]
        public string Time_zone_id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("city_code")]
        public string City_code { get; set; }
        
        [BsonElement("country_id")]
        public string Country_id { get; set; }
        
        [BsonElement("location")]
        public string Location { get; set; }
        
        [BsonElement("elevation")]
        public string Elevation { get; set; }
        
        [BsonElement("icao")]
        public string Icao { get; set; }
        
        [BsonElement("city")]
        public string City { get; set; }
        
        [BsonElement("state")]
        public string State { get; set; }

    }

}
