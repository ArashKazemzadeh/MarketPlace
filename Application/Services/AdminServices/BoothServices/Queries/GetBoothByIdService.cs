using Application.Dtos;
using Application.IServices.AdminServices.BoothServices.Queries;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.BoothServices.Queries
{
    public class GetBoothByIdService : IGetBoothByIdService
    {
        private readonly IBoothRepository _boothRepository;
        private readonly IMapper _mapper;

        public GetBoothByIdService(IBoothRepository boothRepository, IMapper mapper)
        {
            _boothRepository = boothRepository;
            _mapper = mapper;
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

            var boothDto = _mapper.Map<BoothDto>(booth);
            return new GeneralDto<BoothDto>
            {
                Data = boothDto,
                message = "عملیات با موفقیت انجام شد."
            };
        }

    }

}
