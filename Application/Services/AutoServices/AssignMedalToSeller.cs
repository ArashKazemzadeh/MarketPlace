using Application.Dtos;
using Application.IServices.AutoServices;
using ConsoleApp1.Models;
using Domin.Enums;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using ZstdSharp;

namespace Application.Services.AutoServices;



public class AssignMedalToSeller : IAssignMedalToSeller
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IMedalRepository _medalRepository;

    public AssignMedalToSeller(ISellerRepository sellerRepository, IMedalRepository medalRepository)
    {
        _sellerRepository = sellerRepository;
        _medalRepository = medalRepository;
    }


    public async Task Execute()
    {
        var sellers = await _sellerRepository.GetAllAsync();

        foreach (var seller in sellers)
        {
            var saleAmount = seller.SalesAmount;
            if (seller.Medals.Count == 0 || seller.Medals==null && saleAmount > 1000)
            {

                var bronzeMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Bronze);
                if (bronzeMedal != null)
                {
                    seller.Medals.Add(bronzeMedal);

                }
                else
                {
                    await _medalRepository.AddAsync(new Medal { Type = MedalEnum.Bronze });
                    seller.Medals.Add(bronzeMedal);

                }

                seller.CommissionPercentage = 0.09;
            }

            if (!seller.Medals.Any(m => m.Type == MedalEnum.Silver) && saleAmount > 5000)
            {
                var silverMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Silver);
                if (silverMedal != null)
                {
                    seller.Medals.Add(silverMedal);

                }
                else
                {
                    await _medalRepository.AddAsync(new Medal { Type = MedalEnum.Silver });
                    seller.Medals.Add(silverMedal);

                }
                seller.CommissionPercentage = 0.07;

            }

            if (!seller.Medals.Any(m => m.Type == MedalEnum.Gold) && saleAmount > 10000)
            {
                var goldMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Gold);
                if (goldMedal != null)
                {
                    seller.Medals.Add(goldMedal);

                }
                else
                {
                    await _medalRepository.AddAsync(new Medal { Type = MedalEnum.Gold });
                    seller.Medals.Add(goldMedal);

                }
                seller.CommissionPercentage = 0.05;

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



