using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.UserServices.SellerService.Commands
{
    public class UpdateSellerAdminService : IUpdateSellerAdminService
    {
        private readonly ISellerRepository _sellerRepository;
        public UpdateSellerAdminService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<GeneralDto> Execute(SellerDto sellerDto)
        {
            var seller = new SellerUpdateRepositoryDto
            {
                Id = sellerDto.Id,
                IsActive = sellerDto.IsActive,
                CompanyName = sellerDto.CompanyName,
                IsRemoved = sellerDto.IsRemoved,
                CommissionPercentage = sellerDto.CommissionPercentage

            };
            var result = await _sellerRepository.UpdateAsync(seller);
            if (result)
            {
                return new GeneralDto()
                {
                    message = "عملیات با موفقین انجام شد"
                };
            }
            else
            {
                return new GeneralDto()
                {
                    message = "کاربر موجود نیست"
                };
            }
        }
    }
}
//public string? CompanyName { get; set; }
//public bool IsActive { get; set; }
//public bool IsRemoved { get; set; } = false;
//public double CommissionPercentage { get; set; }