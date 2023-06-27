using Application.Dtos;
using Application.IServices.SellerServices.ProductServices.Commands;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ProductServices.Commands
{
    public class DeleteProductSellerService : IDeleteProductSellerService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductSellerService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GeneralDto> Execute(int id)
        {
            var productGeneral = await _productRepository.GetByIdAsync(id);
            if (productGeneral == null)
                return new GeneralDto { message = "کالا موجود نیست" };
            if (productGeneral.IsAuction)
                return new GeneralDto { message = "تا پایان مزایده امکان حذف کالا وجود ندارد" };


            await _productRepository.DeleteAsync(id);
            return new GeneralDto
            {
                message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
