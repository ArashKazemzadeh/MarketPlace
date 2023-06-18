using Application.IServices.CustomerServices.SellerServices.Queries;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.CustomerServices.SellerServices.Queries
{
    public class GetBoothsByCategoryId : IGetBoothsByCategoryId
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBoothRepository _boothRepository;
        public GetBoothsByCategoryId(ICategoryRepository categoryRepository, 
            IBoothRepository boothRepository)
        {
            _categoryRepository = categoryRepository;
            _boothRepository = boothRepository;
        }
        public async Task<List<BoothRepositoryDto>> Execute(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return null;
            }
            var booths = await _boothRepository.GetByCategoryIdAsync(categoryId);
            var boothsDto = booths.Select(b => new BoothRepositoryDto
            {
                Id = b.Id,
                SellerId = b.SellerId,
                Seller = b.Seller,
                SellerName = b.Seller.CompanyName,
                Description = b.Description,
                Name = b.Name
            }).ToList();
            return boothsDto;
        }


    }
}
