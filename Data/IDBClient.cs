using MongoDB.Driver;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoShop2._0.Data
{
    public interface IDBClient
    {
        IMongoCollection<Book> GetBooksColletion();
    }
}
