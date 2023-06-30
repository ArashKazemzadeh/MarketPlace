using Application.IServices.SellerServices.ImageServices.Queries;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.File;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.SellerServices.ImageServices.Queries
{
    public class FilesQueryService : IFilesQueryService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IImageRepository _imageRepository;

        public FilesQueryService(ISellerRepository sellerRepository, IFileRepository fileRepository, IImageRepository imageRepository)
        {
            _sellerRepository = sellerRepository;
            _fileRepository = fileRepository;
            _imageRepository = imageRepository;
        }
        public async Task<List<FileGetDto>> GetAllFilesBySellerId(int sellerId)
        {
            var seller=await _sellerRepository.GetByIdAsync(sellerId);
            if (seller==null)
            {
                return new List<FileGetDto>();
            }

            var result = await _fileRepository.GetAllByOwnerFileIdAsync(sellerId);
            return result;
        }

        public async Task<FileGetDto> GetFile(int fileId)
        {
            var result = await _fileRepository.GetByIdAsync(fileId);
            return result;
        }
       
    }

   
}
