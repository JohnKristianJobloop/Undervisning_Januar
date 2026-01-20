using System;
using ReflectionExample.Interfaces;

namespace ReflectionExample.Models;

public class FordFactory : ICarFactory
{
    public static ICarFactory CreateFactory() => new FordFactory();

    public Car Build<T>(ICarOptions options)
    {
        throw new NotImplementedException();
    }
}
