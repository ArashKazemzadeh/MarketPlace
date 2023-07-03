using Domin.IRepositories.Dtos.Bid;

namespace Application.IServices.CustomerServices.BidServices.Queries;

public interface IBidCustomerQueryServise
{
    Task<List<BidGetRepDto>> GetCustomerBids(int customerId);
}