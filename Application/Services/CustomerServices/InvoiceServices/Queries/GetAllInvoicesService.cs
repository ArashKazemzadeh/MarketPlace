using Application.Dtos;
using Application.IServices.CustomerServices.InvoiceServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.InvoiceServices.Queries
{
    public class GetAllInvoicesService : IGetAllInvoicesService
    {
        public List<GeneralDto<InvoiceDto>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
