using Application.IServices.AutoServices;
using Application.IServices.LogServices;
using Domin.IRepositories.IseparationRepository.SqlServer;
namespace Application.Services.AutoServices;

public class ProcessCompletedAuctionsAndAddToWinnerCart : IProcessCompletedAuctionsAndAddToWinnerCart
{
    private readonly IAutomaticTasksOfTheApplicationRepository _automaticTasksOfTheApplicationRepository;
    private readonly ILogingService _logingService;
    public ProcessCompletedAuctionsAndAddToWinnerCart(
        IAutomaticTasksOfTheApplicationRepository automaticTasksOfTheApplicationRepository,
        ILogingService logingService)
    {
        _automaticTasksOfTheApplicationRepository = automaticTasksOfTheApplicationRepository;
        _logingService = logingService;
    }
    public async Task Execute()
    {
      var result=  await _automaticTasksOfTheApplicationRepository.ProcessCompletedAuctions();
    await  _logingService.LogInformation(result, "Auction Result" );
    }
}


