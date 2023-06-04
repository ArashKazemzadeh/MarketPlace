using Application.Dtos;
using Common.Mappers;
using ConsoleApp.Models;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.UserServices.Queries
{
    public interface IGetSellerByIdAdminService
    {
        Task<GeneralDto<SellerDto>> Execute(int id);
    }
    public class GetSellerByIdAdminService : IGetSellerByIdAdminService
    {
        private readonly ISellerRepository _sellerRepository;
        public GetSellerByIdAdminService(ISellerRepository sellerRepository,
            ICustomMapper<SellerDto, Seller> mapper)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<GeneralDto<SellerDto>> Execute(int id)
        {
            var result = await _sellerRepository.GetByIdAsync(id);
            if (result == null)
            {
                return new GeneralDto<SellerDto>
                {
                    message = "کاربر موجود نیست"
                };
            }
            else
            {
                return new GeneralDto<SellerDto>
                {
                    message = "کاربریافت شد",
                    Data = new SellerDto
                    {
                        Id = result.Id,
                        CompanyName = result.CompanyName,
                        IsRemoved = result.IsRemoved,
                        IsActive = result.IsActive,
                        CommissionPercentage=result.CommissionPercentage
                    }
                };
            }
        }
    }
}
