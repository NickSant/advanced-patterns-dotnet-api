using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoShop2._0.Config;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoShop2._0.Data
{
    public class DBClient : IDBClient
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public DBClient(IOptions<BookstoreDBConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _booksCollection = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);

        }

        public IMongoCollection<Book> GetBooksColletion() => _booksCollection;
       
    }
}
