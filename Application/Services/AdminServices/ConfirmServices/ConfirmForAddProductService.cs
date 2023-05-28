using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ConfirmServices
{
    public class ConfirmForAddProductService : IConfirmForAddProductService
    {
        private readonly IProductRepository _productRepository;

        public ConfirmForAddProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public GeneralDto Execute(int id)
        {
           var product= _productRepository.GetByIdAsync(id);
           if (product.Result ==null)
           {
               return new GeneralDto
               {
                   message = "این کالا موجود نیست."
               };
           }

           if (product.Result.IsConfirm == null || product.Result.IsConfirm == false)
           {
               product.Result.IsConfirm = true;
               return new GeneralDto
               {
                   message = "کالا با موفقیت تایید شد."
               };
            }
           else
           {
               product.Result.IsConfirm = false;
               return new GeneralDto
               {
                   message = "تاییدیه کالا جهت نمایش و فروش لغو شد."
               };
            }

        }
    }
}
