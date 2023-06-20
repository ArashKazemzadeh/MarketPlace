using Application.IServices.AutoServices;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AutoServices
{
    public class CalculationOfSalesAndTheCommissionAmountOfEachSeller: ICalculationOfSalesAndTheCommissionAmountOfEachSeller
    {
        private readonly IAutomaticTasksOfTheApplicationRepository _automaticTasksOfTheApplicationRepository;
        public CalculationOfSalesAndTheCommissionAmountOfEachSeller(IAutomaticTasksOfTheApplicationRepository automaticTasksOfTheApplicationRepository)
        {
            _automaticTasksOfTheApplicationRepository = automaticTasksOfTheApplicationRepository;
        }

        public async Task Execute()
        {
          await  _automaticTasksOfTheApplicationRepository.CalculateCommissions();
        }
    }
}
