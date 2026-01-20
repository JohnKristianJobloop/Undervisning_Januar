using System;
using ReflectionExample.Models;

namespace ReflectionExample.Interfaces;

public interface ICarFactory
{
    Car Build<T>(ICarOptions options);
    static abstract ICarFactory CreateFactory();
}
