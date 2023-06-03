using Application.Dtos;
using Application.IServices.AdminServices.MedalServices.Commands;
using ConsoleApp1.Models;
using Domin.Enums;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.MedalServices.Commands;



public class AssignMedalToSellerBySellerIdService : IAssignMedalToSellerBySellerIdService
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IMedalRepository _medalRepository;

    public AssignMedalToSellerBySellerIdService(ISellerRepository sellerRepository, IMedalRepository medalRepository)
    {
        _sellerRepository = sellerRepository;
        _medalRepository = medalRepository;
    }

    // متد برای اختصاص مدال به فروشنده بر اساس شناسه
    public async Task<GeneralDto> Execute(int sellerId)
    {
        var seller = await _sellerRepository.GetByIdAsync(sellerId);

        if (seller == null)
        {
            return new GeneralDto { message = "فروشنده یافت نشد." };
        }

        if (seller.Medals.Count == 0)
        {
            var bronzeMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Bronze);
            if (bronzeMedal != null)
            {
                seller.Medals.Add(bronzeMedal);

            }
            else
            {
             await   _medalRepository.AddAsync(new Medal { Type = MedalEnum.Bronze });
                seller.Medals.Add(bronzeMedal);

            }
            return new GeneralDto { message = "نشان برنز اختصاص داده شد." };
        }

        if (!seller.Medals.Any(m => m.Type == MedalEnum.Silver))
        {
            var silverMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Silver);
            if (silverMedal != null)
            {
             seller.Medals.Add(silverMedal);
               
            }
            else
            {
             await   _medalRepository.AddAsync(new Medal { Type = MedalEnum.Silver });
                seller.Medals.Add(silverMedal);

            }
            return new GeneralDto { message = "نشان نقره اختصاص داده شد." };
        }

        if (!seller.Medals.Any(m => m.Type == MedalEnum.Gold))
        {
            var goldMedal = await _medalRepository.GetMedalByTypeAsync(MedalEnum.Gold);
            if (goldMedal != null)
            {
                seller.Medals.Add(goldMedal);
            }
            else
            {
           await     _medalRepository.AddAsync(new Medal { Type = MedalEnum.Gold });
                seller.Medals.Add(goldMedal);

            }
            return new GeneralDto { message = "نشان طلا اختصاص داده شد." };

        }

        if (seller.Medals.Any(m => m.Type == MedalEnum.Gold) && seller.Medals.Any(m => m.Type == MedalEnum.Silver) && seller.Medals.Any(m => m.Type == MedalEnum.Bronze))
        {
            return new GeneralDto { message = "فروشنده همه سه نشان را دارد." };
        }

        return new GeneralDto();
    }


}



