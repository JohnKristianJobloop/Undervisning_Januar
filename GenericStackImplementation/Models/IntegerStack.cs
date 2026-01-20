using System;

namespace GenericStackImplementation.Models;

public class IntegerStack(int stackLength)
{
    //Vi trenger en måte å vite hvor toppen av "stacken" er.
    private int _position;

    //Vi trenger en måte å holde all data i stacken. 
    private readonly int[] _data = new int[stackLength];

    public void Push(int number)
    {
        if(_position >= _data.Length) throw new IndexOutOfRangeException("outside of range of stack");
        _data[_position++] = number; 
    }

    public int Pop() => _position < 0 ? throw new IndexOutOfRangeException("outside the range of stack") : _data[--_position];
}
