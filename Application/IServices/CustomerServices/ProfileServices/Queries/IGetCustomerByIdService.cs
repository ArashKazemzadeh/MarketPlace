using Domin.IRepositories.Dtos;


namespace Application.IServices.CustomerServices.ProfileServices.Queries
{


    public interface IGetCustomerByIdService
    {
        Task<CustomerGetDto> Execute(int customerid);

    }



}
