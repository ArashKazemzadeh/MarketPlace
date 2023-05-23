using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.BoothServices.Commands
{
    public interface IInActiveBoothSellerService
    {
        GeneralDto Execute(int id);

    }
}
