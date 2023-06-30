using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
namespace Domin.IRepositories.IseparationRepository;


public interface IImageRepository
{
    Task<Image> GetProfileImageBySellerId(int sellerId);
    Task<Image> GetBySellerIdAsync(int sellerId);
    Task<Image> GetByIdAsync(int imageId);
    Task<List<ImageForProductRepDto>> GetAllImageProductBySellerId(int sellerId);
    Task<IEnumerable<Image>> GetImagesForProductAsync(int productId);
    Task<int> AddAsync(ImageForProductRepDto image);
    Task<int> AddAsync(ImageUserAddDto image);
   
     Task<bool> RemoveAsync(int id);
    Task<Image> GetByUrlAsync(string url);
    Task<bool> RemoveAsync(string url);

}
