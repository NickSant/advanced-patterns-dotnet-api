using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoShop2._0.Config;
using MongoShop2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MongoShop2._0.Contexts
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        public IClientSessionHandle Session { get; set; }

        public MongoContext(IOptions<BookstoreDBConfig> dbConfig)
        {
            _commands = new List<Func<Task>>();

            MongoClient = new MongoClient(dbConfig.Value.Connection_String);
            Database = MongoClient.GetDatabase(dbConfig.Value.Database_Name);
        }

      
        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
