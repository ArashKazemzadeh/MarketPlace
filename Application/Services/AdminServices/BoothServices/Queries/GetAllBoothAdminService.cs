﻿using Application.IServices.AdminServices.BoothServices.Queries;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Queries
{
    public class GetAllBoothAdminService : IGetAllBoothAdminService
    {
        private readonly IBoothRepository _boothRepository;
        public GetAllBoothAdminService(IBoothRepository boothRepository, IMapper mapper)
        {
            _boothRepository = boothRepository;
        }
        public async Task<List<BoothDto>> Execute()
        {
            var booths = await _boothRepository.GetAllAsync();
            var boothDtos = booths.Select(booth => new BoothDto
            {
                Id = booth.Id,
                Name = booth.Name,
                Description = booth.Description
            }).ToList();
            return boothDtos;
        }
    }
}
