using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using Domin.IRepositories.Dtos;
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

        public async Task<GeneralDto> ExecuteFalse(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new GeneralDto
                {
                    message = "این کالا موجود نیست."
                };
            }
            //صحت این متد بررسی شود
            if (product.IsConfirm == null)
            {
                product.IsConfirm = false;
               
                await _productRepository.UpdateAsync(product);
                return new GeneralDto
                {
                    message = "کالا با موفقیت رد شد."
                };
            }
            return new GeneralDto
            {
                message = "عملیات با مشکل مواجه شد."
            };
        }

        public async Task<GeneralDto>  ExecuteTrue(int id)
        {
            var product =await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new GeneralDto
                {
                    message = "این کالا موجود نیست."
                };
            }

            if (product.IsConfirm == null)
            {
               
               
                
                product.IsConfirm = true;


await _productRepository.UpdateAsync(product);
                return new GeneralDto
                {
                    message = "کالا با موفقیت تایید شد."
                };
            }
            return new GeneralDto
            {
                message = "عملیات با مشکل مواجه شد."
            };

        }
    }
}
