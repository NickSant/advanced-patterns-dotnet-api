using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoShop2._0.Domain.Entities
{
    public class Book: Snapshot
    {
        public static Book Build(string name, double price, string category, string author) => new Book
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            Category = category,
            Author = author,
        };

        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
