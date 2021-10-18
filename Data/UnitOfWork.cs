using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Repositories;
using MongoShop2._0.Interfaces;
using System;
using System.Threading.Tasks;

namespace MongoShop2._0.Data
{
    public class UnitOfWork<TSnapshot, TContext> : IUnitOfWork<TSnapshot>, IDisposable 
        where TSnapshot : Snapshot
        where TContext : IMongoContext
    {
        private readonly TContext _context;
        public IRepository<TSnapshot> Repository { get; }

        public UnitOfWork(IRepository<TSnapshot> _repository, TContext context)
        {
            Repository = _repository;
            _context = context;
        }
        public Task<int> SaveChangesAsync() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
