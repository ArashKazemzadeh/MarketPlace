using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.SellerServices.AuctionServices.Commands
{
    public interface IAddAuctionForProductService
    {
        GeneralDto<AuctionDto> Execute(AuctionDto auctionDto);
    }
}
