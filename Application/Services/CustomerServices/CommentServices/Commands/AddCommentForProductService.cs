using Application.IServices.CustomerServices.CommentServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.CommentServices.Commands
{
    public class AddCommentForProductService : IAddCommentForProductService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IProductRepository _productRepository;

        public AddCommentForProductService(ICustomerRepository customerRepository, ICommentRepository commentRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _commentRepository = commentRepository;
            _productRepository = productRepository; 
        }

        public async Task<string> Execute(CommentAddDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(Convert.ToInt32(dto.userId));
            var product = await _productRepository.GetByIdAsync(dto.productId);
            if (customer==null)
            {
                return "کاربر یافت نشد";
            }
            if (product == null)
            {
                return "کالا یافت نشد";
            }

          var result=  await _commentRepository.AddAsync(dto);
          if (result!=0)
          {
              return "دیدگاه با موفقیت ثبت شد";
          }

          return "دیدگاه ثبت نشد";
        }
    }
}
