using Application.IServices.SellerServices.ImageServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.File;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ImageServices.Commands
{
    public class FileCommandService : IFileCommandService
    {
        private readonly IFileRepository _fileRepository;
        private readonly ISellerRepository _sellerRepository;
       

        public FileCommandService(IFileRepository fileRepository, ISellerRepository sellerRepository)
        {
            _fileRepository = fileRepository;
            _sellerRepository = sellerRepository;
            
        }
        public async Task<string> DeleteFile(int fileId)
        {
            var fileDto = await _fileRepository.GetByIdAsync(fileId);
            if (fileDto == null)
                return "فایل یافت نشد.";

            var result = await _fileRepository.DeleteAsync(fileDto);
            if (result)
                return "عملیات با موفقیت انجام شد.";
            else
                return "عملیات با شکست مواجه شد";
        }

        public async Task<string> UploadFile(int sellerId, FileAddDto inputDto)
        {
            var sellerExist = await _sellerRepository.GetByIdAsync(sellerId);
            if (sellerExist == null)
                return "کاربر یافت نشد.";
            var result = await _fileRepository.AddAsync(inputDto, sellerId);
            if (result != 0)
                return "عملیات با موفقیت انجام شد.";
            return "عملیات با مشکل مواجه شد.";
        }
       
    }


}
