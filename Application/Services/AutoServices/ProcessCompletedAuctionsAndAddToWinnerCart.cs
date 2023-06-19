﻿using Application.IServices.AutoServices;
using Domin.IRepositories.IseparationRepository;
namespace Application.Services.AutoServices;

public class ProcessCompletedAuctionsAndAddToWinnerCart : IProcessCompletedAuctionsAndAddToWinnerCart
{
    private readonly IAutomaticTasksOfTheApplicationRepository _automaticTasksOfTheApplicationRepository;
    public ProcessCompletedAuctionsAndAddToWinnerCart(IAutomaticTasksOfTheApplicationRepository automaticTasksOfTheApplicationRepository)
    {
        _automaticTasksOfTheApplicationRepository = automaticTasksOfTheApplicationRepository;
    }
    public async Task Execute()
    {
        await _automaticTasksOfTheApplicationRepository.ProcessCompletedAuctions();
    }
}


