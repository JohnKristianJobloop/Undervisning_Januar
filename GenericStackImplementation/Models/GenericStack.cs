using System;
using System.Collections;
using GenericStackImplementation.Interfaces;

namespace GenericStackImplementation.Models;

public class GenericStack<T>(int stackLength): IGenericStack<T>
{
    //Vi trenger en måte å vite hvor toppen av "stacken" er.
    private int _position;

    //Vi trenger en måte å holde all data i stacken. 
    private readonly T[] _data = new T[stackLength];

    public void Push(T number)
    {
        if(_position >= _data.Length) throw new IndexOutOfRangeException("outside of range of stack");
        _data[_position++] = number; 
    }

    public T Pop() => _position < 0 ? throw new IndexOutOfRangeException("outside the range of stack") : _data[--_position];

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            yield return _data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
