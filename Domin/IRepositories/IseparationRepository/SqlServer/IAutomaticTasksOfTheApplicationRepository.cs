using Microsoft.EntityFrameworkCore;

namespace Domin.IRepositories.IseparationRepository.SqlServer
{
    public interface IAutomaticTasksOfTheApplicationRepository
    {
        Task ProcessCompletedAuctions();

    }
}


