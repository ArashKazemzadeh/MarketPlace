using Application.Dtos;
using Application.IServices.CustomerServices.InvoiceServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.InvoiceServices.Queries
{
    internal class GetInvoiceByIdService : IGetInvoiceByIdService
    {
        public GeneralDto<InvoiceDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
