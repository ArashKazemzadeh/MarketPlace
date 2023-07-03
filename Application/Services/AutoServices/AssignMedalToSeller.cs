using Application.Dtos;
using Application.IServices.AutoServices;
using Application.IServices.LogServices;
using ConsoleApp1.Models;
using Domin.Enums;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Seller;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.Extensions.Configuration;
using ZstdSharp;

namespace Application.Services.AutoServices;



public class AssignMedalToSeller : IAssignMedalToSeller
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IMedalRepository _medalRepository;
    private readonly ILogingService _logingService;
    public AssignMedalToSeller(ISellerRepository sellerRepository, IMedalRepository medalRepository, ILogingService logingService)
    {
        _sellerRepository = sellerRepository;
        _medalRepository = medalRepository;
        _logingService = logingService;
    }


    public async Task Execute()
    {
        var sellers = await _sellerRepository.GetAllAsync();
        var medals = await _medalRepository.GetAllAsync();
        foreach (var seller in sellers)
        {
            var saleAmount = seller.SalesAmount;

            if (seller.Medals.Count == 0 && saleAmount > 1000)
            {
                var bronzeMedal = medals.FirstOrDefault(m => m.Type == MedalEnum.Bronze);
                if (bronzeMedal == null)
                {
                    bronzeMedal = new Medal { Type = MedalEnum.Bronze };
                    await _medalRepository.AddAsync(bronzeMedal);
                    medals.Add(bronzeMedal);
                }

                seller.Medals.Add(bronzeMedal);
                seller.CommissionPercentage = 0.09;
            }
            else if (!seller.Medals.Any(m => m.Type == MedalEnum.Silver) && saleAmount >= 5000)
            {
                var silverMedal = medals.FirstOrDefault(m => m.Type == MedalEnum.Silver);
                if (silverMedal == null)
                {
                    silverMedal = new Medal { Type = MedalEnum.Silver };
                    await _medalRepository.AddAsync(silverMedal);
                    medals.Add(silverMedal);
                }
                seller.Medals.Add(silverMedal);
                seller.CommissionPercentage = 0.07;
            }
            else if (!seller.Medals.Any(m => m.Type == MedalEnum.Gold) && saleAmount >= 10000)
            {
                var goldMedal = medals.FirstOrDefault(m => m.Type == MedalEnum.Gold);
                if (goldMedal == null)
                {
                    goldMedal = new Medal { Type = MedalEnum.Gold };
                    await _medalRepository.AddAsync(goldMedal);
                    medals.Add(goldMedal);
                }

                seller.Medals.Add(goldMedal);
                seller.CommissionPercentage = 0.05;
             await   _logingService.LogInformation(seller.CompanyName, MedalEnum.Gold.ToString());
            }
            var sellerDto = new SellerUpdateRepositoryDto
            {
                Id = seller.Id,
                CommissionPercentage = seller.CommissionPercentage,
                CompanyName = seller.CompanyName,
                IsActive = seller.IsActive,
                IsRemoved = seller.IsRemoved,
            };
            await _sellerRepository.UpdateAsync(sellerDto);
            
        }
    }
}



