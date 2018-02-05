using System;

namespace Com.KiddoPay.Data
{
    public interface IRepository<T, TKey> where T : class where TKey : struct
    {
        T Get(TKey key);
        TKey Create(T data);
        bool Update(TKey key, T data);
        bool Delete(TKey key);
    }
}
