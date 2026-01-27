using System;
using ReflectionExample.Interfaces;

namespace ReflectionExample.Extention;



//Dette er en eldre måte å ha en factory class som lager objekter som oppfyller krav til en interface. I dagens .NET bruker vi static abstract metoder på interfacen isteden. 
public static class CarFactoryFactory
{
    public static ICarFactory CreateFactory<T>() where T : ICarFactory
    {
        return (ICarFactory)Activator.CreateInstance(typeof(T))!;
    }
}
