using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.CustomerServices.BidServices.Commands
{
    public interface IAddBidForAuctionService
    {
        GeneralDto<BidDto> Execute(BidDto biddto);

    }
}
