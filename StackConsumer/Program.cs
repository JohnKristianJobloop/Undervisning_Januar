// See https://aka.ms/new-console-template for more information
using GenericStackImplementation.Interfaces;
using GenericStackImplementation.Models;

Console.WriteLine("Hello, World!");

var intStack = new IntegerStack(10);

intStack.Push(5);
var popped = intStack.Pop();

Console.WriteLine(popped);

var objStack = new ObjectStack(10);

objStack.Push(5);

objStack.Push("Hello!");

var poppedObj = objStack.Pop();

Console.WriteLine(poppedObj); //hva er dette?

Console.WriteLine(poppedObj.GetType());

var stringStack = new GenericStack<string>(10);

for (var i = 0; i < 10; i++)
{
    stringStack.Push($"I pushed in {i}");
}

var listStack = new GenericStack<List<string>>(10);

var carStack = new GenericStack<Car>(10);

Car vehicle = new();

carStack.Push(vehicle);

Vehicle poppedVehicle = carStack.Pop();


foreach (var sentence in stringStack) Console.WriteLine(sentence);

var sentencesIncludingNumberEight = stringStack.Where(sentence => sentence.Contains("8"));

foreach(var sentence in sentencesIncludingNumberEight) Console.WriteLine(sentence);

