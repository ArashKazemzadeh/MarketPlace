namespace Persistence.Repositories.MongoDb;

public interface ILoggingRepository
{
    Task LogInformation(string message, string title);
    Task LogWarning(string message, string title);
    Task LogError(string message, string title);
}