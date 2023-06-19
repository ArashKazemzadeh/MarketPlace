using Domin.IRepositories.IseparationRepository;
namespace Application.Services.AutoServices;




public interface IProcessCompletedAuctionsAndAddToWinnerCart
{
    Task Execute();
}
public class ProcessCompletedAuctions : IProcessCompletedAuctionsAndAddToWinnerCart
{
    private readonly IAutomaticTasksOfTheApplicationRepository _automaticTasksOfTheApplicationRepository;
    public ProcessCompletedAuctions(IAutomaticTasksOfTheApplicationRepository automaticTasksOfTheApplicationRepository)
    {
        _automaticTasksOfTheApplicationRepository = automaticTasksOfTheApplicationRepository;
    }
    public async Task Execute()
    {
        await _automaticTasksOfTheApplicationRepository.ProcessCompletedAuctions();
    }
}


