using Microsoft.Data.SqlClient;
using System.Data;
using ConsoleApp1.Models;
using Dapper;
using Domin.IRepositories.IseparationRepository.Dapper;
using Domin.IRepositories.Dtos.Seller;

namespace Persistence.Repositories.DapperRepositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly string _connectionString = "Server=.\\SQL2022;Database=MarketPlaceDb;User Id=sa;Password=377-00;TrustServerCertificate=True;";

        public UserDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<FinancialRepSeller> GetFinancialBySellerId(int sellerId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, CommissionPercentage, CommissionsAmount, SalesAmount FROM Sellers WHERE Id = @SellerId";
                var financial = await connection.QueryFirstOrDefaultAsync<Seller>(query, new { SellerId = sellerId });
                var result = new FinancialRepSeller
                {
                    Id = financial.Id,
                    CommissionPercentage = financial.CommissionPercentage,
                    CommissionsAmount = financial.CommissionsAmount,
                    SalesAmount = financial.SalesAmount
                };
                return result;
            }
        }
    }
}
