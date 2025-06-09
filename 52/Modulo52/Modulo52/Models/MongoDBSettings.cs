namespace Modulo52.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }

        public MongoDBSettings()
        {
            this.ConnectionString = "mongodb+srv://airportapi:RV3h6mfk5ye5UDry@monitoria52.jnj9750.mongodb.net/?retryWrites=true&w=majority&appName=Monitoria52";
            this.DatabaseName = "Airports";
            this.CollectionName = "BR";
        }
    }
}
