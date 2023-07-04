
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.CommentServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels;

namespace WebSite.EndPoint.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        private readonly ICommentQueryService _commentQueryService;
        private readonly IAccountService _accountService;


        public CommentViewComponent(ICommentQueryService commentQueryService, IAccountService accountService)
        {
            _commentQueryService = commentQueryService;
            _accountService = accountService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
           
            var comments = await _commentQueryService.GetCommentByProductId(productId);
            var model = comments.Select( c => new GetCommentVM
            {
                Id = productId,
                Description = c.Description,
                Title = c.Title,
                RegisterDate = c.RegisterDate,
           UserId = c.CustomerId.ToString()
            }).ToList();
            return View(model);
        }
    }
}
