using Domin.IRepositories.Dtos;

namespace Application.IServices.CustomerServices.BidServices.Queries;

public interface IBidCustomerQueryServise
{
    Task<List<BidGetRepDto>> GetCustomerBids(int customerId);
}