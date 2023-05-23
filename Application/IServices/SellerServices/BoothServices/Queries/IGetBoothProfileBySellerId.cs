using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.BoothServices.Queries
{
    public interface IGetBoothProfileBySellerId
    {
        GeneralDto<BoothDto> Execute(int sellerId);

    }
}
