using System;

namespace GenericStackImplementation.Interfaces;

public interface IPushable<in T>
{
    void Push(T obj);
}
