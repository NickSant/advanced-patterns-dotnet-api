using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Entities
{
    public class Snapshot
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
