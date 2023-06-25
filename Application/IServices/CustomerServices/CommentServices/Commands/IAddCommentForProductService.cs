using Application.Dtos;
using Domin.IRepositories.Dtos;


namespace Application.IServices.CustomerServices.CommentServices.Commands
{
    public interface IAddCommentForProductService
    {
        Task<string> Execute(CommentAddDto dto);

    }


}
