namespace BooksStore.Services;

public class ConsoleLoggingService : ILoggingService
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
