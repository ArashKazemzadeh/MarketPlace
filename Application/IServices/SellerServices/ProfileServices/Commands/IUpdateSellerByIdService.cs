using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.SellerServices.ProfileServices.Commands
{
    public interface IUpdateSellerByIdService
    {
       GeneralDto<SellerDto>  Execute( int sellerId);

    }
}
