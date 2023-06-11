using Application.Dtos;
using Application.IServices.AdminServices.BoothServices.Commands;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.Dtos;
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
        public async Task<GeneralDto> Execute(BoothDto boothDto)
        {
            var existingBooth = await _boothRepository.GetByIdAsync(boothDto.Id);
            if (existingBooth == null)
                return new GeneralDto
                {
                    message = "غرفه یافت نشد."
                };
            var booth = new BoothRepDto
            {
                Name = boothDto.Name,
                Description = boothDto.Description,
                BoothId = boothDto.Id
            };
            await _boothRepository.UpdateBoothAsync(booth);

            return new GeneralDto
            {
                message = "به روز رسانی انجام شد."
            };
        }

    }
}
