using System;

namespace src.Interfaces;

public interface ILFU_Cache<TKey, TValue> where TKey : IEquatable<TKey> 
{
    TValue? Get(TKey key);

    TValue Insert(TKey key, TValue value);
}
