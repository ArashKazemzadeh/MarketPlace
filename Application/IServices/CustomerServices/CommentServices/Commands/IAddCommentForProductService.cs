using Application.Dtos;
using ConsoleApp.Models;


namespace Application.IServices.CustomerServices.CommentServices.Commands
{
    public interface IAddCommentForProductService
    {
        GeneralDto<CommentDto> Execute(CommentDto commentDto);

    }
}
