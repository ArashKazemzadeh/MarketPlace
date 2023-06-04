using Application.Dtos;
using Application.IServices.AdminServices.BoothServices.Commands;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Commands
{
    public class UpdateBoothAdminService : IUpdateBoothAdminService
    {
        private readonly IBoothRepository _boothRepository;

        public UpdateBoothAdminService(IBoothRepository boothRepository, IMapper mapper)
        {
            _boothRepository = boothRepository;
        }
        public async Task<GeneralDto> Execute(BoothDto booth)
        {
            var existingBooth = await _boothRepository.GetByIdAsync(booth.Id);
            if (existingBooth == null)
                return new GeneralDto
                {
                    message = "غرفه یافت نشد."
                };
            existingBooth.Name = booth.Name;
            existingBooth.Description = booth.Description;
            await _boothRepository.UpdateAsync(existingBooth);

            return new GeneralDto
            {
                message = "به روز رسانی انجام شد."
            };
        }

    }
}
