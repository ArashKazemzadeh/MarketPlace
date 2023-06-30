using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Domin.IRepositories.Dtos;
using Application.IServices.Visitors;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.Visitors.ProfileImageService
{
    public class ProfileImageService : IProfileImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ISellerRepository _sellerRepository;

        public ProfileImageService(IImageRepository imageRepository, ISellerRepository sellerRepository)
        {
            _imageRepository = imageRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<bool> DeleteProfileImage(int id)
        {
            var result = await _imageRepository.RemoveAsync(id);
            return result;
        }

        public async Task<bool> UploadProfileImage(int sellerId, string imageUrl)
        {
            var seller = await _sellerRepository.GetByIdAsync(sellerId);
            if (seller == null)
                return false;

            var image = await _imageRepository.GetBySellerIdAsync(sellerId);
            if (image != null)
                await _imageRepository.RemoveAsync(image.Id);
            

            var newImage = new ImageUserAddDto
            {
                SellerId = sellerId,
                Url = imageUrl
            };
            var result = await _imageRepository.AddAsync(newImage);
            if (result==0)
            {
                return false;
            }

            return true;
        }

       
      

        public async Task<GeneralDto<ImageUserDto>> GetProfileImage(int sellerId)
        {
            var result =await _imageRepository.GetProfileImageBySellerId(sellerId);
            if (result == null)
                return new GeneralDto<ImageUserDto>
                {
                    message = "eagle-png-logo"
                };
            return new GeneralDto<ImageUserDto>
            {
                message = null,
                Data = new ImageUserDto
                {
                    Id = result.Id,
                    Url = result.Url,
                    SellerId = result.SellerId
                        
                }
            };
        }

    }
}
