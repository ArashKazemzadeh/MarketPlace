using Application.IServices.AutoServices;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AutoServices
{
    public class AggregateCommissionsForAdmin: IAggregateCommissionsForAdmin
    {
        private readonly IAutomaticTasksOfTheApplicationRepository _automaticTasksOfTheApplicationRepository;
        public AggregateCommissionsForAdmin(IAutomaticTasksOfTheApplicationRepository automaticTasksOfTheApplicationRepository)
        {
            _automaticTasksOfTheApplicationRepository = automaticTasksOfTheApplicationRepository;
        }

        public async Task Execute()
        {
            await _automaticTasksOfTheApplicationRepository.AggregateCommissionsForAdmin();
        }
    }
}
