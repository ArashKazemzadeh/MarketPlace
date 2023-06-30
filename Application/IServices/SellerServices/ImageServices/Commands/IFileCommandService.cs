using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.File;
namespace Application.IServices.SellerServices.ImageServices.Commands;



public interface IFileCommandService
{
  
    Task<string> UploadFile(int sellerId, FileAddDto inputDto);
    Task<string> DeleteFile(int fileId);
}