using MediatR;
using MongoDB.Driver;
using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Repositories;
using MongoShop2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoShop2._0.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Snapshot
    {

        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;
        public Repository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<List<TEntity>> Get() => (await DbSet.FindAsync(Builders<TEntity>.Filter.Empty)).ToList();

        public virtual TEntity Create(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.AddCommand(async () => await DbSet.InsertOneAsync(entity));
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.AddCommand(async () => await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity));

            return entity;
        }

        public string Delete(Guid Id) 
        {
           _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", Id)));
            return "Successfuly deleted";
        } 

        public async Task<TEntity> GetOne(Guid Id) => (await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", Id))).SingleOrDefault();

        public async void SaveChangesAsync() => await _context.SaveChanges();
    }
}
