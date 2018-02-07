using System;
using System.Collections.Generic;

namespace Com.KiddoPay.Data
{
    public interface IRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct
    {
        IEnumerable<T> Get();
        T Get(TKey key);
        T Find(params object[] keys);
        TKey Create(T data);
        bool Update(TKey key, T data);
        bool Delete(TKey key);
    }
}
