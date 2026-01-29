using System.ComponentModel;

namespace Test;

public class UnitTest1
{
    //Vi har en del forskjellige tester.

    //Fact sier en spesifikk ting, om en spesifikk hendelse i applikasjonen vår. Tenk gitt hendelse A, så skjer hendelse B. 
    [Fact]
    public void Test1()
    {
        //Arrange, sett opp startpunktet til testen
        int a = 1;
        int b = 2;
        Func<int, int, int>sum=(a,b) => a+b;

        //Act, utfør handlingen som skal testes
        int result = sum(a,b);

        //Assert, kom med en påstand om utfall av handling. 
        Assert.Equal(a+b, result);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test2(int a, int b)
    {
        //Arrange
        Func<int, int, int>sum=(a,b) => a+b;
        //Act
        int result = sum(a,b);
        //Assert
        Assert.Equal(a + b, result);
    }

    public static IEnumerable<object[]> TestData =>
    [
        [1,4],[6,8],[95,234],[36,85]
    ];
}
