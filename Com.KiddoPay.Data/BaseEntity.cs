using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Data
{
    public class BaseEntity<TKey> where TKey : struct
    {
        public virtual TKey Id { get; set; }
    }
}
