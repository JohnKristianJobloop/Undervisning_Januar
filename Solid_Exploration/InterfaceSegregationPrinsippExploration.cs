using System;
using System.Runtime.CompilerServices;

namespace Solid_Exploration;

public class InterfaceSegregationPrinsippExploration
{
    public void Run()
    {
        IPrintable printer = new SimpleCanonLaserPrinter();
        printer.Print("Hello!");

        /*
        var someText = printer.Scan(); //Hva sier kontrakten? Hva sier objektet?

        printer.Fax(123123);
        */
        ICombo comboMaskine = new PrinterScannerCombo();
        comboMaskine.Print("Hello!");
        var input = comboMaskine.Scan();

        PrintWithPrinter(comboMaskine, "HEllo!");

        PrintWithPrinter(printer, "Yo!");

    }

    public static void PrintWithPrinter(IPrintable printer, string text) => printer.Print(text);

}

public interface IPrintable
{
    void Print(string text);
}

public interface IScannable
{
    string Scan();
}

public interface IFaxable
{
    void Fax(int teleServer);
}


public interface IPrinter
{
    void Print(string text);

    string Scan();

    void Fax(int teleServer);
}

public interface ICombo: IScannable, IPrintable;
public class SimpleCanonLaserPrinter : IPrintable
{
    public void Fax(int teleServer)
    {
        throw new NotImplementedException();
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public string Scan()
    {
        throw new NotImplementedException();
    }
}

public class PrinterScannerCombo : ICombo
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public string Scan()
    {
        return Console.ReadLine()!;
    }
}