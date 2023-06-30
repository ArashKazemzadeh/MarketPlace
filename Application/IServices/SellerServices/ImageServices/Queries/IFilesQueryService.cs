
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.File;
namespace Application.IServices.SellerServices.ImageServices.Queries;




public interface IFilesQueryService
{
  
    Task<FileGetDto> GetFile(int fileId);
    Task<List<FileGetDto>> GetAllFilesBySellerId(int sellerId);
}