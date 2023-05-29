using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ProoductServices.Commands
{
    public class ConfirmForAddProductService : IConfirmForAddProductService
    {
        private readonly IProductRepository _productRepository;

        public ConfirmForAddProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GeneralDto>  Execute(int id)
        {
            var product =await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new GeneralDto
                {
                    message = "این کالا موجود نیست."
                };
            }

            if (product.IsConfirm == null || product.IsConfirm == false)
            {
                product.IsConfirm = true;
                return new GeneralDto
                {
                    message = "کالا با موفقیت تایید شد."
                };
            }
            else
            {
                product.IsConfirm = false;
                return new GeneralDto
                {
                    message = "تاییدیه کالا جهت نمایش و فروش لغو شد."
                };
            }

        }
    }
}
