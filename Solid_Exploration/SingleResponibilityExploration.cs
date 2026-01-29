using System;

namespace Solid_Exploration;

public class SingleResponibilityExploration(IEmailHandler emailHandler, IDatabaseHandler dbHandler, ILogger logger)
{

    public void HandleOrder(Order order)
    {
        emailHandler.SendConfirmation(order);
        dbHandler.StoreOrder(order);
        logger.LogOrder(order);
    }
    //Vi må kunne ta i mot en ordre fra en kunde, typ varebestilling. 
    //Den må loggføres
    /*private void AppendOrderToLogFile(int orderId, string logFileLocation)
    {
        //...
        //Her måtte vi hatt en oversikt over filehandling og log systemer. 
    }

    //Vi må kunne lagre ordren til en database:
    private void SaveOrderToDatabase(Order order)
    {
        //...
        //Denne metoden måtte hatt en oversikt over database og tilkobling til den. Dette måtte også objektet hatt.
    }
    private void SendEmail(string emailAddress, string emailBody)
    {
        //...
        //Her måtte vi hatt en oversikt over en epostklient, vi kan bruke for å faktisk sende eposter.
    }
    */

}
public record Order(int Id, string Email);

public class EmailHandler : IEmailHandler
{
    public void SendConfirmation(Order order){}
}

public class SuperDuperEmailHandler : IEmailHandler
{
    public void SendConfirmation(Order order)
    {
        throw new NotImplementedException();
    }
}

public interface IEmailHandler
{
    void SendConfirmation(Order order);
}

public class DatabaseHandler()
{
    public void StoreOrder(Order order){}
}

public interface IDatabaseHandler
{
    void StoreOrder(Order order);
}

public class Logger()
{
    public void LogOrder(Order order){}
}

public interface ILogger
{
    void LogOrder(Order order);
}
