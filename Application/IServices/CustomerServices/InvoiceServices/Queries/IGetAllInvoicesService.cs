

using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.InvoiceServices.Queries
{
    public interface IGetAllInvoicesService
    {
       List<GeneralDto<InvoiceDto>> Execute();

    }
}
