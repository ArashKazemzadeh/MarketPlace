using Application.IServices.SellerServices.ProfileServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Address;
using Domin.IRepositories.Dtos.Booth;
using Domin.IRepositories.Dtos.Seller;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.SellerServices.ProfileServices.Commands;

public class AddSellerService: IAddSellerService
{
        private readonly ISellerRepository _sellerRepository;
        private readonly IBoothRepository _boothRepository;
        private readonly IAddressRepository _addressRepository;

        public AddSellerService(ISellerRepository sellerRepository,
            IBoothRepository boothRepository, IAddressRepository addressRepository)
        {
            _sellerRepository = sellerRepository;
            _boothRepository = boothRepository;
            _addressRepository = addressRepository;
        }

        public async Task<string> Execute(AddSellerDto addSellerDto)
        {
            if (addSellerDto==null)
            {
                return "اطلاعات دریافت نشد.";
            }
            var addressDto = new AddressRepDto
            {
                City = addSellerDto.City,
                Street = addSellerDto.Street,
                Description = addSellerDto.AddressDescription,
                SellerId = addSellerDto.SellerId
            };

            var boothDto = new BoothRepDto
            {
                Name = addSellerDto.BoothName,
                Description = addSellerDto.BoothDescription,
                SellerId = addSellerDto.SellerId
            };

            var sellerDto = new SellerRepDto
            {
                Id = addSellerDto.SellerId,
                CompanyName = addSellerDto.CompanyName,
                CommissionPercentage = 0.1
            };
            await _sellerRepository.AddAsync(sellerDto);
            await _addressRepository.AddAsync(addressDto);
            await _boothRepository.AddAsync(boothDto);

            return "فروشنده جدید با موفقیت ایجاد شد.";
        }
    }



