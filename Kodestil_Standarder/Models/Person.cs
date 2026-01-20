namespace Kodestil_Standarder.Models;

public class Person
{
    public string? Name
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value cannot be an empty string");
            field = value;
        }
    }
    public int Age;
    private int _privatePersonId = Random.Shared.Next(1,50);
    public bool VerifyId(int id) => id == _privatePersonId;
}
