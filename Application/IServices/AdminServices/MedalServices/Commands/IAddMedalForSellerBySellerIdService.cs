using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.AdminServices.MedalServices.Commands
{
    public interface IAddMedalForSellerBySellerIdService
    {
        GeneralDto<SellerDto> Execute(int id);

    }
}
