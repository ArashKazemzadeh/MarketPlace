using Domin.IRepositories.Dtos.Comment;

namespace Application.IServices.CustomerServices.ProfileServices.Queries
{


    public interface IGetCustomerByIdService
    {
        Task<CustomerGetDto> Execute(int customerid);

    }



}
