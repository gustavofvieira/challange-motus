using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Develop.Store.Domain.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Document { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
