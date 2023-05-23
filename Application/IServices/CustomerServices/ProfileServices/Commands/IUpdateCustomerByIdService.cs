using Application.Dtos;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.CustomerServices.ProfileServices.Commands
{
    public interface IUpdateCustomerByIdService
    {
       GeneralDto<CustomerDto> Execute(CustomerDto customerDto);

    }
}
