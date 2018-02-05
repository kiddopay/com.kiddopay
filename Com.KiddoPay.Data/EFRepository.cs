using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Data
{
    public abstract class EFRepository<TDbContext, T, TKey> : IRepository<T, TKey>
        where TDbContext : DbContext
        where T : BaseEntity<TKey>
        where TKey : struct
    {
        public abstract Func<TKey, Func<T, bool>> FindStrategy { get; }
        TDbContext DbContext { get; }

        public EFRepository(TDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public TKey Create(T data)
        {
            this.DbContext.Set<T>().Add(data);
            this.DbContext.SaveChanges();
            return data.Id;
        }

        public bool Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public T Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Update(TKey key, T data)
        {
            throw new NotImplementedException();
        }
    }
}
