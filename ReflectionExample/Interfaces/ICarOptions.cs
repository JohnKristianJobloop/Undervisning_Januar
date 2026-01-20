using System;

namespace ReflectionExample.Interfaces;

public interface ICarOptions
{
    Enum Type {get;set;}
    string Model {get;set;}
    long ChassisNumber {get;set;}
}
