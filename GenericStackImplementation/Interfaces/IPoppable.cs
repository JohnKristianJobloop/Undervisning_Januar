using System;

namespace GenericStackImplementation.Interfaces;

public interface IPoppable<out T>
{
    T Pop();
}
