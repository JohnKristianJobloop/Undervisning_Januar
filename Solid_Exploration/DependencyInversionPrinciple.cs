using System;

namespace Solid_Exploration;

public class DependencyInversionPrinciple(DataHandler handler)
{
    public void HandleOrder(Order order) => handler.HandleOrder(order);
}

public class DataHandler(IDatabase database)
{
    public void HandleOrder(Order order) => database.SaveOrder(order);
}

public class SQLDatabase: IDatabase
{
    public void Insert(Order order){}

    public void SaveOrder(Order order) => Insert(order);
}

public class ExcelDatabase: IDatabase
{
    public void Append(Order order){}

    public void SaveOrder(Order order) => Append(order);
}


public class SupabaseDatabase: IDatabase
{
    public void Add(Order order){}

    public void SaveOrder(Order order) => Add(order);
}

public interface IDatabase
{
    void SaveOrder(Order order);
}