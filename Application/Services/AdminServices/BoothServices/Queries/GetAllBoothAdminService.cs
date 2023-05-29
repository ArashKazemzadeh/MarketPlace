using Application.IServices.AdminServices.BoothServices.Queries;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Queries
{
    public class GetAllBoothAdminService : IGetAllBoothAdminService
    {
        private readonly IBoothRepository _boothRepository;
        private readonly IMapper _mapper;

        public GetAllBoothAdminService(IBoothRepository boothRepository, IMapper mapper)
        {
            _boothRepository = boothRepository;
            _mapper = mapper;
        }

        public async Task<List<BoothDto>> Execute()
        {
            var booths = await _boothRepository.GetAllAsync();
            var boothDtos = _mapper.Map<List<BoothDto>>(booths);
            return boothDtos;
        }
    }

}
