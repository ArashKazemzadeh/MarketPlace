using Application.Interfaces.Contexts;
using Domin.Entities.Logss;
using Serilog;

namespace Persistence.Repositories.MongoDb
{
public class LoggingRepository : ILoggingRepository
    {
        private readonly ILogger _logger;
        private readonly IMongoDbContext<LogInformation> _mongoDbContext;

        public LoggingRepository(ILogger logger, IMongoDbContext<LogInformation> mongoDbContext)
        {
            _logger = logger;
            _mongoDbContext = mongoDbContext;
        }

        public async Task LogInformation(string message, string title = "!")
        {
            var logInformation = new LogInformation
            {

                Title = $"Information - {title}",
                Message = message,
                Timestamp = DateTime.Now
            };

          _logger.Information("Logging information: {LogInformation}", $"{logInformation.Message } - {logInformation.Title}");
          _mongoDbContext.GetCollection().InsertOne(logInformation);

        }

        public async Task LogWarning(string message, string title = "!")
        {
            var logInformation = new LogInformation
            {
                Title = $"Warning - {title}",
                Message = message,
                Timestamp = DateTime.Now
            };

            _logger.Warning("Logging warning: {LogWarning}", $"{logInformation.Message} - {logInformation.Title}");

            _mongoDbContext.GetCollection().InsertOne(logInformation);


        }

        public async Task LogError(string message, string title = "!")
        {
            var logInformation = new LogInformation
            {

                Title = $"Error - {title}",
                Message = message,
                Timestamp = DateTime.Now
            };

          _logger.Error("Logging error: {LogError}",
                $"{logInformation.Message} - {logInformation.Title}");
            _mongoDbContext.GetCollection().InsertOne(logInformation);


        }
    }
}


