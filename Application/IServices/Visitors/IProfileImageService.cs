using Application.Dtos;
using Domin.IRepositories.Dtos;

namespace Application.IServices.Visitors;

public interface IProfileImageService
{
    Task<bool> DeleteProfileImage(int id);
    Task<bool> UploadProfileImage(int sellerId, string imageUrl);
    Task<GeneralDto<ImageUserDto>> GetProfileImage(int sellerId);
}