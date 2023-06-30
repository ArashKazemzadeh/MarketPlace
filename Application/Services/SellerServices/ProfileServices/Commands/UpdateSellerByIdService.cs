using Application.IServices.SellerServices.ProfileServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.SellerServices.ProfileServices.Commands;




public class UpdateSellerByIdService : IUpdateSellerByIdService
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IBoothRepository _boothRepository;
    private readonly IAddressRepository _addressRepository;

    public UpdateSellerByIdService(ISellerRepository sellerRepository,
        IBoothRepository boothRepository, IAddressRepository addressRepository)
    {
        _sellerRepository = sellerRepository;
        _boothRepository = boothRepository;
        _addressRepository = addressRepository;
    }
    public async Task<bool> Execute(AddSellerDto updateSellerDto)
    {
        var update = await _sellerRepository.UpdateProfileAsync(updateSellerDto);
        int? addressId = updateSellerDto.AddressId;
        if (addressId != 0)
        {
            var addressDto = new AddressRepDto
            {
                AddressId  = addressId,
                City = updateSellerDto.City,
                Street = updateSellerDto.Street,
                Description = updateSellerDto.AddressDescription
            };
            await _addressRepository.UpdateAsync(addressDto);
        }
        int? boothId = updateSellerDto.AddressId;
        if (boothId != 0)
        {
            var boothDto = new BoothRepDto()
            {
                BoothId = boothId,
                Name = updateSellerDto.BoothName,
                Description = updateSellerDto.BoothDescription
            };
            await _boothRepository.UpdateBoothAsync(boothDto);
        }
        if (update)
            return true;
        return false;
    }
}

