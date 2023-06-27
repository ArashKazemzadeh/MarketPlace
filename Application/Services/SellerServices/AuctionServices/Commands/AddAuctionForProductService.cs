﻿using Application.IServices.SellerServices.AuctionServices.Commands;
using ConsoleApp.Models;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
namespace Application.Services.SellerServices.AuctionServices.Commands;




public class AddAuctionForProductService : IAddAuctionForProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IAuctionRepository _auctionRepository;
    public AddAuctionForProductService(IProductRepository productRepository,
        IAuctionRepository auctionRepository)
    {
        _productRepository = productRepository;
        _auctionRepository = auctionRepository;
    }
    public async Task<string> Execute(AuctionDto auctionDto, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
            return "کالایافت نشد.";
        if (product.IsAuction)
            return "شما قبلا برای این کالا مزایده ثبت کرده اید";
        if (product.IsActive==false)
            return "مزایده ی این کالا تمام شده و کالا به حالت غیرفعال در آمده است.";
        if (product.Availability<1)
            return "برای شرکت در مزایده تعداد کافی کالا موجود نیست.";
        var auction = new Auction
        {
            StartDeadTime = auctionDto.StartDeadTime,
            EndDeadTime = auctionDto.EndDeadTime,
            HighestPrice = auctionDto.HighestPrice,
            ProductId = productId,
        };
        product.IsAuction = true;
        await _auctionRepository.AddAsync(auction);
        product.Auction = auction;
        await _productRepository.UpdateAsync(product);
        return "مزایده با موفقیت ایجاد شد.";
    }
}

