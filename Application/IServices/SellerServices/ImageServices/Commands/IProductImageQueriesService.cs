﻿using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Image;

namespace Application.IServices.SellerServices.ImageServices.Commands;

public interface IProductImageQueriesService
{
    Task<List<string>> GetImageUrlForProduct(int productId);
    Task<Image> GetImageByIdAsync(int imageId);
    Task<IEnumerable<Image>> GetImagesForProductAsync(int productId);
    Task<List<ImageForProductRepDto>> GetAllImageProductBySellerId(int sellerId);
}