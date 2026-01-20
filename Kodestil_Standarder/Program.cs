namespace Kodestil_Standarder;

using Kodestil_Standarder.Models;

class Program
{
    static void Main(string[] args)
    {
        int integer = 10;
        const int constantNumber = 43;
        float floatNum = 0.5f;
        double doubleNum = 0.6;
        decimal decimalNum = 0.7m;
        long longNum = 123123;
        char charA = 'A';

        string word = "Hello!";
        bool check = true;

        var someValue = 1; //0001
        var someOtherValue = 2;//0010

        var either = someValue | someOtherValue;
        Console.WriteLine(either); //0011
        someValue = 10;

        var studentGradesTable = new Dictionary<string, List<int>>()
        {
            {"John", [3,4,3,5,5,6]}
        };

        var studentNames = studentGradesTable.Select(keyValuePair => keyValuePair.Key).ToList();

        var someArray = new int[3]; //[0,0,0]

        int[] someOtherArray = [3]; //[3]

        List<string> names = ["Anders", "John", "Kevin", "Håkon"];

        List<string> someList = [];

        Dictionary<int, int> someDictionary = [];

        int[] someEmptyArray = [];

        var num = someArray[2];

        Dictionary<string, int> nameAndAge = new()
        {
            ["John"] = 33
        };

        var person = new Person
        {
            Age = 33
        };
        var verified = person.VerifyId(20);

        var name = person.Name ?? "Default Name";
    }
}



public class PersonWithBackingFields
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    private int _age;

    public int Age
    {
        get => _age;
        set
        {
        if( value > 150 || value < 0) throw new ArgumentException("Invalid Age");
        _age = value;
        }
    }
    private int _privatePersonId = Random.Shared.Next(1,50);
    public bool VerifyId(int id) => id == _privatePersonId;
}

public interface IPersonService
{
    public List<Person> GetPeople();
    public Person Find(Func<Person, bool> filter);
}

public record StudentOverview(string StudentName, string Class);
