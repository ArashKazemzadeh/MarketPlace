using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.AuctionServices.Queries
{
    public interface IGetAuctionByIdService
    {
        Task<GeneralDto<AuctionDto>> Execute(int id);
    }
}
