﻿using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.SellerServices.ProfileServices.Queries
{
    public interface IGetSellerByIdService
    {
        GeneralDto<SellerDto> Execute(int sellerId);

    }
}
