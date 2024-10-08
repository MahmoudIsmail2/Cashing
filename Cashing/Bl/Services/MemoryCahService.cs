﻿using Cashing.Bl.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Cashing.Bl.Services
{
    public class MemoryCahService : IMemoryCahService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCahService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T GetFromCash<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }
            return default(T);
        }

        public void RemoveFromCash(string key)
        {
            var cashKey = _memoryCache.Get(key);
            if (cashKey is not null)
                _memoryCache.Remove(key);
        }
        public T SettoCash<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
            return value;
        }
    }
}
