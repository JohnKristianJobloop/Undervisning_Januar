using System;

namespace GenericStackImplementation.Models;

public class ObjectStack(int stackLength)
{
    //Vi trenger en måte å vite hvor toppen av "stacken" er.
    private int _position;

    //Vi trenger en måte å holde all data i stacken. 
    private readonly object[] _data = new object[stackLength];

    public void Push(object number)
    {
        if(_position >= _data.Length) throw new IndexOutOfRangeException("outside of range of stack");
        _data[_position++] = number; 
    }

    public object Pop() => _position < 0 ? throw new IndexOutOfRangeException("outside the range of stack") : _data[--_position];
}

