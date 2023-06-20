using Application.Dtos;
using Application.IServices.AdminServices.BoothServices.Queries;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Queries
{
    public class GetBoothByIdService : IGetBoothByIdService
    {
        private readonly IBoothRepository _boothRepository;
        public GetBoothByIdService(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
        }
        public async Task<GeneralDto<BoothDto>> Execute(int id)
        {
            var booth = await _boothRepository.GetByIdAsync(id);
            if (booth == null)
            {
                return new GeneralDto<BoothDto>
                {
                    message = "غرفه یافت نشد."
                };
            }

            var boothDto = new BoothDto
            {
                Id = booth.Id,
                Name = booth.Name,
                Description = booth.Description
            };

            return new GeneralDto<BoothDto>
            {
                Data = boothDto,
                message = "عملیات با موفقیت انجام شد."
            };
        }

    }

}
