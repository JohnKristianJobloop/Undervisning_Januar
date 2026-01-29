using System;
using src.Interfaces;
using src.Models;

namespace Test.LFUTest;

public class LFUCacheTests
{
    [Fact]
    public void InsertValue_IntoCache_ReturnsSameValue()
    {
        //Arrange
        ILFUCache<string, string> Cache = new LFUCache<string, string>(10);
        string valueToBeInserted = "Hello!";

        //Act
        var valueInserted = Cache.Insert("Key", valueToBeInserted);

        //Assert
        Assert.Equal(valueToBeInserted, valueInserted);
    }

    [Fact]
    public void GetValueWithValidKey_ReturnsCorrectValue()
    {
        //Arrange
        ILFUCache<string, string> Cache = new LFUCache<string, string>(10);
        string valueToBeInserted = "Hello!";
        string validKey = "Key";
        var insertedValue = Cache.Insert(validKey, valueToBeInserted);

        //Act
        var result = Cache.Get(validKey);

        //Assert
        Assert.Equal(insertedValue, result);        
    }

    [Fact]
    public void GetValueWithInvalidKey_RetunsDefaultValueType()
    {
        //Arrange
        ILFUCache<string, string> Cache = new LFUCache<string, string>(10);
        string valueToBeInserted = "Hello!";
        string validKey = "Key";
        var insertedValue = Cache.Insert(validKey, valueToBeInserted);

        //Act
        var invalidResult = Cache.Get("Yo");

        //Assert
        Assert.Null(invalidResult);
    }
}
