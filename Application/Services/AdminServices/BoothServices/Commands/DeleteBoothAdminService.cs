using Application.Dtos;
using Application.IServices.AdminServices.BoothServices.Commands;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Commands
{
    public class DeleteBoothAdminService : IDeleteBoothAdminService
    {
        private readonly IBoothRepository _boothRepository;

        public DeleteBoothAdminService(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
        }

        public async Task<GeneralDto> Execute(int id)
        {
            var existingBooth =await _boothRepository.GetByIdAsync(id);
            if (existingBooth == null)
            {
                return new GeneralDto { message = "غرفه مورد نظر یافت نشد." };
            }

         await   _boothRepository.DeleteAsync(existingBooth);
            return new GeneralDto { message = "غرفه با موفقیت حذف شد." };
        }

    }
}
