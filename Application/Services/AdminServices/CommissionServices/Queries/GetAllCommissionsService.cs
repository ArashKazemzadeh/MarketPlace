using Application.IServices.AdminServices.CommissionServices.Queries;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.CommissionServices.Queries;

public class GetAllCommissionsService : IGetAllCommissionsService
{
    private readonly ISellerRepository _sellerRepository;

    public GetAllCommissionsService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<int> Execute()
    {
        var sellers = await _sellerRepository.GetAllAsync();
        int totalCommissionsAmount = sellers.Sum(seller => seller.CommissionsAmount.GetValueOrDefault());
        return totalCommissionsAmount;
    }
}


