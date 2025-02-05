using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Develop.Store.Domain.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool Canceled { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
