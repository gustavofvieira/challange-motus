using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Develop.Store.Domain.Models
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Customer Customer { get; set; }
        public double TotalValue { get; set; }
        public List<Product> Products { get; set; }
    }
}
