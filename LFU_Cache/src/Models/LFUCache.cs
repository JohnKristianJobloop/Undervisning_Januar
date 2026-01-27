using System;
using src.Interfaces;

namespace src.Models;

public class LFUCache<TKey, TValue>(int cacheSize): ILFU_Cache<TKey,TValue> where TKey : IEquatable<TKey>
{
    //Vi trenger et dictionary, som skal holde en nøkkel, og returnere en node fra linked list.

    //Vi trenger en slags linked list, som holder oversikt over hvilke data som er
    //Least Frequently Used

    private int _cacheSize = cacheSize;

    private Dictionary<TKey, LinkedListNode<TValue>> _cache = [];

    private LinkedList<TValue> _values = [];

    public TValue? Get(TKey key)
    {
        //Vi prøver å finne en cache-hit
        var node = _cache.Where(pair => pair.Key.Equals(key)).Select(pair => pair.Value).FirstOrDefault();
        if (node is null) return default;

        //Vi flytter node til head, for å passe på at den ikke forsvinner med en gang.
        _values.Remove(node);
        _values.AddFirst(node);

        //Vi returnerer verdien bak
        return node.Value;
    }

    public TValue Insert(TKey key, TValue value)
    {
        //Vi skjekker først om Cache er fullt. 
        if (_cache.Count >= _cacheSize && _values.Last != null)
        {
            //Hent ut siste noden i linked list
            var lastNode = _values.Last;

            //Vi finner hvor den er i dictionariet vårt
            var node = _cache.Where(pair => pair.Value == lastNode).FirstOrDefault();

            //Vi fjerner de fra cachet. 
            _values.Remove(lastNode);
            _cache.Remove(node.Key);
        }


        var newNode = new LinkedListNode<TValue>(value);
        _values.AddFirst(newNode);
        _cache.Add(key, newNode);
        return value;
    }
}
