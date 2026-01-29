using System;

namespace Solid_Exploration;

public class LiskovSubstitutionPrinsippExploration
{
    public static void Run()
    {
        var eagle = new Eagle();
        var penguin = new Penguin();

        MakeBirdsFly(eagle);
        //MakeBirdsFly(penguin); //Her forventer vi, basert på baseklassen å gjøre noe via fly metoden. Hva skjer egentlig?
        //Vi ser etter vi implementerte en ekstra mellomklasse med Fly, at penguin nå ikke er gyldig i MakeBirdsFly.
    }
    public static void MakeBirdsFly(BirdWithFlight bird) => bird.Fly();

}

public class Bird
{
    
}

public class BirdWithFlight: Bird
{
    public virtual void Fly() => Console.WriteLine("Flying!");
}

public class Eagle: BirdWithFlight
{
    public override void Fly() => Console.WriteLine("Flying like an eagle!");
}


public class Penguin: Bird
{
}
