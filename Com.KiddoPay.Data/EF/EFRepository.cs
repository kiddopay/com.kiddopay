using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Com.KiddoPay.Data.EF
{
    public abstract class EFRepository<TDbContext, T, TKey> : IRepository<T, TKey>
        where TDbContext : DbContext
        where T : EFBaseEntity<TKey>, new()
        where TKey : struct
    {
        public abstract Func<TKey, Func<T, bool>> FindStrategy { get; }
        TDbContext DbContext { get; }
        IServiceProvider ServiceProvider { get; }

        public EFRepository(IServiceProvider serviceProvider)
            : this(serviceProvider.GetService(typeof(TDbContext)) as TDbContext)
        {
            this.ServiceProvider = serviceProvider;
        }
        public EFRepository(TDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        void Validate(T entity)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(entity, this.ServiceProvider, null);
            Validator.ValidateObject(entity, validationContext, true);
        }

        public IEnumerable<T> Get()
        {
            return this.DbContext.Set<T>();
        }

        public T Get(TKey key)
        {
            return this.DbContext.Set<T>().SingleOrDefault(FindStrategy(key));
        }

        public T Find(params object[] keys)
        {
            return this.DbContext.Set<T>().Find(keys);
        }

        public TKey Create(T data)
        {
            this.Validate(data);
            this.DbContext.Set<T>().Add(data);
            this.DbContext.SaveChanges();
            return data.Id;
        }

        public bool Update(TKey key, T data)
        {
            //
            throw new NotImplementedException();
        }

        public bool Delete(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
