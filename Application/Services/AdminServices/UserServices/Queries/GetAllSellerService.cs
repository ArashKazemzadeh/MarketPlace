using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.UserServices.Queries
{
    public interface IGetAllSellerService
    { Task<List<SellerDto>> Execute();
    }

    public class GetAllSellerService: IGetAllSellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        public GetAllSellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;   
        }
        public async Task<List<SellerDto>> Execute()
        {
         var existSellers= await _sellerRepository.GetAllAsync();
         List<SellerDto> sellerDtos = existSellers.Select(s => new SellerDto
         {
             Id = s.Id,
             CompanyName = s.CompanyName,
             CommissionsAmount = s.CommissionsAmount,
             CommissionPercentage = s.CommissionPercentage,
             SalesAmount = s.SalesAmount
         }).ToList();
         return sellerDtos;
        }
    }
}
