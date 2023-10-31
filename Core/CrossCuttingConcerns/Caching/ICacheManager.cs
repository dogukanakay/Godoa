﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T GetT<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        void Remove(string key);
        bool IsAdd(string key);
        void RemoveByPattern(string pattern);
    }
}
