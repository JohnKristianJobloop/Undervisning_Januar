using System;

namespace src.Interfaces;

public interface ILFUCache<TKey, TValue> where TKey : IEquatable<TKey> 
{
    TValue? Get(TKey key);

    TValue Insert(TKey key, TValue value);
}
