using System;
using ReflectionExample.Interfaces;

namespace ReflectionExample.Extention;

public static class CarFactoryFactory
{
    public static ICarFactory CreateFactory<T>() where T : ICarFactory
    {
        return (ICarFactory)Activator.CreateInstance(typeof(T))!;
    }
}
