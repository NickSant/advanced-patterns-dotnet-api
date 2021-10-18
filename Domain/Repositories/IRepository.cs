using MediatR;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Snapshot
    {
        Task<List<TEntity>> Get();
        Task<TEntity> GetOne(Guid Id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        string Delete(Guid Id);
    }
}
