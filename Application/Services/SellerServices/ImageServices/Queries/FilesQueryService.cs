﻿using Application.IServices.SellerServices.ImageServices.Queries;
using Domin.IRepositories.Dtos.File;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ImageServices.Queries
{
    public class FilesQueryService : IFilesQueryService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IFileRepository _fileRepository;

        public FilesQueryService(ISellerRepository sellerRepository, IFileRepository fileRepository)
        {
            _sellerRepository = sellerRepository;
            _fileRepository = fileRepository;   
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
