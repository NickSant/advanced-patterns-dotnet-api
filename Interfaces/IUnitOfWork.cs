using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Data
{
    public interface IUnitOfWork<TSnapshot> where TSnapshot : Snapshot
    {
       IRepository<TSnapshot> Repository { get; }
       Task<int> SaveChangesAsync();
    }
}
