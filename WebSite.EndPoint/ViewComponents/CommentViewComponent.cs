
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.CommentServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels;

namespace WebSite.EndPoint.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentQueryService _commentQueryService;
    

        public CommentViewComponent(ICommentQueryService commentQueryService)
        {
            _commentQueryService = commentQueryService;
          
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var comments = await _commentQueryService.GetCommentByProductId(productId);
            var model = comments.Select(c => new GetCommentVM
            {
                Id = productId,
                Description = c.Description,
                Title = c.Title,
                RegisterDate = c.RegisterDate,
                ProductName = c.Product.Name,
                UserId = c.CustomerId.ToString()
            }).ToList();
            return View(model);
        }
    }
}
