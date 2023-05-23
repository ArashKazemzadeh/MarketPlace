using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.ImageServices.Commands
{
    public interface IDeleteImageForProductService
    {
        GeneralDto Execute(ImageForProductDto imagedto, int productId);

    }
}
