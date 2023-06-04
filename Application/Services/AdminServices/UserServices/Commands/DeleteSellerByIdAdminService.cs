

using Application.Dtos;
using Application.IServices.AdminServices.UserService.Commands;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.UserServices.Commands
{
    public class DeleteSellerByIdAdminService : IDeleteSellerByIdAdminService
    {
        private readonly ISellerRepository _sellerRepository;

        public DeleteSellerByIdAdminService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        public async Task<GeneralDto> Execute(int id)
        {
          await  _sellerRepository.DeleteAsync(id);
          return new GeneralDto
          {
              message = "عملیات با موفقیت انجام شد"
          };
        }
    }
}
