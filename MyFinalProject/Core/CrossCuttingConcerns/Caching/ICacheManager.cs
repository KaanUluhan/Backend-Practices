using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
   public interface ICacheManager          //bağımsız bir interface
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);     //dakika,saat cinsinden tutabiliriz  ne istiyosak
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);       //başı sonu önemli değil design verdik
    }
}
