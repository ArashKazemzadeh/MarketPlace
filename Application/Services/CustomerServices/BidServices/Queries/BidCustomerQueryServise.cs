﻿using Application.IServices.CustomerServices.BidServices.Queries;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Domin.IRepositories.Dtos.Bid;

namespace Application.Services.CustomerServices.BidServices.Queries
{
    public class BidCustomerQueryServise : IBidCustomerQueryServise
    {

        private readonly IBidRepository _bidRepository;
        public BidCustomerQueryServise(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public async Task<List<BidGetRepDto>> GetCustomerBids(int customerId)
        {
            var customerBids = await _bidRepository.GetBidsByCustomerId(customerId);
            if (customerBids == null || customerBids.Count == 0)
                return new List<BidGetRepDto>();
            return customerBids;
        }
    }
}
