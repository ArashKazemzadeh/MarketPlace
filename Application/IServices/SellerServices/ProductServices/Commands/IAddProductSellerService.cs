﻿using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.ProductServices.Commands
{
    public interface IAddProductSellerService
    {
        GeneralDto<ProductDto> Execute(ProductDto productDto,int boothId);

    }
}
