using Application.IServices.LogServices;
using Persistence.Repositories.MongoDb;

namespace Application.Services.LogService;

public class LogingService : ILogingService
{


    private readonly ILoggingRepository _loggingRepository;

    public LogingService(ILoggingRepository loggingRepository)
    {
        _loggingRepository = loggingRepository;
    }

    public async Task LogError(string message, string title)
    {
        await _loggingRepository.LogError(message, title);
    }

    public async Task LogInformation(string message, string title)
    {
        await _loggingRepository.LogInformation(message, title);
    }

    public async Task LogWarning(string message, string title)
    {
        await _loggingRepository.LogWarning(message, title);
    }
}