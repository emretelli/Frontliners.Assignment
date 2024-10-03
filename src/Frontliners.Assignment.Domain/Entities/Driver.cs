using Frontliners.Assignment.Domain.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Frontliners.Assignment.Domain.Entities
{
    public class Driver : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
    }
}
