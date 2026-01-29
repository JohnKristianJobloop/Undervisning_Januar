using System;

namespace Solid_Exploration;

public class OpenClosedPrinsippExploration
{
    //Her er ansvaret for å koble en discount og en type, flyttet vekk fra dette objektet. Vi gjør bare utregningen, slik metoden sier den skal.
    public decimal CalculateDiscountForEachCustomerType(CustomerTypes type, decimal amount) => amount * ((decimal) (100-type)/100);
    /*
    //Når vi legger til en ny CustomerType i CustomerTypes, må også denne metoden endre seg, for å forhindre exceptions.
    //Da følger ikke lengre denne classen Open Closed principle, siden enumen og objektet er explisitt linket sammen.
    public decimal CalculateDiscountForEachCustomerType(CustomerTypes type, decimal amount)
    {
        return type switch
        {
            CustomerTypes.Regular => amount * 0.95m,
            CustomerTypes.VIP => amount * 0.80m,
            CustomerTypes.SuperVIP => amount * 0.75m,
            CustomerTypes.SuperDuperVIP => amount * 0.70m,
            _ => throw new NotSupportedException("Uknown customer type")
        };
    }
    */
}

//CustomerTypes har nå ansvaret for å koble en customer type, til en discount. 
//Legger vi til en ny customer type her, vil det ikke føre til problemer i utregning.
public enum CustomerTypes
{
    Regular = 5,
    VIP = 20,
    SuperVIP = 25,
    SuperDuperVIP = 30
}

/*
public enum CustomerTypes
{
    Regular,
    VIP,
    SuperVIP,
    SuperDuperVIP
}
*/