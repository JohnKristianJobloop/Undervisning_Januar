using System;

namespace GenericStackImplementation.Interfaces;

public interface IGenericStack<T>: IEnumerable<T>, IPoppable<T>, IPushable<T>;


