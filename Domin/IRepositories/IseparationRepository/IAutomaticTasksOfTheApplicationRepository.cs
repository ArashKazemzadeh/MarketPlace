

using Microsoft.EntityFrameworkCore;

namespace Domin.IRepositories.IseparationRepository
{
    public interface IAutomaticTasksOfTheApplicationRepository
    {
        Task ProcessCompletedAuctions();
        Task CalculateCommissions();
        Task AggregateCommissionsForAdmin();
    }
}


