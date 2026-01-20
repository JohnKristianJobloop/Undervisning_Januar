using System;
using ReflectionExample.Interfaces;

namespace ReflectionExample.Models;

public class MercedersFactory : ICarFactory
{
    public static ICarFactory CreateFactory() => new MercedersFactory();

    public Car Build<T>(ICarOptions options)
    {
        throw new NotImplementedException();
    }
}
