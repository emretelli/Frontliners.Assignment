using Frontliners.Assignment.Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Frontliners.Assignment.Domain.Entities
{
    public class Truck : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public TruckSize Size { get; set; }
    }

    public enum TruckSize
    {
        Small,
        Medium,
        Large
    }
}
